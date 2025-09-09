using UnityEngine;

public static class SMIEntry
{
	// SharpMonoInjector: set Target Method to SMIEntry.Load (or LoadWithArg)
	public static void Load()
	{
		TryStart(null);
	}

	public static void LoadWithArg(string arg)
	{
		TryStart(arg);
	}

	public static void Unload()
	{
		try
		{
			var existing = Object.FindObjectOfType<AntiCheat>();
			if (existing != null)
			{
				Object.Destroy(existing.gameObject);
			}
		}
		catch { }
	}

	private static void TryStart(string arg)
	{
		try
		{
			if (Object.FindObjectOfType<AntiCheat>() != null)
			{
				return;
			}
			var go = new GameObject("AntiCheat");
			var ac = go.AddComponent<AntiCheat>();
			Object.DontDestroyOnLoad(go);
			if (!string.IsNullOrEmpty(arg) && arg.Equals("nolog", System.StringComparison.OrdinalIgnoreCase))
			{
				ac.logDetectionsToConsole = false;
			}
		}
		catch { }
	}
}

