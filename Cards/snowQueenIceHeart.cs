using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void SnowQueenIceHeart_F0137()
        {
            List<Ability> abilities = new()
            {
                FrozenHeart.ability
            };
            CardHelper.CreateCard(
                "wstl_snowQueenIceHeart", "Frozen Heart",
                "The palace was cold and lonely.",
                0, 1, 0, 0,
                Resources.snowQueenIceHeart, Resources.snowQueenIceHeart_emission,
                abilities: abilities, specialAbilities: new(),
                metaCategories: new(), tribes: new(), traits: new(),
                isTerrain: true);
        }
    }
}