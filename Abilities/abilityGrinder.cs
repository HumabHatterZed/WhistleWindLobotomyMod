﻿using System.Collections;
using DiskCardGame;
using UnityEngine;
using APIPlugin;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private NewAbility Ability_Grinder()
        {
            const string rulebookName = "Grinder";
            const string rulebookDescription = "This card gains the stats of the cards sacrificed to play it.";
            const string dialogue = "Now everything will be just fine.";
            return WstlUtils.CreateAbility<Grinder>(
                Resources.sigilGrinder,
                rulebookName, rulebookDescription, dialogue, 2);
        }
    }
    public class Grinder : AbilityBehaviour
    {
        public static Ability ability;
        public override Ability Ability => ability;

        public override bool RespondsToOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
        {
            return !fromCombat && Singleton<BoardManager>.Instance.currentSacrificeDemandingCard == base.Card;
        }
        public override IEnumerator OnOtherCardDie(PlayableCard card, CardSlot deathSlot, bool fromCombat, PlayableCard killer)
        {
            yield return base.PreSuccessfulTriggerSequence();
            base.Card.AddTemporaryMod(new CardModificationInfo(card.Attack, card.Health));
            base.Card.Anim.LightNegationEffect();
            yield return new WaitForSeconds(0.25f);
            yield return base.LearnAbility(0.4f);
        }
    }
}