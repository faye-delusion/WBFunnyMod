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
            Item.Size = new Vector2(12,12);

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 4000;
            Item.knockBack = 0f;
            Item.crit = 5;
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            
            Item.shoot = ModContent.ProjectileType<RayGunProjectile>(); // placeholder, replace later
            Item.shootSpeed = 20;
            Item.useAmmo = AmmoID.None;
            Item.UseSound = SoundID.Item115;

            Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.Expert;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DirtBar>());
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

    }

}