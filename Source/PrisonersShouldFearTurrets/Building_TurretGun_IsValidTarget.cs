using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersShouldFearTurrets;

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

        Log.Message($"{p}: {p.mindState.mentalStateHandler.CurStateDef}");
        var appliesToPawn =
            PrisonersShouldFearTurretsMod.instance.Settings.AppliesForPrisoners && p.IsPrisonerOfColony ||
            PrisonersShouldFearTurretsMod.instance.Settings.AppliesForSlaves && p.IsSlaveOfColony;
        if (!appliesToPawn)
        {
            return;
        }

        if (PrisonBreakUtility.IsPrisonBreaking(p))
        {
            __result = true;
            return;
        }

        if (SlaveRebellionUtility.IsRebelling(p))
        {
            __result = true;
            return;
        }

        if (PrisonersShouldFearTurretsMod.instance.Settings.AppliesForAggro && p.InAggroMentalState)
        {
            __result = true;
        }
    }
}