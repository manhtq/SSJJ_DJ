using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("create-test-files")]
    public IActionResult CreateTestFiles()
    {
        try
        {
            // Tạo file test
            File.WriteAllText("C:\\UI.dll", "test");
            Directory.CreateDirectory("D:\\ssjj");
            File.WriteAllText("D:\\c\\log.log", "test");
            
            return Ok("Test files created successfully!");
        }
        catch (Exception ex)
        {
            return BadRequest("Error: " + ex.Message);
        }
    }
    
    [HttpGet("check-files")]
    public IActionResult CheckFiles()
    {
        var results = new
        {
            UI_DLL = File.Exists("C:\\UI.dll"),
            SSJJ_Dir = Directory.Exists("D:\\ssjj"),
            Log_File = File.Exists("D:\\c\\log.log")
        };
        
        return Ok(results);
    }
}