using WBFunnyMod.Items.Weapons.Misc;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace WBFunnyMod.Projectiles
{
	public class ChnilssonProjectile : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Chnilsson Projectile");
		}

		public override void SetDefaults() {
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.penetrate = 3;
			projectile.hide = true;
		}

		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) {
			if (projectile.ai[0] == 1f)
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) {
					if (Main.npc[npcIndex].behindTiles) {
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else {
						drawCacheProjsBehindNPCs.Add(index);
					}

					return;
				}
			}
			drawCacheProjsBehindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough) {
			width = height = 10; 
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox) {
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8) {
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft) {
			Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y); 
			Vector2 usePos = projectile.position; 
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;
			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++) {
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 81);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}

			if (projectile.owner == Main.myPlayer) {
				int item =
				Main.rand.NextBool(18) ? Item.NewItem(projectile.getRect(), ModContent.ItemType<Chnilsson>()) : 0;
				if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0) {
					NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
				}
			}
		}

		public bool IsStickingToTarget {
			get => projectile.ai[0] == 1f;
			set => projectile.ai[0] = value ? 1f : 0f;
		}

		public int TargetWhoAmI {
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		private const int MAX_STICKY_CHNILSSON = 6;
		private readonly Point[] _stickingChnilssons = new Point[MAX_STICKY_CHNILSSON];

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI; 
			projectile.velocity =
				(target.Center - projectile.Center) *
				0.75f; 
			projectile.netUpdate = true; 
			projectile.damage = 0; 
			UpdateStickyChnilssons(target);
		}

		private void UpdateStickyChnilssons(NPC target)
		{
			int currentChnilssonIndex = 0; 

			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI && currentProjectile.active && currentProjectile.owner == Main.myPlayer && currentProjectile.type == projectile.type && currentProjectile.modProjectile is ChnilssonProjectile chnilssonProjectile && chnilssonProjectile.IsStickingToTarget  && chnilssonProjectile.TargetWhoAmI == target.whoAmI) {
					_stickingChnilssons[currentChnilssonIndex++] = new Point(i, currentProjectile.timeLeft); 
					if (currentChnilssonIndex >= _stickingChnilssons.Length)  
						break;
				}
			}

			if (currentChnilssonIndex >= MAX_STICKY_CHNILSSON)
			{
				int oldChnilssonIndex = 0;
				for (int i = 1; i < MAX_STICKY_CHNILSSON; i++) {
					if (_stickingChnilssons[i].Y < _stickingChnilssons[oldChnilssonIndex].Y) {
						oldChnilssonIndex = i;
					}
				}
				Main.projectile[_stickingChnilssons[oldChnilssonIndex].X].Kill();
			}
		}

		private const int MAX_TICKS = 45;
        private const int ALPHA_REDUCTION = 25;

		public override void AI() {
			UpdateAlpha();
		}

		private void UpdateAlpha()
		{
			if (projectile.alpha > 0) {
				projectile.alpha -= ALPHA_REDUCTION;
			}
			if (projectile.alpha < 0) {
				projectile.alpha = 0;
			}
		}


		private void StickyAI()
		{
			projectile.ignoreWater = true;
			projectile.tileCollide = false; 
			const int aiFactor = 15;
			projectile.localAI[0] += 1f;
			bool hitEffect = projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200) { 
				projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) {
				projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
				projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect) {
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else { 
				projectile.Kill();
			}
		}
	}
}