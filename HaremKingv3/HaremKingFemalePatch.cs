using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace HaremKingv3.Patches
{
    [HarmonyPatch(typeof(CharacterObject), "IsFemale", MethodType.Getter)]
    internal class HaremKingFemalePatch
    {
        static bool Prefix(ref bool __result, CharacterObject __instance)
        {
            Occupation occupation = __instance.Occupation;
            bool IsPlayerCharacter = __instance.IsPlayerCharacter;

            List<Occupation> excludedOccupations = new List<Occupation>()
            {
                Occupation.NotAssigned,
                Occupation.Lord,
                Occupation.Special,
                Occupation.NumberOfOccupations,
            };
            if (IsPlayerCharacter || excludedOccupations.Contains(occupation))
            {
                return true;
            }

            __result = true;
            return false;
        }
    }
}
