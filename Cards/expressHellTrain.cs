using InscryptionAPI;
using InscryptionAPI.Card;
using DiskCardGame;
using System.Collections.Generic;
using WhistleWindLobotomyMod.Properties;

namespace WhistleWindLobotomyMod
{
    public partial class WstlPlugin
    {
        private void ExpressHellTrain_T0986()
        {
            List<Ability> abilities = new()
            {
                TheTrain.ability
            };
            List<Trait> traits = new()
            {
                Trait.DeathcardCreationNonOption
            };

            CardHelper.CreateCard(
                "wstl_expressHellTrain", "Express Train to Hell",
                "When the time comes, the train will sound its mighty horn.",
                0, 1, 0, 0,
                Resources.expressHellTrain, Resources.expressHellTrain_emission,
                abilities: abilities, specialAbilities: new(),
                metaCategories: new(), tribes: new(), traits: traits,
                isTerrain: true, isRare: true, onePerDeck: true, riskLevel: 4);
        }
    }
}