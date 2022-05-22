using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using WBFunnyMod.Projectiles;
using WBFunnyMod.Items.Misc.CraftMaterials;
namespace WBFunnyMod.Items.Weapons.Swords
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
			item.Size = new Vector2(32,32);

			item.melee = true;
			item.autoReuse = true;

			item.damage = 2000;
			item.knockBack = 3f;
			item.crit = 4;

			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.UseSound = SoundID.Item1;
			
			item.value = Item.buyPrice(silver: 50);
			item.rare = ItemRarityID.Expert;

			item.shoot = ModContent.ProjectileType<MorbiusProjectile>();
			item.shootSpeed = 5f;
		}

		public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
	}
}