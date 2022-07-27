using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using System;

namespace WBFunnyMod.Items.Accessories.Summoner
{

    public class Papoy : ModItem
    {

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Papoy?");
            Tooltip.SetDefault("Adds 1000 extra minion slots.");

        }

        public override void SetDefaults()
        {
            Item.Size = new Vector2(32,32);

            Item.maxStack = 1;

            Item.accessory = true;

            Item.value = Item.buyPrice(gold:2);
            Item.rare = ItemRarityID.Expert;

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            player.maxMinions += 1000;

        }

        public override void AddRecipes()
        {
            
            Recipe recipe = CreateRecipe();

            recipe.AddIngredient(ItemID.Banana, 10);

            recipe.AddTile(TileID.WorkBenches);

            recipe.Register();

        }

    }

}