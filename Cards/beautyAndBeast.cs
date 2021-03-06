using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void BeautyAndBeast_O0244()
        {
            List<Ability> abilities = new()
            {
                Cursed.ability
            };

            List<Tribe> tribes = new()
            {
                Tribe.Hooved,
                Tribe.Insect
            };

            CardHelper.CreateCard(
                "wstl_beautyAndBeast", "Beauty and the Beast",
                "A pitiable creature. Death would be a mercy for it.",
                1, 1, 1, 0,
                Resources.beautyAndBeast, Resources.beautyAndBeast_emission,
                abilities: abilities, specialAbilities: new(),
                metaCategories: new(), tribes: tribes, traits: new(),
                isChoice: true, riskLevel: 2);
        }
    }
}