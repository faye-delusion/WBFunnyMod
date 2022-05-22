using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WBFunnyMod.Items.Misc.CraftMaterials
{

    public class DirtBar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dirt Bar");
            Tooltip.SetDefault("mud");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.maxStack = 999;
            item.Size = new Vector2(30,24);
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.autoReuse = true;
            item.rare = ItemRarityID.Expert;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }

}