using InscryptionAPI;
using InscryptionAPI.Card;
using InscryptionAPI.Triggers;
using DiskCardGame;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void Ability_BitterEnemies()
        {
            const string rulebookName = "Bitter Enemies";
            const string rulebookDescription = "A card bearing this sigil gains 1 Power when another card on this board also has this sigil.";
            const string dialogue = "A bitter grudge laid bare.";

            BitterEnemies.ability = AbilityHelper.CreateAbility<BitterEnemies>(
                Resources.sigilBitterEnemies,// Resources.sigilBitterEnemies_pixel,
                rulebookName, rulebookDescription, dialogue, powerLevel: 2,
                addModular: true).Id;
        }
    }
    public class BitterEnemies : AbilityBehaviour, IPassiveAttackBuff
    {
        public static Ability ability;
        public override Ability Ability => ability;

        public override bool RespondsToResolveOnBoard()
        {
            return ActivateOnPlay();
        }
        public override IEnumerator OnResolveOnBoard()
        {
            yield return base.LearnAbility(0.4f);
        }
        public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
        {
            return ActivateOnPlay();
        }
        public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
        {
            yield return base.LearnAbility(0.4f);
        }
        // Gives +1 Attack to all cards with Bitter Enemies when two or more exist on the board
        public int GetPassiveAttackBuff(PlayableCard target)
        {
            int count = 0;
            foreach (CardSlot slot in Singleton<BoardManager>.Instance.AllSlotsCopy.Where(slot => slot != base.Card.Slot))
            {
                if (slot.Card != null && slot.Card.HasAbility(BitterEnemies.ability))
                {
                    count++;
                }
            }
            return this.Card.OnBoard && target != this.Card && target.Info.HasAbility(BitterEnemies.ability) && count > 0 ? 1 : 0;
        }
        public bool ActivateOnPlay()
        {
            foreach (CardSlot slot in Singleton<BoardManager>.Instance.AllSlotsCopy.Where(slot => slot != base.Card.Slot))
            {
                if (slot.Card != null && slot.Card.HasAbility(BitterEnemies.ability))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
