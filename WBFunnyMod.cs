using Terraria.ModLoader;

namespace WBFunnyMod
{
	public class WBFunnyMod : Mod
	{

		public static WBFunnyMod Instance;

		public WBFunnyMod()
		{

			Instance = this;

			ContentAutoloadingEnabled = true;
			GoreAutoloadingEnabled = true;
			MusicAutoloadingEnabled = true;
			BackgroundAutoloadingEnabled = true;

			// Properties/* tModPorter Note: Removed. Instead, assign the properties directly (ContentAutoloadingEnabled, GoreAutoloadingEnabled, MusicAutoloadingEnabled, and BackgroundAutoloadingEnabled) */ = new ModProperties()
			// {

			// 	Autoload = true,
			// 	AutoloadGores = true,
			// 	AutoloadSounds = true

			// };

		}

		public override void Load()
		{

			if (Instance == null || Instance != this)
			{

				Instance = this;

			}

		}

	}

}