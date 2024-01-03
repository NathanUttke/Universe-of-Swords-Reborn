using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    public class ClingerSwordProjectile : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<ClingerSword>().Texture;
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.hide = true;            
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
        }        
        public Player Owner => Main.player[Projectile.owner];        
        public int SwingDirection => MathF.Sign(Projectile.velocity.X);

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float collisionPoint = 0f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Owner.MountedCenter, Owner.MountedCenter + (Projectile.velocity * 15f * Projectile.scale), Projectile.scale * 16f, ref collisionPoint);
        }
        public override void AI()
        {      

            if (Main.myPlayer == Projectile.owner && (Owner.dead || !Owner.controlUseItem || Owner.noItems || Owner.CCed))
            {
                Projectile.Kill();
            }

            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 23;
                SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
            }

            SetPlayerValues();

            Projectile.Center = Owner.Center;
            Projectile.scale = 1f + (MathF.Sin(Projectile.ai[1] / 4f) * -Owner.direction);
            Projectile.spriteDirection = Projectile.direction;
            Projectile.rotation = -MathF.Sin(Projectile.ai[1] / 4f);

            if (Owner.direction < 0)
            {
                Projectile.rotation -= MathHelper.PiOver2;
            }
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);
            Projectile.ai[1] += 1f;
        }
        private void SetPlayerValues()
        {
            Owner.direction = SwingDirection;
            Owner.heldProj = Projectile.whoAmI;
            Owner.SetDummyItemTime(2);
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = Projectile.rotation;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.TrueNightsEdge, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,
                MovementVector = Projectile.rotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f) + Projectile.velocity

            }, Projectile.owner);

            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Owner.direction, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}