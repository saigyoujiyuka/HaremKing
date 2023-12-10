using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.Library;
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
            new Harmony("HaremKingv3").PatchAll();
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
        }
    }
}
