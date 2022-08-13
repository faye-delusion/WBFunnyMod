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
            Tooltip.SetDefault("Swinging alters the time.");
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

            Main.NewText(damage_multiplier);

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