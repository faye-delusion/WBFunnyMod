using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using System;

namespace WBFunnyMod.Items.Weapons.Tomes
{

    public class Ultimatum : ModItem
    {

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Ultimatum");
            Tooltip.SetDefault("Ever wanted to combine all the spell books?");

        }

        public override void SetDefaults()
        {
            
            Item.Size = new Vector2(28,28);

            Item.DamageType = DamageClass.Magic;
            Item.damage = 350;
            Item.knockBack = 0f;
            Item.crit = 4;
            Item.noMelee = true;
            Item.autoReuse = true;

            Item.useTime = 1;
            Item.useAnimation = 1;
            Item.useStyle = ItemUseStyleID.Shoot;
            
            Item.mana = 8;
            Item.shoot = ProjectileID.CrystalStorm;
            Item.shootSpeed = 20;

            Item.value = Item.buyPrice(platinum: 2);
            Item.rare = ItemRarityID.Expert;

        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            Random random = new Random();

            int[] primary_projectile_types = {

                ProjectileID.CrystalStorm,
                ProjectileID.GoldenShowerFriendly,
                ProjectileID.LunarFlare

            };

            int[] alt_projectile_types = {
                ProjectileID.BookOfSkullsSkull, 
                ProjectileID.WaterBolt, 
                ProjectileID.CursedFlameFriendly,
                ProjectileID.DemonScythe,
                ProjectileID.MagnetSphereBall,
                ProjectileID.Typhoon
            };

            int primary_projectile = primary_projectile_types[random.Next(0,primary_projectile_types.Length)];

            Projectile.NewProjectile(source, position, velocity, primary_projectile, damage, knockback, player.whoAmI);
            
            int alt_projectile_type = alt_projectile_types[random.Next(0, alt_projectile_types.Length)];

            Vector2 new_velocity = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(10));

            Projectile.NewProjectile(source, position, new_velocity, alt_projectile_type, damage, knockback, player.whoAmI);



            
            return false;

        }

        public override void AddRecipes()
        {
            
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.WaterBolt);
            recipe.AddIngredient(ItemID.BookofSkulls);
            recipe.AddIngredient(ItemID.DemonScythe);
            recipe.AddIngredient(ItemID.CrystalStorm);
            recipe.AddIngredient(ItemID.CursedFlames);
            recipe.AddIngredient(ItemID.MagnetSphere);
            recipe.AddIngredient(ItemID.RazorbladeTyphoon);
            recipe.AddIngredient(ItemID.LunarFlareBook);

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            Recipe recipe_alt = CreateRecipe();

            recipe_alt.AddIngredient(ItemID.WaterBolt);
            recipe_alt.AddIngredient(ItemID.BookofSkulls);
            recipe_alt.AddIngredient(ItemID.DemonScythe);
            recipe_alt.AddIngredient(ItemID.CrystalStorm);
            recipe_alt.AddIngredient(ItemID.GoldenShower);
            recipe_alt.AddIngredient(ItemID.MagnetSphere);
            recipe_alt.AddIngredient(ItemID.RazorbladeTyphoon);
            recipe_alt.AddIngredient(ItemID.LunarFlareBook);

            recipe_alt.AddTile(TileID.LunarCraftingStation);
            recipe_alt.Register();

        }

    }

}