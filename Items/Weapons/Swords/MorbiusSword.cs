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
			Item.Size = new Vector2(32,32);

			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.autoReuse = true;

			Item.damage = 8000;
			Item.knockBack = 3f;
			Item.crit = 4;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
			
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Expert;

			Item.shoot = ModContent.ProjectileType<MorbiusProjectile>();
			Item.shootSpeed = 5f;
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}