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
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            projectile.damage = 20;
            projectile.width = 10;
            projectile.height = 10;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.WoodenArrowFriendly;

        }

        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(10, 0f, -target.direction);
        }

    }

}