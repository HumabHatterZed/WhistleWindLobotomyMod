using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using InscryptionAPI;
using InscryptionAPI.Saves;
using DiskCardGame;
using HarmonyLib;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhistleWindLobotomyMod
{
    // Currently only used for special dialogue, will be used for other things/replaced with a better system(s)
    public static partial class PersistentValues
    {
        #region Plague Doctor
        public static bool ClockThisRun
        {
            // Has the Clock struck twelve this run?
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ClockStruckTwelve"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ClockStruckTwelve", value); }
        }
        public static bool ApostleKilled
        {
            // Keeps track of whether this is the first time the player has tried to kill an Apostle
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ApostleMurderAttempted"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ApostleMurderAttempted", value); }
        }
        public static bool ApostleDowned
        {
            // Keeps track of whether this is the first time an Apostle has been downed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ApostleDowned"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ApostleDowned", value); }
        }
        public static bool WhiteNightHammer
        {
            // Keeps track of whether this is the first time the player has tried to kill WhiteNight using a null killer (hammer)
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "WhiteNightMurderAttempted"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "WhiteNightMurderAttempted", value); }
        }
        public static bool WhiteNightKilled
        {
            // Keeps track of whether this is the first time WhiteNight has been killed by a card
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "WhiteNightDefeated"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "WhiteNightDefeated", value); }
        }
        public static bool ApostleHeretic
        {
            // Keeps track of whether this is the first time the player has tried to kill WhiteNight
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ApostleHereticAppeared"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ApostleHereticAppeared", value); }
        }
        #endregion

        #region Magical Girls
        public static bool HasSeenHatredTransformation
        {
            // Keeps track of whether this is the first time Magical Girl H has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "TransformedIntoHatred");
            }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "TransformedIntoHatred", value); }
        }
        public static bool HasSeenHatredTireOut
        {
            // Keeps track of whether this is the first time Queen oF Hatred has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "HatredExhausted"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "HatredExhausted", value); }
        }
        public static bool HasSeenHatredRecover
        {
            // Keeps track of whether this is the first time Queen oF Hatred (E) has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "HatredRecovered"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "HatredRecovered", value); }
        }
        public static bool HasSeenGreedTransformation
        {
            // Keeps track of whether this is the first time Magical Girl D has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "TransformedIntoGreed"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "TransformedIntoGreed", value); }
        }
        public static bool HasSeenDespairProtect
        {
            // Keeps track of whether this is the first time Magical Girl S has protected
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ProtectedByKnight"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ProtectedByKnight", value); }
        }
        public static bool HasSeenDespairTransformation
        {
            // Keeps track of whether this is the first time Magical Girl S has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "TransformedIntoDespair"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "TransformedIntoDespair", value); }
        }
        #endregion

        #region ALEPHs
        public static bool HasSeenNothingTransformation
        {
            // Keeps track of whether this is the first time Nothing There has revealed its True forme
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "NothingThereRevealed"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "NothingThereRevealed", value); }
        }
        public static bool HasSeenNothingTransformationTrue
        {
            // Keeps track of whether this is the first time Nothing There True has transformed into Egg forme
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "NothingTherePupated"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "NothingTherePupated", value); }
        }
        public static bool HasSeenNothingTransformationEgg
        {
            // Keeps track of whether this is the first time Nothing There Egg has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "NothingThereHatched"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "NothingThereHatched", value); }
        }
        public static bool HasSeenMountainGrow
        {
            // Keeps track of whether this is the first time MoSB-1/-2 has grown
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "MountainOfBodiesGrown"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "MountainOfBodiesGrown", value); }
        }
        public static bool HasSeenMountainShrink
        {
            // Keeps track of whether this is the first time MoSB-2/-3 has shrunk
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "MountainOfBodiesShrunk"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "MountainOfBodiesShrunk", value); }
        }
        public static bool HasSeenCensoredKill
        {
            // Keeps track of whether this is the first time Censored has <CENSORED>
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "CENSOREDCreatedMinion"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "CENSOREDCreatedMinion", value); }
        }
        public static bool HasSeenArmyBlacked
        {
            // Keeps track of whether this is the first time Army in Pink has gone black
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ArmyTurnedBlack"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ArmyTurnedBlack", value); }
        }
        public static bool HasSeenMeltingHeal
        {
            // Keeps track of whether this is the first time Melting Love has absorbed a minion
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "MeltingLoveMinionAbsorbed"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "MeltingLoveMinionAbsorbed", value); }
        }
        #endregion

        #region HEs
        public static bool HasSeenDerFreischutzSeventh
        {
            // Keeps track of whether this is the first time Freischutz has shot his seventh bullet
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "FreischutzSeventhBullet"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "FreischutzSeventhBullet", value); }
        }
        public static bool HasSeenCrumblingArmourKill
        {
            // Keeps track of whether this is the first time Crumbling Armour has punished a coward
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "CowardnessPunished"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "CowardnessPunished", value); }
        }
        public static bool HasSeenCrumblingArmourFail
        {
            // Keeps track of whether this is the first time Crumbling Armour hasn't given Power
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "CourageFailed"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "CourageFailed", value); }
        }
        public static bool HasSeenCrumblingArmourRefuse
        {
            // Keeps track of whether this is the first time -Courageous- has refused to give Power
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "CourageRefused"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "CourageRefused", value); }
        }
        public static bool HasSeenSnowQueenFreeze
        {
            // Keeps track of whether this is the first time Snow Quene has frozen a card
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "SnowQueenFrozen"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "SnowQueenFrozen", value); }
        }
        public static bool HasSeenSnowQueenFail
        {
            // Keeps track of whether this is the first time Snow Quene has failed to freeze
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "SnowQueenFail"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "SnowQueenFail", value); }
        }
        #endregion

        #region TETHs
        public static bool HasSeenBloodbathHand
        {
            // Keeps track of whether this is the first time Bloodbath has grown
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "BloodBathHand1"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "BloodBathHand1", value); }
        }
        public static bool HasSeenBloodbathHand1
        {
            // Keeps track of whether this is the second time Bloodbath has grown
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "BloodBathHand2"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "BloodBathHand2", value); }
        }
        public static bool HasSeenBloodbathHand2
        {
            // Keeps track of whether this is the third time Bloodbath has grown
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "BloodBathHand3"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "BloodBathHand3", value); }
        }
        public static bool HasSeenBeautyTransform
        {
            // Keeps track of whether this is the first time a player card has transformed
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "PlayerTransformedByCurse"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "PlayerTransformedByCurse", value); }
        }
        public static bool HasSeenShyLookAngry
        {
            // Keeps track of whether this is the first time Today's Shy Look became Angry
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ShyLookedAngryToday"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ShyLookedAngryToday", value); }
        }
        public static bool HasSeenShyLookHappy
        {
            // Keeps track of whether this is the first time Today's Shy Look became Angry
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ShyLookedHappyToday"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ShyLookedHappyToday", value); }
        }
        public static bool HasSeenShyLookNeutral
        {
            // Keeps track of whether this is the first time Today's Shy Look be indecisive
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "ShyLookedNeutralToday"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "ShyLookedNeutralToday", value); }
        }
        public static bool HasSeenRegeneratorExplode
        {
            // Keeps track of whether this is the first time Regenerator caused magic cancer
            get { return ModdedSaveManager.RunState.GetValueAsBoolean(WstlPlugin.pluginGuid, "RegeneratorCancer"); }
            set { ModdedSaveManager.RunState.SetValue(WstlPlugin.pluginGuid, "RegeneratorCancer", value); }
        }
        #endregion

        #region ZAYINs

        #endregion
    }
}