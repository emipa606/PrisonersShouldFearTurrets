using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersShouldFearTurrets;

[HarmonyPatch]
public class Building_TurretGun_IsValidTarget
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(typeof(Building_TurretGun), "IsValidTarget");
        if (ModLister.GetActiveModWithIdentifier("CETeam.CombatExtended") != null)
        {
            yield return AccessTools.Method("CombatExtended.Building_TurretGunCE:IsValidTarget");
        }
    }

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

        PrisonersShouldFearTurrets.LogMessage($"{p}: {p.mindState.mentalStateHandler.CurStateDef}");

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