using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WBFunnyMod.Projectiles;
using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Weapons.Misc
{

    public class Chnilsson : ModItem
    {
        public override void SetDefaults()
        {
			Item.shootSpeed = 10f;
			Item.damage = 50000;
			Item.knockBack = 5f;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 999;
            Item.rare = ItemRarityID.Expert;

			Item.consumable = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.autoReuse = true;
			Item.DamageType = DamageClass.Throwing;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 5);
			Item.shoot = ModContent.ProjectileType<ChnilssonProjectile>();
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