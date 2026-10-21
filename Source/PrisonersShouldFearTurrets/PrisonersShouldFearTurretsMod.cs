using Mlie;
using UnityEngine;
using Verse;

namespace PrisonersShouldFearTurrets;

[StaticConstructorOnStartup]
internal class PrisonersShouldFearTurretsMod : Mod
{
    /// <summary>
    ///     The instance of the settings to be read by the mod
    /// </summary>
    public static PrisonersShouldFearTurretsMod Instance;

    private static string currentVersion;


    /// <summary>
    ///     Constructor
    /// </summary>
    /// <param name="content"></param>
    public PrisonersShouldFearTurretsMod(ModContentPack content)
        : base(content)
    {
        Instance = this;
        Settings = GetSettings<PrisonersShouldFearTurretsModSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(content.ModMetaData);
    }

    /// <summary>
    ///     The instance-settings for the mod
    /// </summary>
    internal PrisonersShouldFearTurretsModSettings Settings { get; }

    public override string SettingsCategory()
    {
        return "Prisoners Should Fear Turrets";
    }

    /// <summary>
    ///     The settings-window
    /// </summary>
    /// <param name="inRect"></param>
    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);

        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.CheckboxLabeled("PSFT.logging.label".Translate(), ref Settings.VerboseLogging,
            "PSFT.logging.tooltip".Translate());
        if (currentVersion != null)
        {
            listingStandard.Gap();
            GUI.contentColor = Color.gray;
            listingStandard.Label("PSFT.version.label".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.Gap();
        listingStandard.CheckboxLabeled("PSFT.forprisoners.label".Translate(), ref Settings.AppliesForPrisoners);
        listingStandard.CheckboxLabeled("PSFT.forslaves.label".Translate(), ref Settings.AppliesForSlaves);
        listingStandard.Gap();
        if (!Settings.AppliesForSlaves && !Settings.AppliesForPrisoners)
        {
            listingStandard.Label("PSFT.nothing.label".Translate());
        }
        else
        {
            listingStandard.CheckboxLabeled("PSFT.foraggro.label".Translate(), ref Settings.AppliesForAggro);
            if (ModLister.IdeologyInstalled)
            {
                listingStandard.CheckboxLabeled("PSFT.applyterror.label".Translate(), ref Settings.ApplyTerror);
            }
        }

        listingStandard.End();
    }
}