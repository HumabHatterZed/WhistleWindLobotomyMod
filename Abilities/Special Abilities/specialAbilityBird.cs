﻿using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Resources = WhistleWindLobotomyMod.Properties.Resources;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void SpecialAbility_Bird()
        {
            const string rulebookName = "Big Bird";
            const string rulebookDescription = "Reacts to other cards being played.";
            BigBird.specialAbility = AbilityHelper.CreateSpecialAbility<BigBird>(rulebookName, rulebookDescription).Id;
        }
    }

    public class BigBird : SpecialCardBehaviour
    {
        public SpecialTriggeredAbility SpecialAbility => specialAbility;

        public static SpecialTriggeredAbility specialAbility;

        private bool Punishing;
        private bool Judgement;
        private CardSlot punishSlot;
        private CardSlot judgeSlot;
        public override bool RespondsToResolveOnBoard()
        {
            return true;
        }
        public override IEnumerator OnResolveOnBoard()
        {
            // Create table effects if Apocalypse Bird then break
            if (base.PlayableCard.Info.name == "wstl_apocalypseBird")
            {
                yield return TableEffects();
                yield break;
            }
            yield return CheckSum();
        }
        public override bool RespondsToOtherCardResolve(PlayableCard otherCard)
        {
            if (base.PlayableCard.Info.name != "wstl_apocalypseBird")
            {
                return otherCard.OpponentCard == base.PlayableCard.OpponentCard;
            }
            return false;
        }
        public override IEnumerator OnOtherCardResolve(PlayableCard otherCard)
        {
            yield return CheckSum();
        }
        private IEnumerator CheckSum()
        {
            // Break if alread have Apocalypse Bird
            if (PersistentValues.HasApocalypse)
            {
                yield break;
            }
            Punishing = false;
            Judgement = false;
            punishSlot = null;
            judgeSlot = null;
            foreach (CardSlot slot in Singleton<BoardManager>.Instance.GetSlots(!base.PlayableCard.OpponentCard).Where((CardSlot s) => s.Card != null))
            {
                if (slot != base.PlayableCard.Slot)
                {
                    if (slot.Card.Info.name == "wstl_punishingBird")
                    {
                        Punishing = true;
                        punishSlot = slot;
                    }
                    if (slot.Card.Info.name == "wstl_judgementBird")
                    {
                        Judgement = true;
                        judgeSlot = slot;
                    }
                }
            }
            if (Punishing && Judgement)
            {
                yield return Apocalypse(punishSlot, judgeSlot);
            }
            else
            {
                yield break;
            }
        }

        private IEnumerator Apocalypse(CardSlot smallSlot, CardSlot longSlot)
        {

            yield return new WaitForSeconds(0.7f);

            // Exposit story of the Black Forest
            if (!PersistentValues.HasSeenApocalypse)
            {
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Let me tell you a story. The story of the [c:bR]Black Forest[c:].");
            }

            AudioController.Instance.SetLoopVolume(0.5f * (Singleton<GameFlowManager>.Instance as Part1GameFlowManager).GameTableLoopVolume, 0.5f);
            AudioController.Instance.SetLoopAndPlay("red_noise", 1);
            AudioController.Instance.SetLoopVolumeImmediate(0.3f, 1);

            if (!PersistentValues.HasSeenApocalypse)
            {
                yield return new WaitForSeconds(0.4f);
                Singleton<ViewManager>.Instance.SwitchToView(View.Default, false, true);
                yield return new WaitForSeconds(0.5f);

                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Once upon a time, [c:bR]three birds[c:] lived happily in the lush Forest with their fellow animals.");
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("One day a stranger arrived at the Forest. He proclaimed that the Forest would soon be ensared in a bitter conflict.");
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("One that would only end when everything was devoured by a [c:bR]terrible Beast[c:].");
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The birds, frightened by this doomsay, sought to prevent conflict from ever breaking out.");
                
                // Look down at the board
                Singleton<ViewManager>.Instance.SwitchToView(View.Board);
                yield return new WaitForSeconds(0.25f);

                smallSlot.Card.Anim.StrongNegationEffect();
                yield return new WaitForSeconds(0.4f);
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:bR]Small Bird[c:] punished wrongdoers with his beak.");
                longSlot.Card.Anim.StrongNegationEffect();
                yield return new WaitForSeconds(0.4f);
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("[c:bB]Long Bird[c:] weighed the sins of all creatures in the forest with his scales.");
                base.PlayableCard.Anim.StrongNegationEffect();
                yield return new WaitForSeconds(0.4f);
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("With his many eyes, [c:bG]Big Bird[c:] kept constant watch over the entire Forest.");
                
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Fights began to break out. More and more creatures left the Forest, no matter how hard the birds worked.");
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("They decided to combine their powers. This way, they could better protect their home. This way, they could better return the peace.");
            }

            Singleton<ViewManager>.Instance.SwitchToView(View.Default);
            yield return new WaitForSeconds(0.2f);
            // Remove cards
            RemoveCard(smallSlot.Card);
            yield return new WaitForSeconds(0.2f);
            RemoveCard(longSlot.Card);
            yield return new WaitForSeconds(0.2f);
            RemoveCard(base.PlayableCard);
            yield return new WaitForSeconds(0.5f);

            yield return TableEffects();

            // More text
            if (!PersistentValues.HasSeenApocalypse)
            {
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Darkness fell upon the forest. Mayhem ran amok as creatures screamed in terror at the towering bird.");
            }

            // Give player Apocalypse in their deck and their hand
            Singleton<ViewManager>.Instance.SwitchToView(View.Hand);

            CardInfo info = CardLoader.GetCardByName("wstl_apocalypseBird");
            RunState.Run.playerDeck.AddCard(info);
            
            // set cost to 0 for this fight (can play immediately that way)
            info.cost = 0;
            yield return Singleton<CardSpawner>.Instance.SpawnCardToHand(info, null, 0.25f, null);
            PersistentValues.HasApocalypse = true;
            yield return new WaitForSeconds(0.2f);

            // Li'l text blurb
            yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("Someone yelled out 'It's [c:bR]the Beast[c:]! A big, scary monster lives in the Black Forest!'");

            yield return new WaitForSeconds(0.2f);
            Singleton<ViewManager>.Instance.SwitchToView(View.Default);
            yield return new WaitForSeconds(0.15f);
            if (!PersistentValues.HasSeenApocalypse)
            {
                PersistentValues.HasSeenApocalypse = true;
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("The three birds, [c:bR]now one[c:] looked around for [c:bR]the Beast[c:]. But there was nothing.");
                yield return Singleton<TextDisplayer>.Instance.ShowUntilInput("No creatures. No beast. No sun or moon or stars. Only a single bird, alone in an empty forest. ");
                yield return new WaitForSeconds(0.15f);
            }
            Singleton<ViewManager>.Instance.Controller.LockState = ViewLockState.Unlocked;
        }
        private void RemoveCard(PlayableCard item)
        {
            RunState.Run.playerDeck.RemoveCard(item.Info);
            item.UnassignFromSlot();
            SpecialCardBehaviour[] components = item.GetComponents<SpecialCardBehaviour>();
            for (int i = 0; i < components.Length; i++)
            {
                components[i].OnCleanUp();
            }
            item.ExitBoard(0.3f, Vector3.zero);
        }
        private IEnumerator TableEffects()
        {
            PersistentValues.HasSeenApocalypseEffects = true;

            yield return new WaitForSeconds(0.166f);
            Singleton<TableVisualEffectsManager>.Instance.ThumpTable(0.1f);
            yield return new WaitForSeconds(0.166f);
            Singleton<TableVisualEffectsManager>.Instance.ThumpTable(0.1f);
            yield return new WaitForSeconds(1.418f);

            Color glowRed = GameColors.Instance.glowRed;
            Color darkRed = GameColors.Instance.darkRed;
            darkRed.a = 0.5f;
            Color gray = GameColors.Instance.gray;
            gray.a = 0.5f;

            Singleton<TableVisualEffectsManager>.Instance.ChangeTableColors(GameColors.Instance.nearBlack, GameColors.Instance.gray, GameColors.Instance.gray, darkRed, darkRed, glowRed, glowRed, glowRed, glowRed);

            AudioController.Instance.StopLoop(1);
            AudioController.Instance.SetLoopVolume((Singleton<GameFlowManager>.Instance as Part1GameFlowManager).GameTableLoopVolume, 0.25f);
        }
    }
}