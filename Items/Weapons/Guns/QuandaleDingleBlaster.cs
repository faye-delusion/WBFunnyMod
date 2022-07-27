using Terraria;
using Terraria.DataStructures;
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
            Item.Size = new Vector2(4,4);

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 1600;
            Item.knockBack = 0f;
            Item.crit = 4;
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.FemaleHit;

            Item.shoot = ProjectileID.MeteorShot;
            Item.shootSpeed = 20f;
            Item.useAmmo = AmmoID.None;

            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Expert;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {

            int num_projectiles = 20;
            int speedX = (int)velocity.X;
            int speedY = (int)velocity.Y;

            for (int i = 0; i < num_projectiles; i++)
            {
                Vector2 newSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(20));
                Projectile.NewProjectile(source, new Vector2(position.X, position.Y), newSpeed, type, damage, knockback, player.whoAmI);
                // Projectile.NewProjectile(position.X, position.Y, newSpeed.X, newSpeed.Y, type, damage, knockback, player.whoAmI);
            }

            return false;
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