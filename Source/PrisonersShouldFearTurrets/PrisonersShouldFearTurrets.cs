using System.Reflection;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersShouldFearTurrets;

[StaticConstructorOnStartup]
public class PrisonersShouldFearTurrets
{
    public static readonly ThoughtDef ObservedTurretDef;

    static PrisonersShouldFearTurrets()
    {
        ObservedTurretDef = DefDatabase<ThoughtDef>.GetNamedSilentFail("ObservedTurret");
        var harmony = new Harmony("Mlie.PrisonersShouldFearTurrets");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }


    public static void LogMessage(string message, bool forced = false, bool warning = false)
    {
        if (warning)
        {
            Log.Warning($"[PrisonersShouldFearTurrets]: {message}");
            return;
        }

        if (!forced && !PrisonersShouldFearTurretsMod.instance.Settings.VerboseLogging)
        {
            return;
        }

        Log.Message($"[PrisonersShouldFearTurrets!]: {message}");
    }
}