using System;
using System.IO;
using System.Reflection;

namespace Launcher
{
	class Program
	{
		static int Main(string[] args)
		{
			try
			{
				string baseDir = AppDomain.CurrentDomain.BaseDirectory;
				string dllPath = args.Length > 0 ? args[0] : Path.Combine(baseDir, "BobHSSJJ.dll");
				if (!File.Exists(dllPath))
				{
					Console.Error.WriteLine("Missing BobHSSJJ.dll at: " + dllPath);
					return 2;
				}
				Assembly asm = Assembly.LoadFrom(dllPath);
				Type loaderType = asm.GetType("Veh.Loader");
				if (loaderType == null)
				{
					Console.Error.WriteLine("Veh.Loader type not found in BobHSSJJ.dll");
					return 3;
				}
				MethodInfo method = loaderType.GetMethod("newload", BindingFlags.Public | BindingFlags.Static);
				if (method == null)
				{
					method = loaderType.GetMethod("Load", BindingFlags.Public | BindingFlags.Static);
				}
				if (method == null)
				{
					Console.Error.WriteLine("No suitable entry (newload/Load) found on Veh.Loader");
					return 4;
				}
				method.Invoke(null, null);
				Console.WriteLine("BobHSSJJ loaded. Press Enter to exit.");
				Console.ReadLine();
				return 0;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex.ToString());
				return 1;
			}
		}
	}
}

