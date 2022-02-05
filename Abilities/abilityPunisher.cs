﻿using System.Collections;
using DiskCardGame;
using UnityEngine;
using APIPlugin;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class Plugin
    {
        private NewAbility Ability_Punisher()
        {
            const string rulebookName = "Punisher";
            const string rulebookDescription = "When a card bearing this sigil is struck, the striker is killed.";
            const string dialogue = "Retaliation is swift, but death is slow.";
            return WstlUtils.CreateAbility<Punisher>(
                Resources.sigilPunisher,
                rulebookName, rulebookDescription, dialogue, 4, true);
        }
    }
    public class Punisher : AbilityBehaviour
    {
        public static Ability ability;
        public override Ability Ability => ability;

        public override bool RespondsToTakeDamage(PlayableCard source)
        {
            return source;
        }
        public override IEnumerator OnTakeDamage(PlayableCard source)
        {
            yield return base.PreSuccessfulTriggerSequence();
            base.Card.Anim.StrongNegationEffect();
            yield return new WaitForSeconds(0.55f);
            yield return source.Die(false, base.Card, true);
            yield return base.LearnAbility(0.4f);
        }
    }
}