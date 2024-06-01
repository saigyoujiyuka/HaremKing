using HarmonyLib;
using TaleWorlds.CampaignSystem.GameComponents;

namespace HaremKing
{
    [HarmonyPatch(typeof(DefaultClanTierModel), "GetCompanionLimitFromTier")]
    internal class HaremKingCompanionLimitPatch
    {
        public static void Postfix(ref int __result)
        {
            __result *= 3;
            return;
        }
    }
}
