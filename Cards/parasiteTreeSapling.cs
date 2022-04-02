﻿using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void ParasiteTreeSapling_D04108()
        {
            WstlUtils.Add(
                "wstl_parasiteTreeSapling", "Sapling",
                "They proliferate and become whole. Can you feel it?",
                1, 2, 0, 0,
                Resources.parasiteTreeSapling, Resources.parasiteTreeSapling_emission,
                abilities: new(), specialAbilities: new(),
                metaCategories: new(), tribes: new(), traits: new());
        }
    }
}