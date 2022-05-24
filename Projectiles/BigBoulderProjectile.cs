using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using Microsoft.Xna.Framework;

namespace WBFunnyMod.Projectiles
{

    public class BigBoulderProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("big ass boulder");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Boulder);
            projectile.Size = new Vector2(128,128);
            projectile.aiStyle = 1;
            projectile.friendly = false;
            projectile.ranged = true;
            aiType = ProjectileID.Boulder;
            projectile.penetrate = -1;

        }

        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(target.lifeMax, 0, -target.direction);
        }

    }


}