using System.Reflection;
using HarmonyLib;
using Verse;

namespace PrisonersShouldFearTurrets
{
    [StaticConstructorOnStartup]
    public class PrisonersShouldFearTurrets
    {
        static PrisonersShouldFearTurrets()
        {
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
}