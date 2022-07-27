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
            
            Item.Size = new Vector2(40,40);

            Item.damage = 20;
            Item.knockBack = 6;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;

            Item.useTime = 0;
            Item.useAnimation = 6;

            Item.pick = 1000;
            Item.autoReuse = true;

            Item.value = Item.buyPrice(platinum: 10);
            Item.rare = ItemRarityID.Expert;

            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;

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