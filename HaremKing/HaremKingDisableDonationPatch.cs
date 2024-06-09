using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CampaignBehaviors;
using TaleWorlds.CampaignSystem.Party;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.CampaignSystem.ViewModelCollection.CharacterDeveloper;
using TaleWorlds.Library;

namespace HaremKing
{
    [HarmonyPatch(typeof(GarrisonTroopsCampaignBehavior), "OnSettlementEntered")]
    internal class HaremKingDisableDonationPatch
    {
        static bool Prefix(MobileParty mobileParty, Settlement settlement, Hero hero)
        {
            if (!Campaign.Current.GameStarted)
            {
                return true;
            }
            if (mobileParty != null && mobileParty.IsLordParty && !mobileParty.IsDisbanding && mobileParty.LeaderHero != null
                && mobileParty.LeaderHero.Clan == Clan.PlayerClan)
            {
                // InformationManager.DisplayMessage(new InformationMessage("Disable donation!"));
                return false;
            }
            return true;
        }
    }
}
