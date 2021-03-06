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
        private void Ability_Martyr()
        {
            const string rulebookName = "Martyr";
            const string rulebookDescription = "When a card bearing this sigil dies, all allied creatures gain 2 Health.";
            const string dialogue = "A selfless death to cleanse your beasts of evil.";

            Martyr.ability = AbilityHelper.CreateAbility<Martyr>(
                Resources.sigilMartyr,// Resources.sigilMartyr_pixel,
                rulebookName, rulebookDescription, dialogue, powerLevel: 2,
                addModular: true).Id;
        }
    }
    public class Martyr : AbilityBehaviour
    {
        public static Ability ability;
        public override Ability Ability => ability;

        public override bool RespondsToDie(bool wasSacrifice, PlayableCard killer)
        {
            foreach (CardSlot slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy.Where((CardSlot s) => s.Card != null && s.Card != base.Card))
            {
                return !base.Card.OpponentCard && !wasSacrifice && killer != null;
            }
            return false;
        }
        public override IEnumerator OnDie(bool wasSacrifice, PlayableCard killer)
        {
            // SigilADay julianperge
            yield return base.PreSuccessfulTriggerSequence();
            yield return new WaitForSeconds(0.2f);
            foreach (var slot in Singleton<BoardManager>.Instance.PlayerSlotsCopy.Where(slot => slot.Card != base.Card))
            {
                if (slot.Card != null)
                {
                    slot.Card.HealDamage(2);
                    slot.Card.Anim.LightNegationEffect();
                    yield return new WaitForSeconds(0.15f);
                }    
            }
            yield return base.LearnAbility(0.25f);
        }
    }
}
