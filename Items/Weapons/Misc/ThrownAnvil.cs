using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using WBFunnyMod.Projectiles;
using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Weapons.Misc
{

    public class ThrownAnvil : ModItem
    {

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Throwing Anvil");
            Tooltip.SetDefault("weeeee... bonk");

        }

        public override void SetDefaults()
        {
            item.shootSpeed = 4f;
            item.damage = 20000;
            item.knockBack = 15f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useAnimation = 30;
            item.useTime = 30;
            item.Size = new Vector2(32,16);
            item.maxStack = 999;
            item.rare = ItemRarityID.Expert;

            item.consumable = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = false;
            item.thrown = true;

            item.UseSound = SoundID.Item1;
            item.value = Item.buyPrice(silver: 50);
            item.shoot = ModContent.ProjectileType<AnvilProjectile>();

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 5);
            recipe.AddRecipe();
        }

    }

}