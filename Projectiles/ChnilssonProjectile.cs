using Terraria.Audio;
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
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = 3;
			Projectile.hide = true;
		}

		public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI) {
			if (Projectile.ai[0] == 1f)
			{
				int npcIndex = (int)Projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) {
					if (Main.npc[npcIndex].behindTiles) {
						behindNPCsAndTiles.Add(index);
					}
					else {
						behindNPCs.Add(index);
					}

					return;
				}
			}
			behindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac) {
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
			SoundEngine.PlaySound(SoundID.Dig, Projectile.position); 
			Vector2 usePos = Projectile.position; 
			Vector2 rotVector = (Projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
			usePos += rotVector * 16f;
			const int NUM_DUSTS = 20;

			for (int i = 0; i < NUM_DUSTS; i++) {
				Dust dust = Dust.NewDustDirect(usePos, Projectile.width, Projectile.height, 81);
				dust.position = (dust.position + Projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}

			// if (Projectile.owner == Main.myPlayer) {
			// 	int item =
			// 	Main.rand.NextBool(18) ? Item.NewItem(Projectile.getRect(), ModContent.ItemType<Chnilsson>()) : 0;
			// 	if (Main.netMode == NetmodeID.MultiplayerClient && item >= 0) {
			// 		NetMessage.SendData(MessageID.SyncItem, -1, -1, null, item, 1f);
			// 	}
			// }
		}

		public bool IsStickingToTarget {
			get => Projectile.ai[0] == 1f;
			set => Projectile.ai[0] = value ? 1f : 0f;
		}

		public int TargetWhoAmI {
			get => (int)Projectile.ai[1];
			set => Projectile.ai[1] = value;
		}

		private const int MAX_STICKY_CHNILSSON = 6;
		private readonly Point[] _stickingChnilssons = new Point[MAX_STICKY_CHNILSSON];

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
			IsStickingToTarget = true; 
			TargetWhoAmI = target.whoAmI; 
			Projectile.velocity =
				(target.Center - Projectile.Center) *
				0.75f; 
			Projectile.netUpdate = true; 
			Projectile.damage = 0; 
			UpdateStickyChnilssons(target);
		}

		private void UpdateStickyChnilssons(NPC target)
		{
			int currentChnilssonIndex = 0; 

			for (int i = 0; i < Main.maxProjectiles; i++)
			{
				Projectile currentProjectile = Main.projectile[i];
				if (i != Projectile.whoAmI && currentProjectile.active && currentProjectile.owner == Main.myPlayer && currentProjectile.type == Projectile.type && currentProjectile.ModProjectile is ChnilssonProjectile chnilssonProjectile && chnilssonProjectile.IsStickingToTarget  && chnilssonProjectile.TargetWhoAmI == target.whoAmI) {
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
			if (Projectile.alpha > 0) {
				Projectile.alpha -= ALPHA_REDUCTION;
			}
			if (Projectile.alpha < 0) {
				Projectile.alpha = 0;
			}
		}


		private void StickyAI()
		{
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false; 
			const int aiFactor = 15;
			Projectile.localAI[0] += 1f;
			bool hitEffect = Projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (Projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200) { 
				Projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) {
				Projectile.Center = Main.npc[projTargetIndex].Center - Projectile.velocity * 2f;
				Projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				if (hitEffect) {
					Main.npc[projTargetIndex].HitEffect(0, 1.0);
				}
			}
			else { 
				Projectile.Kill();
			}
		}
	}
}