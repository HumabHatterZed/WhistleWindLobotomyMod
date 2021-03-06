using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void Spiderling_O0243()
        {
            List<Ability> abilities = new()
            {
                Ability.Evolve
            };
            List<Tribe> tribes = new()
            {
                Tribe.Insect
            };
            CardHelper.CreateCard(
                "wstl_spiderling", "Spiderling",
                "Small and defenceless.",
                0, 1, 0, 0,
                Resources.spiderling, Resources.spiderling_emission,
                abilities: abilities, specialAbilities: new(),
                metaCategories: new(), tribes: tribes, traits: new(),
                evolveName: "wstl_spiderBrood");
        }
    }
}