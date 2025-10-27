using System;
using System.Reflection;
using UnityEngine;

public class ReflectionInjector
{
    public static void Inject()
    {
        try
        {
            // Tìm MonoBehaviour trong scene
            var behaviours = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();
            foreach (var behaviour in behaviours)
            {
                if (behaviour.name.Contains("Game") || behaviour.name.Contains("Main"))
                {
                    // Inject AntiCheat vào GameObject này
                    var ac = behaviour.gameObject.AddComponent<AntiCheat>();
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("ReflectionInjector Error: " + ex.Message);
        }
    }
}