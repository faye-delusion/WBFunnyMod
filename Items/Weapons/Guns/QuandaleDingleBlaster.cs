using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Weapons.Guns
{

    public class QuandaleDingleBlaster : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Quandale Dingle Blaster");
			Tooltip.SetDefault("hey guys quandale dingle here");
		}
        public override void SetDefaults()
        {
            item.Size = new Vector2(4,4);

            item.ranged = true;
            item.damage = 400;
            item.knockBack = 0f;
            item.crit = 4;
            item.noMelee = true;
            item.autoReuse = true;

            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.FemaleHit, 0);   

            item.shoot = ProjectileID.MeteorShot;
            item.shootSpeed = 20f;
            item.useAmmo = AmmoID.None;

            item.value = Item.buyPrice(gold: 10);

        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            int num_projectiles = 20;

            for (int i = 0; i < num_projectiles; i++)
            {
                Vector2 newSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(position.X, position.Y, newSpeed.X, newSpeed.Y, type, damage, knockBack, player.whoAmI);
            }

            return false;
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