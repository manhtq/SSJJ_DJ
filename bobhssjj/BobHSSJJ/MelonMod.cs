using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(AntiCheatMod), "AntiCheat", "1.0.0", "YourName")]
[assembly: MelonGame("GameStudio", "GameName")]

public class AntiCheatMod : MelonMod
{
    public override void OnInitializeMelon()
    {
        MelonLogger.Msg("AntiCheat Mod Starting...");
        
        var go = new GameObject("AntiCheat");
        var ac = go.AddComponent<AntiCheat>();
        Object.DontDestroyOnLoad(go);
        
        MelonLogger.Msg("AntiCheat Mod Loaded!");
    }
}