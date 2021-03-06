using InscryptionAPI;
using DiskCardGame;
using System.Collections;
using UnityEngine;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void Rulebook_MagicalGirlS()
        {
            const string rulebookName = "Magical Girl S";
            const string rulebookDescription = "Transforms when an adjacent card dies.";
            const string dialogue = "femboy";
            EntryMagicalGirlS.ability = AbilityHelper.CreateAbility<EntryMagicalGirlS>(
                Resources.sigilAbnormality,// Resources.sigilAbnormality_pixel,
                rulebookName, rulebookDescription, dialogue, powerLevel: 0,
                overrideModular: true).Id;
        }
    }
    public class EntryMagicalGirlS : AbilityBehaviour
    {
        public static Ability ability;
        public override Ability Ability => ability;
    }
}
