using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace WBFunnyMod.Projectiles
{

    public class AnvilProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            
            DisplayName.SetDefault("Thrown Anvil");

        }

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            Projectile.Size = new Vector2(32,16);
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            AIType = ProjectileID.ThrowingKnife;
            Projectile.penetrate = -1;
        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(Projectile.damage, 15f, -target.direction);
        }

    }

}