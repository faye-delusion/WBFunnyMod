using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;


namespace WBFunnyMod.Projectiles
{

    public class RayGunProjectile : ModProjectile
    {

        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.Size = new Vector2(8,8);
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.aiStyle = 0;
            Projectile.penetrate = 5;
        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            for (int i = 0; i < 7; i++){

                Dust.NewDust(Projectile.position, 4, 4, 15, 0.2f, -0.5f, 0, Color.Green);

            }
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, 4, 4, 15, Projectile.velocity.X * -0.5f, Projectile.velocity.Y * -0.5f,0, Color.Green);
        }

    }

}