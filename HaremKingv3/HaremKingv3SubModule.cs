using System.Collections.Generic;
using System.Linq;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.LinQuick;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;

namespace HaremKingv3
{
    public class HaremKingv3SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            InformationManager.DisplayMessage(new InformationMessage("OnSubModuleLoad"));
            Module.CurrentModule.AddInitialStateOption(new InitialStateOption("Message",
                new TextObject("Message", null),
                9990,
                () => { InformationManager.DisplayMessage(new InformationMessage("Hello World!")); },
                () => { return (false, null); }
                )
            );
        }

        //protected override void OnApplicationTick(float dt)
        //{
        //    base.OnApplicationTick(dt);
        //}

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            InformationManager.DisplayMessage(new InformationMessage("OnGameStart"));
        }

        public override void OnGameInitializationFinished(Game game)
        {
            base.OnGameInitializationFinished(game);
            InformationManager.DisplayMessage(new InformationMessage("OnGameInitializationFinished"));

            List<CharacterObject> characterList = game.ObjectManager.GetObjectTypeList<CharacterObject>();
            InformationManager.DisplayMessage(new InformationMessage("Total: " + characterList.Count.ToString()));

            List<Occupation> excludedOccupations = new List<Occupation>() {
                Occupation.NotAssigned,
                Occupation.Lord,
                Occupation.Special,
                Occupation.NumberOfOccupations,
            };
            List<CharacterObject> femaleCharacterList = characterList.Where(item => !excludedOccupations.Contains(item.Occupation)).ToList();
            InformationManager.DisplayMessage(new InformationMessage("Female: " + femaleCharacterList.Count.ToString()));

            foreach (CharacterObject characterObject in femaleCharacterList)
            {
                if (!characterObject.IsHero)
                {
                    characterObject.IsFemale = true;
                }
                //if (targetOccupations.Contains(characterObject.Occupation))
                //{
                //    characterObject.IsFemale = true;
                //}
                //if (characterObject.HeroObject != null)
                //{
                //    characterObject.HeroObject.UpdatePlayerGender(true);
                //}
            }
        }
    }
}
