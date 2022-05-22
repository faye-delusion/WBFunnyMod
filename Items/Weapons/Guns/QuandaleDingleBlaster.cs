using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WBFunnyMod.Items.Weapons.Guns
{

    public class QuandaleDingleBlaster : ModItem
    {
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Quandale Dingle Blaster");
			Tooltip.SetDefault("hey guys quandale dingle here");
		}
        public override void SetDefaults()
        {
            item.Size = new Vector2(4,4);

            item.ranged = true;
            item.damage = 2;
            item.knockBack = 0f;
            item.crit = 4;
            item.noMelee = true;
            item.autoReuse = true;

            item.useTime = 1;
            item.useAnimation = 1;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(SoundID.FemaleHit, 0);   

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 10f;
            item.useAmmo = AmmoID.None;

        }

    }

}