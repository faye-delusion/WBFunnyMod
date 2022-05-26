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
            aiType = ProjectileID.Bullet;
            projectile.Size = new Vector2(8,8);
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.aiStyle = 0;
            projectile.penetrate = 5;
        }

        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            for (int i = 0; i < 7; i++){

                Dust.NewDust(projectile.position, 4, 4, 15, 0.2f, -0.5f, 0, Color.Green);

            }
        }

        public override void AI()
        {
            Dust.NewDust(projectile.position + projectile.velocity, 4, 4, 15, projectile.velocity.X * -0.5f, projectile.velocity.Y * -0.5f,0, Color.Green);
        }

    }

}