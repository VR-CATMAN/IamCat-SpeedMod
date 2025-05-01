// SimpleTimeScaleMod.cs
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(SimpleTimeScaleMod), "SimpleTimeScaleMod", "1.0.0", "YourName")]
[assembly: MelonGame("New Folder Games", "I Am Cat")]

public class SimpleTimeScaleMod : MelonMod
{
    public override void OnApplicationStart()
    {
        MelonLogger.Msg("SimpleTimeScaleMod loaded! Time.timeScale = 2");
    }

    public override void OnUpdate()
    {
        // ここを好きな倍率に変えれば OK
        Time.timeScale = 2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;  // 物理挙動の同期用
    }
}

































