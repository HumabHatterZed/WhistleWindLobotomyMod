﻿using APIPlugin;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private void ApostleScythe_T0346()
        {
            List<Ability> abilities = new()
            {
                Woodcutter.ability,
                Apostle.ability
            };

            List<Trait> traits = new()
            {
                Trait.Uncuttable,
                Trait.Pelt
            };

            WstlUtils.Add(
                "wstl_apostleScythe", "Scythe Apostle",
                "The time has come.",
                3, 6, 0, 0,
                Resources.apostleScythe,
                abilities: abilities, new List<SpecialAbilityIdentifier>(),
                new List<Tribe>(), traits: traits,
                emissionTexture: Resources.apostleScythe_emission);
        }
    }
}