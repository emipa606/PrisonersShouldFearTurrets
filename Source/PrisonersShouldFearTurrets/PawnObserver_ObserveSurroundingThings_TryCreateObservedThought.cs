using System;
using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;

namespace PrisonersShouldFearTurrets
{
    [HarmonyPatch(typeof(PawnObserver), "<ObserveSurroundingThings>g__TryCreateObservedThought|7_0")]
    public class PawnObserver_ObserveSurroundingThings_TryCreateObservedThought
    {
        [HarmonyPostfix]
        public static void Postfix(Thing thing, Pawn ___pawn,
            ref List<Thought_MemoryObservationTerror> ___terrorThoughts)
        {
            if (!PrisonersShouldFearTurretsMod.instance.Settings.ApplyTerror)
            {
                return;
            }

            if (thing is not Building_TurretGun turret)
            {
                return;
            }

            if (turret.Faction != Faction.OfPlayerSilentFail || !turret.Active)
            {
                return;
            }

            if (!ModLister.IdeologyInstalled)
            {
                return;
            }

            if (!___pawn.IsSlaveOfColony)
            {
                return;
            }

            var thoughtMemory =
                (Thought_MemoryObservation)ThoughtMaker.MakeThought(PrisonersShouldFearTurrets.ObservedTurretDef);
            thoughtMemory.Target = thing;
            var thought = (Thought_MemoryObservationTerror)ThoughtMaker.MakeThought(ThoughtDefOf.ObservedTerror);
            thought.Target = thing;
            thought.intensity = (int)Math.Round(Math.Min(turret.MarketValue / 25, 50), 0);
            ___terrorThoughts.Add(thought);
            ___pawn.needs.mood.thoughts.memories.TryGainMemory(thoughtMemory);
        }
    }
}