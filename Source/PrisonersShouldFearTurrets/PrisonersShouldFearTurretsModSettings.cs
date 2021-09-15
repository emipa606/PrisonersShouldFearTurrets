using Verse;

namespace PrisonersShouldFearTurrets
{
    /// <summary>
    ///     Definition of the settings for the mod
    /// </summary>
    internal class PrisonersShouldFearTurretsModSettings : ModSettings
    {
        public bool AppliesForPrisoners = true;
        public bool AppliesForSlaves;
        public bool OwnDoor;
        public bool VerboseLogging;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref VerboseLogging, "VerboseLogging");
            Scribe_Values.Look(ref AppliesForPrisoners, "AppliesForPrisoners", true);
            Scribe_Values.Look(ref AppliesForSlaves, "AppliesForSlaves");
            Scribe_Values.Look(ref OwnDoor, "OwnDoor");
        }
    }
}