﻿using APIPlugin;
using DiskCardGame;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private NewSpecialAbility AbilityHelper()
        {
            const string rulebookName = "AbilityHelper";
            const string rulebookDescription = "tiddy";
            return WstlUtils.CreateSpecialAbility<_AbilityHelper>(
                AbilitiesUtil.LoadAbilityIcon("None"),
                rulebookName, rulebookDescription, overrideDesc: true);
        }
    }
    public class _AbilityHelper : SpecialCardBehaviour
    {
        public static SpecialTriggeredAbility specialAbility;
        public static SpecialAbilityIdentifier GetSpecialAbilityId
        {
            get
            {
                return SpecialAbilityIdentifier.GetID(WhistleWindLobotomyMod.Plugin.pluginGUID, "AbilityHelper");
            }
        }

        private bool IsHateA => base.PlayableCard.Info.name.ToLowerInvariant().Equals("wstl_queenofhatred");
        private bool IsHateB => base.PlayableCard.Info.name.ToLowerInvariant().Equals("wstl_queenofhatredexhausted");
        private bool IsGreed => base.PlayableCard.Info.name.ToLowerInvariant().Equals("wstl_magicalgirldiamond");
        private bool IsNothingTrue => base.PlayableCard.Info.name.ToLowerInvariant().Equals("wstl_nothingtheretrue");
        private bool IsNothingEgg => base.PlayableCard.Info.name.ToLowerInvariant().Equals("wstl_nothingthereegg");

        private readonly string hateADialogue = "A formidable attack. Shame it has left her too tired to defend herself.";
        private readonly string hateBDialogue = "The monster returns to full strength.";
        private readonly string greedDialogue = "Desire unfulfilled, the koi continues for Eden.";
        private readonly string nothingTrueDialogue = "What is it doing?";
        private readonly string nothingEggDialogue = "It seems to be trying to mimic you. 'Trying' is the key word.";

        public override bool RespondsToUpkeep(bool playerUpkeep)
        {
            if (IsGreed || IsNothingTrue || IsNothingEgg)
            {
                if (!base.PlayableCard.Slot.IsPlayerSlot)
                {
                    return !playerUpkeep;
                }
                return playerUpkeep;
            }
            return false;
        }
        public override IEnumerator OnUpkeep(bool playerUpkeep)
        {
            if (IsGreed) // Magical Girl D --> King of Greed
            {
                if (!PersistentValues.HasSeenGreedTransformation)
                {
                    PersistentValues.HasSeenGreedTransformation = true;
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(greedDialogue, -0.65f, 0.4f);
                }
                yield break;
            }
            if (IsNothingTrue) // Nothing There True --> Nothing There Egg
            {
                if (!PersistentValues.HasSeenNothingTransformationTrue)
                {
                    PersistentValues.HasSeenNothingTransformationTrue = true;
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(nothingTrueDialogue, -0.65f, 0.4f);
                }
                yield break;
            }
            if (IsNothingEgg) // Nothing There Egg --> Nothing There Final
            {
                CardInfo evolution = CardLoader.GetCardByName("wstl_nothingThereFinal");

                foreach (CardModificationInfo item in base.Card.Info.Mods.FindAll((CardModificationInfo x) => !x.nonCopyable))
                {
                    CardModificationInfo cardModificationInfo = (CardModificationInfo)item.Clone();
                    if (cardModificationInfo.HasAbility(Ability.Evolve))
                    {
                        cardModificationInfo.abilities.Remove(Ability.Evolve);
                    }
                    evolution.Mods.Add(cardModificationInfo);
                }
                yield return base.PlayableCard.TransformIntoCard(evolution);
                yield return new WaitForSeconds(0.5f);
                if (!PersistentValues.HasSeenNothingTransformationEgg)
                {
                    PersistentValues.HasSeenNothingTransformationEgg = true;
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(nothingEggDialogue, -0.65f, 0.4f, Emotion.Curious);
                }
                yield return new WaitForSeconds(0.25f);
                yield break;
            }
        }

        public override bool RespondsToTurnEnd(bool playerTurnEnd)
        {
            if (IsHateA || IsHateB)
            {
                if (!base.PlayableCard.Slot.IsPlayerSlot)
                {
                    return !playerTurnEnd;
                }
                return playerTurnEnd;
            }
            return false;
        }
        public override IEnumerator OnTurnEnd(bool playerTurnEnd)
        {
            if (IsHateA) // Queen of Hatred --> Queen of Hatred Exhausted
            {
                CardInfo evolution = CardLoader.GetCardByName("wstl_queenOfHatredExhausted");

                foreach (CardModificationInfo item in base.Card.Info.Mods.FindAll((CardModificationInfo x) => !x.nonCopyable))
                {
                    CardModificationInfo cardModificationInfo = (CardModificationInfo)item.Clone();
                    evolution.Mods.Add(cardModificationInfo);
                }
                yield return base.PlayableCard.TransformIntoCard(evolution);
                yield return new WaitForSeconds(0.5f);
                if (!PersistentValues.HasSeenHatredTireOut)
                {
                    PersistentValues.HasSeenHatredTireOut = true;
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(hateADialogue, -0.65f, 0.4f);
                }
                yield return new WaitForSeconds(0.25f);
                yield break;
            }
            if (IsHateB) // Queen of Hatred Exhausted --> Queen of Hatred
            {
                CardInfo evolution = CardLoader.GetCardByName("wstl_queenOfHatred");

                foreach (CardModificationInfo item in base.Card.Info.Mods.FindAll((CardModificationInfo x) => !x.nonCopyable))
                {
                    CardModificationInfo cardModificationInfo = (CardModificationInfo)item.Clone();
                    evolution.Mods.Add(cardModificationInfo);
                }
                yield return base.PlayableCard.TransformIntoCard(evolution);
                yield return new WaitForSeconds(0.5f);
                if (!PersistentValues.HasSeenHatredRecover)
                {
                    PersistentValues.HasSeenHatredRecover = true;
                    yield return Singleton<TextDisplayer>.Instance.ShowUntilInput(hateBDialogue, -0.65f, 0.4f);
                }
                yield return new WaitForSeconds(0.25f);
                yield break;
            }
        }
    }
}
