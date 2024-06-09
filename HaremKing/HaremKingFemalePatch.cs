using System.Collections.Generic;
using HarmonyLib;
using TaleWorlds.CampaignSystem;

namespace HaremKing.Patches
{
    [HarmonyPatch(typeof(CharacterObject), "IsFemale", MethodType.Getter)]
    internal class HaremKingFemalePatch
    {
        static bool Prefix(ref bool __result, CharacterObject __instance)
        {
            Occupation occupation = __instance.Occupation;
            bool IsPlayerCharacter = __instance.IsPlayerCharacter;

            List<Occupation> femaleOccupations = new List<Occupation>()
            {
                Occupation.Mercenary,
                Occupation.Soldier,
                Occupation.Bandit
            };
            if (IsPlayerCharacter || !femaleOccupations.Contains(occupation))
            {
                return true;
            }

            __result = true;
            return false;
        }
    }
}
