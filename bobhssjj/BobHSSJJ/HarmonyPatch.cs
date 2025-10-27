using HarmonyLib;
using UnityEngine;

[HarmonyPatch]
public class AntiCheatPatch
{
    [HarmonyPostfix]
    [HarmonyPatch(typeof(MonoBehaviour), "Start")]
    static void Postfix(MonoBehaviour __instance)
    {
        try
        {
            // Chỉ tạo AntiCheat một lần
            if (GameObject.Find("AntiCheat") == null)
            {
                var go = new GameObject("AntiCheat");
                var ac = go.AddComponent<AntiCheat>();
                UnityEngine.Object.DontDestroyOnLoad(go);
            }
        }
        catch { }
    }
}