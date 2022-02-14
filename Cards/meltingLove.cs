﻿using APIPlugin;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private void MeltingLove_D03109()
        {
            List<Ability> abilities = new()
            {
                Slime.ability
            };
            List<Trait> traits = new()
            {
                Trait.KillsSurvivors
            };
            WstlUtils.Add(
                "wstl_meltingLove", "Melting Love",
                "Don't let your beasts get too close now.",
                4, 2, 3, 0,
                Resources.meltingLove,
                abilities: abilities, new List<SpecialAbilityIdentifier>(),
                new List<Tribe>(), traits: traits, metaCategory: CardMetaCategory.Rare,
                emissionTexture: Resources.rudoltaSleigh_emission,
                appearanceBehaviour: CardUtils.getRareAppearance, onePerDeck: true);
        }
    }
}