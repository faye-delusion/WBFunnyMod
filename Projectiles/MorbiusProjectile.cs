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
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            Projectile.damage = 20;
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            AIType = ProjectileID.WoodenArrowFriendly;

        }

        public override bool IsLoadingEnabled(Mod mod)/* tModPorter Suggestion: If you return false for the purposes of manual loading, use the [Autoload(false)] attribute on your class instead */
        {
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.StrikeNPCNoInteraction(10, 0f, -target.direction);
            target.AddBuff(BuffID.Bleeding, 5);
        }

    }

}