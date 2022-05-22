using Terraria.ID;
using Terraria.ModLoader;

namespace WBFunnyMod.Items
{
	public class MorbiusSword : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("morbius movie");
			Tooltip.SetDefault("swing the morbius sword call that a morbius sweep");
		}

		public override void SetDefaults() 
		{
			item.damage = 14;
			item.melee = true;
			item.width = 1600;
			item.height = 1600;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 10;
			item.value = 10000;
			item.rare = -12;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}