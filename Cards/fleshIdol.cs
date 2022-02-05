﻿using System.Collections.Generic;
using DiskCardGame;
using APIPlugin;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private void FleshIdol_T0979()
        {
            List<Ability> abilities = new List<Ability>
            {
                GroupHealer.ability,
                Ability.BuffEnemy
            };

            WstlUtils.Add(
                "wstl_fleshIdol", "Flesh Idol",
                "This is a record, a record of a day we must never forget.",
                2, 0, 0, 6,
                Resources.fleshIdol,
                abilities: abilities, new List<SpecialAbilityIdentifier>(),
                new List<Tribe>(), metaCategory: CardMetaCategory.Rare,
                appearanceBehaviour: CardUtils.getRareAppearance, onePerDeck: true);
        }
    }
}