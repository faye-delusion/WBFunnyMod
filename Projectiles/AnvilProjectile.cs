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
            projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            projectile.Size = new Vector2(32,16);
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            aiType = ProjectileID.ThrowingKnife;
            projectile.penetrate = -1;
        }

        public override bool Autoload(ref string name)
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(projectile.damage, 15f, -target.direction);
        }

    }

}