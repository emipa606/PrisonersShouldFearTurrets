using Mlie;
using UnityEngine;
using Verse;

namespace PrisonersShouldFearTurrets
{
    [StaticConstructorOnStartup]
    internal class PrisonersShouldFearTurretsMod : Mod
    {
        /// <summary>
        ///     The instance of the settings to be read by the mod
        /// </summary>
        public static PrisonersShouldFearTurretsMod instance;

        private static string currentVersion;


        /// <summary>
        ///     The private settings
        /// </summary>
        private PrisonersShouldFearTurretsModSettings settings;

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="content"></param>
        public PrisonersShouldFearTurretsMod(ModContentPack content)
            : base(content)
        {
            instance = this;

            currentVersion =
                VersionFromManifest.GetVersionFromModMetaData(
                    ModLister.GetActiveModWithIdentifier("Mlie.PrisonersShouldFearTurrets"));
        }

        /// <summary>
        ///     The instance-settings for the mod
        /// </summary>
        internal PrisonersShouldFearTurretsModSettings Settings
        {
            get
            {
                if (settings == null)
                {
                    settings = GetSettings<PrisonersShouldFearTurretsModSettings>();
                }

                return settings;
            }

            set => settings = value;
        }

        public override string SettingsCategory()
        {
            return "Prisoners Should Fear Turrets";
        }

        /// <summary>
        ///     The settings-window
        /// </summary>
        /// <param name="rect"></param>
        public override void DoSettingsWindowContents(Rect rect)
        {
            base.DoSettingsWindowContents(rect);

            var listing_Standard = new Listing_Standard();
            listing_Standard.Begin(rect);
            listing_Standard.CheckboxLabeled("PSFT.logging.label".Translate(), ref Settings.VerboseLogging,
                "PSFT.logging.tooltip".Translate());
            if (currentVersion != null)
            {
                listing_Standard.Gap();
                GUI.contentColor = Color.gray;
                listing_Standard.Label("PSFT.version.label".Translate(currentVersion));
                GUI.contentColor = Color.white;
            }

            listing_Standard.Gap();
            listing_Standard.CheckboxLabeled("PSFT.forprisoners.label".Translate(), ref Settings.AppliesForPrisoners);
            listing_Standard.CheckboxLabeled("PSFT.forslaves.label".Translate(), ref Settings.AppliesForSlaves);
            if (!Settings.AppliesForSlaves && !Settings.AppliesForPrisoners)
            {
                listing_Standard.Label("PSFT.nothing.label".Translate());
            }

            if (ModLister.IdeologyInstalled)
            {
                listing_Standard.CheckboxLabeled("PSFT.applyterror.label".Translate(), ref Settings.ApplyTerror);
            }

            listing_Standard.End();
        }
    }
}