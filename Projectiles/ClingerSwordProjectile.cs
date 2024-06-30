using Microsoft.CodeAnalysis;
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
            Projectile.width = 60;
            Projectile.height = 62;
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

        /*public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation + 90f * Math.Sign(Projectile.velocity.X);
            float collisionPoint = 0f;
            float boxSize = 60f;
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * (0f - boxSize), Projectile.Center + projRotation.ToRotationVector2() * boxSize, 20f, ref collisionPoint);
        }
        */ 
  

        public override void AI()
        {      

            if (Owner.dead || Owner.noItems || Owner.CCed || !Owner.active)
            {
                Projectile.Kill();
                return;
            }

            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 23;
                SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
            }

            SetPlayerValues();


            Projectile.Center = Owner.Center;
            //Projectile.scale = 1f + (MathF.Sin(Projectile.ai[0] / 4f) * -Owner.direction);
            Projectile.spriteDirection = Projectile.direction;
            Projectile.rotation = -MathF.Sin(Projectile.ai[0] / 4f);

            Vector2 bladeOffset = (Projectile.rotation - MathHelper.PiOver2).ToRotationVector2() * Projectile.width / 2f;
            Projectile.position += bladeOffset * Owner.direction;

            Projectile.timeLeft = 2;

            if (Owner.direction < 0)
            {
                Projectile.rotation -= MathHelper.PiOver4;
            }
            //Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);

            bool minUseTime = Projectile.ai[1] == 20f;
            bool maxTime = Projectile.ai[1] >= 30f;
            
            if (minUseTime && !Owner.controlUseItem)
            {
                Projectile.Kill();
            }
            if (maxTime)
            {
                Projectile.ai[1] = 0f;
                if (!Owner.controlUseItem)
                {
                    Projectile.Kill();
                }                
            }

            Projectile.ai[0] += 1f;
            Projectile.ai[1] += 1f;

        }
        private void SetPlayerValues()
        {
            Owner.direction = SwingDirection;
            Owner.heldProj = Projectile.whoAmI;
            Owner.SetDummyItemTime(2);
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = 0f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.TrueNightsEdge, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,
                MovementVector = Projectile.rotation.ToRotationVector2() * 5f * 0.1f + Main.rand.NextVector2Circular(2f, 2f) + Projectile.velocity

            }, Projectile.owner);

            /*int i = 0;
            int direction = 1;
                        
            while (i < 2)
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), target.position.X + (offsetPosition  * direction), target.Center.Y, 5f * -direction, 0f, ModContent.ProjectileType<ClingerWallProj>(), Projectile.damage / 2, 0f, Projectile.owner, 0f, 0f);
                direction *= -1;
                i++;
            }*/

            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }

         public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Owner.direction, texture.Height / 2f), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}