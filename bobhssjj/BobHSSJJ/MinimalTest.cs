using UnityEngine;

public class MinimalTest
{
    public static void Load()
    {
        try
        {
            var go = new GameObject("Test");
            UnityEngine.Object.DontDestroyOnLoad(go);
        }
        catch { }
    }
}