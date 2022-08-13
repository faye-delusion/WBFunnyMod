using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Misc
{

    public class GoodMorning : ModItem
    {

        // shit does not work yet lol

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Good Morning!");
            Tooltip.SetDefault("Rise and shine, sleepy head!");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Magic/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.maxStack = 1;
            Item.Size = new Vector2(32,32);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Expert;
            Item.mana = 0;

            
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            
            Main.dayTime = true;
            Main.time = 0;

        }

    }

}