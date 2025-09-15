using System;

namespace Veh
{
	internal static class UITheme
	{
		static ImVec4 fallbackAccent = new ImVec4(0f, 1f, 0f, 1f);

		public static void EnsureDefaults(ref Veh.Hs.GUIConfig gui)
		{
			if (gui.Accent.x == 0f && gui.Accent.y == 0f && gui.Accent.z == 0f && gui.Accent.w == 0f)
			{
				gui.Accent = fallbackAccent;
			}
			if (string.IsNullOrEmpty(gui.Theme))
			{
				gui.Theme = "dark";
			}
		}

		public static ImVec4 ColorAccent()
		{
			if (Main.instance != null && Main.instance._menu_bar != null)
			{
				return Main.instance._menu_bar.guiconfig_0.Accent.w == 0f && Main.instance._menu_bar.guiconfig_0.Accent.x == 0f && Main.instance._menu_bar.guiconfig_0.Accent.y == 0f && Main.instance._menu_bar.guiconfig_0.Accent.z == 0f
					? fallbackAccent
					: Main.instance._menu_bar.guiconfig_0.Accent;
			}
			return fallbackAccent;
		}
	}
}

