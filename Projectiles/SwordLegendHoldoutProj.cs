﻿using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{
    
    internal class SwordLegendHoldoutProj : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<BiggoronSword>().Texture;
        private enum AIState : int
        {
            SwingingLeft = 0,
            Throwing = 1,
            Retracting = 2
        };

        private AIState CurrentAIState
        {
            get => (AIState)Projectile.ai[0];
            set => Projectile.ai[0] = (float)value;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(90);
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

        Player Owner => Main.player[Projectile.owner];
        public ref float SwingTimer => ref Projectile.ai[1];
        public int SwingDirection => MathF.Sign(Projectile.velocity.X);
        private const float MaxTime = 12.5f;
        private bool isInitialized;

        private float EaseInBack(float value)
        {
            float c1 = 1.70158f;            
            float c3 = c1 + 1;

            return c3 * value * value * value - c1 * value * value;

        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4 * MathF.Sign(Projectile.velocity.X);
            float collisionPoint7 = 0f;
            float num20 = 110f;
            if (CurrentAIState != AIState.SwingingLeft)
            {
                num20 = 80f;
            }
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center + projRotation.ToRotationVector2() * (0f - num20), Projectile.Center + projRotation.ToRotationVector2() * num20, 23f * Projectile.scale, ref collisionPoint7);
        }

        public override void AI()
        {           
            if (Main.myPlayer == Projectile.owner && (Owner.dead || !Owner.controlUseItem || Owner.noItems || Owner.CCed))
            {
                Projectile.Kill();
            }        

            if (Main.myPlayer == Projectile.owner && Main.mapFullscreen)
            {
                Projectile.Kill();
            }

            Owner.heldProj = Projectile.whoAmI;            
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = Projectile.rotation;
            Owner.SetDummyItemTime(2);

            switch (CurrentAIState)
            {
                case AIState.SwingingLeft:
                    SwingLeft();
                    break;
                case AIState.Throwing:
                    ThrowWeapon();
                    break;
                case AIState.Retracting:
                    RetractWeapon();
                    break;
            }

            Projectile.direction = (Projectile.velocity.X > 0f).ToDirectionInt();
            Projectile.spriteDirection = Projectile.direction;
        }

        private void SwingLeft()
        {
            Vector2 unitVectorTowardsMouse = Owner.MountedCenter.DirectionTo(Main.MouseWorld).SafeNormalize(Vector2.UnitX * Owner.direction);
            Owner.ChangeDir((unitVectorTowardsMouse.X > 0f).ToDirectionInt());

            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 30;
                SoundEngine.PlaySound(SoundID.Item1, Projectile.position);
            }

            Projectile.rotation = MathHelper.Lerp(-MathF.Sin(SwingTimer / 4f) * Owner.direction, 4f * Owner.direction, MathF.Sin(SwingTimer / 4f));
            if (Owner.direction < 0)
            {
                Projectile.rotation += MathHelper.PiOver2;
            }
            SwingTimer += 0.25f;

            if (SwingTimer > MaxTime)
            {
                CurrentAIState = AIState.Throwing;
                SwingTimer = 0f;
                Projectile.velocity = unitVectorTowardsMouse * 14f + Owner.velocity;
                Projectile.netUpdate = true;                           
            }
            Projectile.Center = Owner.MountedCenter;
        }
        private void ThrowWeapon()
        {
            if (Projectile.soundDelay <= 0)
            {
                Projectile.soundDelay = 20;
                SoundEngine.PlaySound(SoundID.Item169, Projectile.position);
            }
            Projectile.rotation += 0.25f;
            if (Projectile.Distance(Owner.MountedCenter) >= 800f || SwingTimer++ >= 15f)
            {
                CurrentAIState = AIState.Retracting;
                SwingTimer = 0f;
                Projectile.netUpdate = true;
                Projectile.velocity *= 0.3f;
            }
            Owner.ChangeDir((Owner.Center.X < Projectile.Center.X).ToDirectionInt());
        }

        private void RetractWeapon()
        {
            Projectile.rotation += 0.25f;
            Vector2 vecTowardsPlayer = Projectile.DirectionTo(Owner.MountedCenter).SafeNormalize(Vector2.Zero);
            if (Projectile.Distance(Owner.MountedCenter) <= 10f)
            {
                Projectile.scale *= 0.75f;
                Projectile.Kill();
            }            
            Projectile.velocity *= 0.98f;
            Projectile.velocity = Projectile.velocity.MoveTowards(vecTowardsPlayer * 10f, 3f);            
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 textureOrigin = new (0f * Owner.direction, texture.Height);

            if (CurrentAIState != AIState.SwingingLeft)
            {
                textureOrigin = new(texture.Width / 2f, texture.Height / 2f);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation - MathHelper.PiOver2, textureOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
