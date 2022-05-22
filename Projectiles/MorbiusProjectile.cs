using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WBFunnyMod.Projectiles
{

    public class MorbiusProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Morbius Projectile");

        }

        public override void SetDefaults()
        {
            
            projectile.arrow = true;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;

        }

    }

}