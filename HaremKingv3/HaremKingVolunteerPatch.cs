using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameComponents;
using TaleWorlds.Library;
using TaleWorlds.ObjectSystem;

namespace HaremKingv3
{
    [HarmonyPatch(typeof(DefaultVolunteerModel), "GetBasicVolunteer")]
    internal class HaremKingVolunteerPatch
    {
        static bool Prefix(Hero sellerHero, ref CharacterObject __result, DefaultVolunteerModel __instance)
        {
            InformationManager.DisplayMessage(new InformationMessage("GetBasicVolunteer"));
            if (sellerHero.IsRuralNotable && sellerHero.CurrentSettlement.Village.Bound.IsCastle)
            {
                __result = sellerHero.Culture.EliteBasicTroop;
                return false;
            }

            MBReadOnlyList<CharacterObject> characterList = MBObjectManager.Instance.GetObjectTypeList<CharacterObject>();
            IEnumerable<CharacterObject> character = characterList.Where(e => e.StringId.Equals("hrmk_aserai_recruit"));
            if (character.Count() != 1)
            {
                InformationManager.DisplayMessage(new InformationMessage("Not Found!" + character.Count()));
                return true;
            }
            
            Random random = new Random();
            int rand = random.Next(0, 101);
            if (rand < 50)
            {
                foreach (var c in character)
                {
                    __result = c;
                }
            }
            else
            {
                __result = sellerHero.Culture.BasicTroop;
            }
            
            return false;
        }
    }
}
