// SimpleTimeScaleMod.cs
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(SimpleTimeScaleMod), "SimpleTimeScaleMod", "1.1.0", "YourName")]
[assembly: MelonGame("New Folder Games", "I Am Cat")]

public class SimpleTimeScaleMod : MelonMod
{
    // Preference entry for time scale multiplier
    private static MelonPreferences_Entry<float> timeScaleEntry;

    // Called once when MelonLoader finishes initializing
    public override void OnInitializeMelon()
    {
        // Create (or load) a config entry:
        // section: "SimpleTimeScaleMod", key: "TimeScaleMultiplier", default: 2.0f
        timeScaleEntry = MelonPreferences.CreateEntry(
            "SimpleTimeScaleMod",            // category name
            "TimeScaleMultiplier",           // entry key
            2.0f,                            // default value
            "Global time scale multiplier (e.g. 0.5 = half speed, 2 = double speed)"  // description
        );

        // Ensure the .cfg file is written
        MelonPreferences.Save();

        MelonLogger.Msg($"[SimpleTimeScaleMod] Loaded config: TimeScaleMultiplier = {timeScaleEntry.Value}");
    }

    // Called every frame
    public override void OnUpdate()
    {
        // Read the current multiplier from config
        float scale = timeScaleEntry.Value;

        // Apply to Unity’s time scale
        Time.timeScale = scale;

        // Sync physics update rate
        Time.fixedDeltaTime = 0.02f * scale;
    }
}
