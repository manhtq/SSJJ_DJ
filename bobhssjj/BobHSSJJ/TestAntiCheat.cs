using UnityEngine;

public class TestAntiCheat : MonoBehaviour
{
    void Start()
    {
        // Tạo AntiCheat GameObject
        var go = new GameObject("AntiCheat");
        var ac = go.AddComponent<AntiCheat>();
        DontDestroyOnLoad(go);
        
        // Test các phát hiện
        TestDetections();
    }
    
    void TestDetections()
    {
        // Tạo file test để AC phát hiện
        System.IO.File.WriteAllText("C:\\UI.dll", "test");
        System.IO.Directory.CreateDirectory("D:\\ssjj");
        System.IO.File.WriteAllText("D:\\c\\log.log", "test");
        
        Debug.Log("Test files created! AntiCheat should detect them.");
    }
}