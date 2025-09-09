using BepInEx;
using UnityEngine;

[BepInPlugin("com.anticheat", "AntiCheat", "1.0.0")]
public class AntiCheatPlugin : BaseUnityPlugin
{
    void Awake()
    {
        Logger.LogInfo("AntiCheat Plugin Starting...");
        
        // Tạo AntiCheat GameObject
        var go = new GameObject("AntiCheat");
        var ac = go.AddComponent<AntiCheat>();
        DontDestroyOnLoad(go);
        
        Logger.LogInfo("AntiCheat Plugin Loaded!");
    }
}