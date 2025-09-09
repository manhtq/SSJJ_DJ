using UnityEngine;
using System.IO;

public static class Entry
{
    public static void Start()
    {
        try
        {
            // Tạo log file
            string logPath = Path.Combine(Application.dataPath, "..", "AntiCheat.log");
            File.WriteAllText(logPath, "AntiCheat Entry.Start() called!\n");
            
            var go = new GameObject("AntiCheat");
            var ac = go.AddComponent<AntiCheat>();
            UnityEngine.Object.DontDestroyOnLoad(go);
            
            File.AppendAllText(logPath, "AntiCheat GameObject created!\n");
        }
        catch (System.Exception ex)
        {
            // Ghi lỗi ra file
            string logPath = Path.Combine(Application.dataPath, "..", "AntiCheat_Error.log");
            File.WriteAllText(logPath, "Error: " + ex.Message + "\n" + ex.StackTrace);
        }
    }
}