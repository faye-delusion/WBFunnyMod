using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Microsoft.Xna.Framework;
using WBFunnyMod.Items.Misc.CraftMaterials;

namespace WBFunnyMod.Items.Armor
{
	// The AutoloadEquip attribute automatically attaches an equip texture to this item.
	// Providing the EquipType.Legs value here will result in TML expecting a X_Legs.png file to be placed next to the item's main texture.
	[AutoloadEquip(EquipType.Legs)]
	public class BlackLeatherLeggings : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Black Leather Leggings"
				+ "\nGreat Defense; however, you're unable to move left or right.");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 69); // How many coins the item is worth
			Item.rare = ItemRarityID.Expert; // The rarity of the item
			Item.defense = 500; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player) { // Increase the movement speed of the player
			player.velocity.X *= 0;
			player.moveSpeed *= 0;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DirtBar>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
	}
}