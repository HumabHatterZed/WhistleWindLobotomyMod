﻿using APIPlugin;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private void NothingThere_O0620()
        {
            List<Ability> abilities = new()
            {
                Ability.Reach
            };
            List<SpecialAbilityIdentifier> specialAbilities = new()
            {
                NothingThere.GetSpecialAbilityId
            };

            WstlUtils.Add(
                "wstl_nothingThere", "Yumi",
                "I don't remember this challenger...",
                1, 1, 2, 0,
                Resources.nothingThere,
                abilities: abilities, specialAbilities: specialAbilities,
                new List<Tribe>(), metaCategory: CardMetaCategory.Rare,
                emissionTexture: Resources.nothingThere_emission,
                appearanceBehaviour: CardUtils.getRareAppearance);
        }
    }
}