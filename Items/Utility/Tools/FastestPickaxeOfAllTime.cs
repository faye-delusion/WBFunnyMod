using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WBFunnyMod.Items.Misc.CraftMaterials;

using Microsoft.Xna.Framework;

namespace WBFunnyMod.Items.Utility.Tools
{

    public class FastestPickaxeOfAllTime : ModItem
    {

        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("the FASTEST pickaxe of all time");
			Tooltip.SetDefault("this shit fuckin ZOOMIN");
		}

        public override void SetDefaults()
        {
            
            item.Size = new Vector2(40,40);

            item.damage = 20;
            item.knockBack = 6;
            item.melee = true;

            item.useTime = 0;
            item.useAnimation = 6;

            item.pick = 200;
            item.autoReuse = true;

            item.value = Item.buyPrice(platinum: 10);
            item.rare = ItemRarityID.Expert;

            item.UseSound = SoundID.Item1;
            item.useStyle = ItemUseStyleID.SwingThrow;

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