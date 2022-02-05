﻿using System.Collections.Generic;
using DiskCardGame;
using APIPlugin;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private void DimensionalRefraction_O0388()
        {
            List<Ability> abilities = new List<Ability>
            {
                Ability.RandomAbility
            };

            WstlUtils.Add(
                "wstl_dimensionalRefraction", "Dimensional Refraction Variant",
                "The beast is the phenomenon itself.",
                4, 4, 3, 0,
                Resources.dimensionalRefraction,
                abilities: abilities, new List<SpecialAbilityIdentifier>(),
                new List<Tribe>(), metaCategory: CardMetaCategory.ChoiceNode);
        }
    }
}