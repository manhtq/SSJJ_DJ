using UnityEngine;

public class TestEntry
{
    public static void Load()
    {
        try
        {
            if (UnityEngine.Object.FindObjectOfType<AntiCheat>() != null)
            {
                return;
            }
            var go = new GameObject("AntiCheat");
            var ac = go.AddComponent<AntiCheat>();
            UnityEngine.Object.DontDestroyOnLoad(go);
        }
        catch { }
    }

    public static void Unload()
    {
        try
        {
            var existing = UnityEngine.Object.FindObjectOfType<AntiCheat>();
            if (existing != null)
            {
                UnityEngine.Object.Destroy(existing.gameObject);
            }
        }
        catch { }
    }
}