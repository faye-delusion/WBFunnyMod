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
            Item.shootSpeed = 4f;
            Item.damage = 20000;
            Item.knockBack = 15f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.Size = new Vector2(32,16);
            Item.maxStack = 999;
            Item.rare = ItemRarityID.Expert;

            Item.consumable = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.autoReuse = false;
            Item.DamageType = DamageClass.Throwing;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.buyPrice(silver: 50);
            Item.shoot = ModContent.ProjectileType<AnvilProjectile>();

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }

}