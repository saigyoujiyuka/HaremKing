using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;

namespace HaremKingv3.Patches
{
    [HarmonyPatch(typeof(CharacterObject), "get_IsFemale")]
    internal class HaremKingFemalePatch
    {
        static bool Prefix(ref bool __result, CharacterObject __instance)
        {
            MethodInfo OccupationMethod = AccessTools.Method(typeof(CharacterObject), "get_Occupation");
            Occupation occupation = (Occupation)OccupationMethod.Invoke(__instance, new Object[] { });
            
            MethodInfo IsPlayerCharacterMethod = AccessTools.Method(typeof(CharacterObject), "get_IsPlayerCharacter");
            bool IsPlayerCharacter = (bool)IsPlayerCharacterMethod.Invoke(__instance, new Object[] { });

            List<Occupation> excludedOccupations = new List<Occupation>()
            {
                Occupation.NotAssigned,
                Occupation.Lord,
                Occupation.Special,
                Occupation.NumberOfOccupations,
            };
            if (IsPlayerCharacter || excludedOccupations.Contains(occupation))
            {
                //InformationManager.DisplayMessage(new InformationMessage("Exclude: " + occupation.ToString()));
                return true;
            }

            //InformationManager.DisplayMessage(new InformationMessage("To female: " + occupation.ToString()));
            __result = true;
            return false;
        }
    }
}
