using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;
using WBFunnyMod.Projectiles;
using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Weapons.Guns
{

    public class RayGun  : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ray Gun");
            Tooltip.SetDefault("REVIVE ME");
        }

        public override void SetDefaults()
        {
            item.Size = new Vector2(12,12);

            item.ranged = true;
            item.damage = 4000;
            item.knockBack = 0f;
            item.crit = 5;
            item.noMelee = true;
            item.autoReuse = true;

            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            
            item.shoot = ModContent.ProjectileType<RayGunProjectile>(); // placeholder, replace later
            item.shootSpeed = 20;
            item.useAmmo = AmmoID.None;
            item.UseSound = SoundID.Item115;

            item.value = Item.buyPrice(platinum: 2);
            item.rare = ItemRarityID.Expert;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<DirtBar>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

}