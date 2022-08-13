using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

using Microsoft.Xna.Framework;

using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Weapons.Swords
{

    public class TimeBlade : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Time Blade");
            Tooltip.SetDefault("Damage changes based on the time.");
        }


        public override void SetDefaults()
        {
            
            Item.Size = new Vector2(48,96);

			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.autoReuse = true;

			Item.damage = 60;
			Item.knockBack = 3f;
			Item.crit = 4;

			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
			
			Item.value = Item.buyPrice(silver: 50);
			Item.rare = ItemRarityID.Expert;

        }

        public override void ModifyHitNPC(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        {
            // max time = 54000

            double damage_multiplier = Main.time / 16000;
            
            int new_damage = (int) (60 + (60 * damage_multiplier));

            damage = new_damage;

        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.MythrilBar, 10);
            recipe1.AddIngredient(ItemID.GoldWatch, 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.MythrilBar, 10);
            recipe2.AddIngredient(ItemID.PlatinumWatch, 1);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.Register();

            Recipe recipe3 = CreateRecipe();
            recipe3.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe3.AddIngredient(ItemID.GoldWatch, 1);
            recipe3.AddTile(TileID.MythrilAnvil);
            recipe3.Register();

            Recipe recipe4 = CreateRecipe();
            recipe4.AddIngredient(ItemID.OrichalcumBar, 10);
            recipe4.AddIngredient(ItemID.PlatinumWatch, 1);
            recipe4.AddTile(TileID.MythrilAnvil);
            recipe4.Register();
        }

    }

}