using Terraria.ModLoader;

namespace WBFunnyMod
{
	public class WBFunnyMod : Mod
	{

		public static WBFunnyMod Instance;

		public WBFunnyMod()
		{

			Instance = this;

			Properties = new ModProperties()
			{

				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true

			};

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