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
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.maxStack = 999;
            Item.Size = new Vector2(30,24);
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Expert;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }

    }

}