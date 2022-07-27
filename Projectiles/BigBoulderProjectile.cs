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
            Projectile.CloneDefaults(ProjectileID.Boulder);
            Projectile.Size = new Vector2(128,128);
            Projectile.aiStyle = 1;
            Projectile.friendly = false;
            Projectile.DamageType = DamageClass.Ranged;
            AIType = ProjectileID.Boulder;
            Projectile.penetrate = -1;

        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(target.lifeMax, 0, -target.direction);
        }

    }


}