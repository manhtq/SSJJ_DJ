using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Diagnostics;
using UnityEngine;

public partial class AntiCheat : MonoBehaviour
{
	public float checkIntervalSeconds = 2.0f;
	public bool logDetectionsToConsole = true;
	public Action<string> OnCheatDetected;

	private float _nextCheckAt;
	private readonly HashSet<string> _onceFlags = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		_nextCheckAt = Time.realtimeSinceStartup + UnityEngine.Random.Range(0.25f, 1.0f);
	}

	void Update()
	{
		if (Time.realtimeSinceStartup >= _nextCheckAt)
		{
			PerformChecks();
			_nextCheckAt = Time.realtimeSinceStartup + Mathf.Max(0.25f, checkIntervalSeconds);
		}
	}

	private void PerformChecks()
	{
		try
		{
			CheckLoadedAssemblies();
			CheckKnownArtifacts();
			CheckNamedPipe();
			CheckDetourPresence();
		}
		catch (Exception)
		{
			// Swallow to avoid impacting game loop; optionally report internally.
		}
	}

	private void CheckLoadedAssemblies()
	{
		var loaded = AppDomain.CurrentDomain.GetAssemblies();
		foreach (var asm in loaded)
		{
			string name = SafeGetName(asm);
			if (string.IsNullOrEmpty(name)) continue;

			// Signatures from the analyzed cheat
			if (name.IndexOf("BobHSSJJ", StringComparison.OrdinalIgnoreCase) >= 0)
				FlagOnce("asm:BobHSSJJ", "Loaded suspicious assembly: " + name);
			if (name.IndexOf("MonoMod.RuntimeDetour", StringComparison.OrdinalIgnoreCase) >= 0)
				FlagOnce("asm:RuntimeDetour", "Detour framework present: " + name);
			if (name.IndexOf("Mono.Cecil", StringComparison.OrdinalIgnoreCase) >= 0)
				FlagOnce("asm:Mono.Cecil", "IL tooling present: " + name);
		}
	}

	private void CheckKnownArtifacts()
	{
		// Hard-coded artifacts used by the cheat
		TryFlagFile("C:\\UI.dll", "Found injected UI DLL at C:\\UI.dll");
		TryFlagDirectory("D:\\ssjj", "Found cheat log directory D:\\ssjj");
		TryFlagFile("D:\\c\\log.log", "Found cheat log file D:\\c\\log.log");
	}

	private void CheckNamedPipe()
	{
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
		const string pipeName = "A9CC91EDA92B";
		ThreadPool.QueueUserWorkItem(_ =>
		{
			try
			{
				string fullName = "\\\\.\\pipe\\" + pipeName;
				if (WaitNamedPipe(fullName, 1))
				{
					FlagOnce("pipe:" + pipeName, "Named pipe server detected: " + pipeName);
				}
			}
			catch { }
		});
#endif
	}

	private void CheckDetourPresence()
	{
		try
		{
			var runtimeDetour = AppDomain.CurrentDomain.GetAssemblies()
				.FirstOrDefault(a => SafeGetName(a).IndexOf("MonoMod.RuntimeDetour", StringComparison.OrdinalIgnoreCase) >= 0);
			if (runtimeDetour != null)
			{
				var hookType = runtimeDetour.GetType("MonoMod.RuntimeDetour.Hook");
				if (hookType != null)
				{
					FlagOnce("type:Hook", "RuntimeDetour Hook type available");
				}
			}
		}
		catch { }
	}

	private void TryFlagFile(string path, string message)
	{
		try
		{
			if (File.Exists(path))
			{
				FlagOnce("file:" + path, message);
			}
		}
		catch { }
	}

	private void TryFlagDirectory(string path, string message)
	{
		try
		{
			if (Directory.Exists(path))
			{
				FlagOnce("dir:" + path, message);
			}
		}
		catch { }
	}

	private void FlagOnce(string key, string message)
	{
		if (_onceFlags.Add(key))
		{
			if (logDetectionsToConsole)
			{
				UnityEngine.Debug.LogWarning("[AntiCheat] " + message);
			}
			try { OnCheatDetected?.Invoke(message); } catch { }
			TerminateNow();
		}
	}

	private void TerminateNow()
	{
		try { Application.Quit(); } catch { }
		try { Process.GetCurrentProcess()?.Kill(); } catch { }
		try { Environment.Exit(0); } catch { }
	}

	private static string SafeGetName(Assembly asm)
	{
		try { return asm.GetName().Name ?? string.Empty; } catch { return string.Empty; }
	}
}

public static class AntiCheatBootstrap
{
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void Init()
	{
		try
		{
			var go = new GameObject("AntiCheat");
			var ac = go.AddComponent<AntiCheat>();
			ac.OnCheatDetected += msg => { UnityEngine.Debug.LogWarning("[AntiCheat] Detected: " + msg); };
		}
		catch { }
	}
}

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
internal static class NativePipes
{
}

public partial class AntiCheat
{
	private const uint NMPWAIT_NOWAIT = 0x00000001;

	[System.Runtime.InteropServices.DllImport("kernel32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
	private static extern bool WaitNamedPipe(string lpNamedPipeName, uint nTimeOut);
}
#endif