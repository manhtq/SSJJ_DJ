using System;
using System.Reflection;
using UnityEngine;

public class AssemblyPatcher
{
    public static void Patch()
    {
        try
        {
            // Tìm class chính của game
            var gameClass = FindGameClass();
            if (gameClass != null)
            {
                // Hook vào method Start hoặc Awake
                var startMethod = gameClass.GetMethod("Start");
                if (startMethod != null)
                {
                    // Tạo AntiCheat khi game start
                    CreateAntiCheat();
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("AssemblyPatcher Error: " + ex.Message);
        }
    }
    
    private static Type FindGameClass()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (var asm in assemblies)
        {
            var types = asm.GetTypes();
            foreach (var type in types)
            {
                if (type.Name.Contains("Game") || type.Name.Contains("Main"))
                {
                    return type;
                }
            }
        }
        return null;
    }
    
    private static void CreateAntiCheat()
    {
        var go = new GameObject("AntiCheat");
        var ac = go.AddComponent<AntiCheat>();
        UnityEngine.Object.DontDestroyOnLoad(go);
    }
}