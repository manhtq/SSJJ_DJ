using UnityEngine;

public static class Entry
{
    public static void Start()
    {
        try
        {
            var go = new GameObject("AntiCheat");
            var ac = go.AddComponent<AntiCheat>();
            UnityEngine.Object.DontDestroyOnLoad(go);
        }
        catch { }
    }
}