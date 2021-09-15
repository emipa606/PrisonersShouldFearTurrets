using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersShouldFearTurrets
{
    [HarmonyPatch(typeof(Building_TurretGun), "IsValidTarget")]
    public class Building_TurretGun_IsValidTarget
    {
        [HarmonyPostfix]
        public static void Postfix(Thing t, ref bool __result)
        {
            if (__result)
            {
                return;
            }

            if (t is not Pawn p)
            {
                return;
            }

            if (PrisonersShouldFearTurretsMod.instance.Settings.AppliesForPrisoners && p.IsPrisonerOfColony)
            {
                __result = PrisonBreakUtility.IsPrisonBreaking(p);
                return;
            }

            if (PrisonersShouldFearTurretsMod.instance.Settings.AppliesForSlaves && p.IsSlaveOfColony)
            {
                __result = SlaveRebellionUtility.IsRebelling(p);
            }
        }
    }
}