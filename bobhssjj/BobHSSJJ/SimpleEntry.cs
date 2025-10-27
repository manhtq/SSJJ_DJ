using UnityEngine;
using System.IO;

public static class SimpleEntry
{
    public static void Load()
    {
        try
        {
            // Tạo file log đơn giản
            File.WriteAllText("C:\\AntiCheat_Loaded.txt", "AntiCheat loaded at: " + System.DateTime.Now);
            
            var go = new GameObject("AntiCheat");
            var ac = go.AddComponent<AntiCheat>();
            UnityEngine.Object.DontDestroyOnLoad(go);
            
            File.AppendAllText("C:\\AntiCheat_Loaded.txt", "\nGameObject created successfully!");
        }
        catch (System.Exception ex)
        {
            File.WriteAllText("C:\\AntiCheat_Error.txt", ex.ToString());
        }
    }
}