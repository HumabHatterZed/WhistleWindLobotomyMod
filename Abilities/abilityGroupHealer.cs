using InscryptionAPI;
using DiskCardGame;
using System.Collections;
using System.Linq;
using UnityEngine;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void Ability_GroupHealer()
        {
            const string rulebookName = "Group Healer";
            const string rulebookDescription = "While this card is on the board, all allies whose Health is below its maximum regain 1 Health at the end of the opponent's turn.";
            const string dialogue = "You only delay the inevitable.";
            GroupHealer.ability = AbilityHelper.CreateAbility<GroupHealer>(
                Resources.sigilGroupHealer,// Resources.sigilGroupHealer_pixel,
                rulebookName, rulebookDescription, dialogue, powerLevel: 4).Id;
        }
    }
    public class GroupHealer : AbilityBehaviour
    {
        public static Ability ability;
        public override Ability Ability => ability;

        public override bool RespondsToUpkeep(bool playerUpkeep)
        {
            return base.Card.Slot.IsPlayerSlot ? playerUpkeep : !playerUpkeep;
        }
        public override IEnumerator OnUpkeep(bool playerUpkeep)
        {
            Singleton<ViewManager>.Instance.SwitchToView(View.Board);

            yield return base.PreSuccessfulTriggerSequence();
            yield return new WaitForSeconds(0.25f);

            bool player = base.Card.Slot.IsPlayerSlot;
            int count = 0;
            foreach (CardSlot slot in Singleton<BoardManager>.Instance.GetSlots(player).Where(slot => slot.Card != base.Card))
            {
                if (slot.Card != null && slot.Card.Health < slot.Card.MaxHealth)
                {
                    count++;
                    slot.Card.HealDamage(1);
                    slot.Card.OnStatsChanged();
                    slot.Card.Anim.StrongNegationEffect();
                }
            }
            if (count == 0)
            {
                base.Card.Anim.StrongNegationEffect();
                yield return new WaitForSeconds(0.4f);
            }
            else
            {
                yield return new WaitForSeconds(0.4f);
                yield return base.LearnAbility(0.4f);
            }
        }
    }
}
