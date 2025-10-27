using System;
using System.IO;

class ConsoleTest
{
    static void Main()
    {
        Console.WriteLine("Testing AntiCheat detection...");
        
        // Tạo các file test
        try
        {
            File.WriteAllText("C:\\UI.dll", "test");
            Console.WriteLine("Created C:\\UI.dll");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating C:\\UI.dll: " + ex.Message);
        }
        
        try
        {
            Directory.CreateDirectory("D:\\ssjj");
            Console.WriteLine("Created D:\\ssjj directory");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating D:\\ssjj: " + ex.Message);
        }
        
        try
        {
            Directory.CreateDirectory("D:\\c");
            File.WriteAllText("D:\\c\\log.log", "test");
            Console.WriteLine("Created D:\\c\\log.log");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error creating D:\\c\\log.log: " + ex.Message);
        }
        
        Console.WriteLine("Test files created! Check if AntiCheat detects them.");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}