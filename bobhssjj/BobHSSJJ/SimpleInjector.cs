using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

class SimpleInjector
{
    [DllImport("kernel32.dll")]
    static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

    [DllImport("kernel32.dll")]
    static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32.dll")]
    static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);

    [DllImport("kernel32.dll")]
    static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

    public static void Inject(string processName, string dllPath)
    {
        var process = Process.GetProcessesByName(processName)[0];
        var hProcess = OpenProcess(0x1F0FFF, false, process.Id);
        
        var dllBytes = System.IO.File.ReadAllBytes(dllPath);
        var allocMem = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllBytes.Length, 0x1000, 0x40);
        
        WriteProcessMemory(hProcess, allocMem, dllBytes, (uint)dllBytes.Length, out _);
        
        var loadLibrary = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibrary, allocMem, 0, IntPtr.Zero);
    }
}