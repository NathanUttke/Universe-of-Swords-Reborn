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
    internal class SuperInflationHoldoutProj : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<SuperInflation>().Texture;
        public override void SetDefaults()
        {
            Projectile.Size = new(128);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            //Projectile.hide = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        Player Owner => Main.player[Projectile.owner];
        public ref float Timer => ref Projectile.ai[0];
        public ref float RotationTimer => ref Projectile.ai[1];
        private float Acceleration = 1f;
        private const float MaxTime = 12.5f;
        private static float EaseInBack(float value)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return c3 * value * value * value - c1 * value * value;

        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            Vector2 projRotation = (Projectile.rotation * MathF.Sign(Projectile.velocity.X)).ToRotationVector2();
            float _ = 0f;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center + projRotation * Projectile.height * Projectile.scale, 23f * Projectile.scale, ref _);
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

            Vector2 pointPosition = Owner.RotatedRelativePoint(Owner.MountedCenter);
            float mousePosX = Main.mouseX + Main.screenPosition.X - pointPosition.X;
            float mousePosY = Main.mouseY + Main.screenPosition.Y - pointPosition.Y;
            
            int velocityXSign = Math.Sign(Projectile.velocity.X);
            
            Projectile.velocity = new Vector2(velocityXSign, 0f);

            SetPlayerValues();            
            

            if (Timer == 0f)
            {                
                Projectile.rotation = new Vector2(velocityXSign, 0f - Owner.gravDir).ToRotation() + -MathHelper.PiOver4 + MathHelper.Pi;
                if (Projectile.velocity.X < 0f)
                {
                    Projectile.rotation += MathHelper.PiOver4;
                }
            }
            
            Projectile.spriteDirection = Projectile.direction;
            Projectile.position = Owner.RotatedRelativePoint(Owner.Center, true) - Projectile.Size / 2 + Vector2.UnitX * Owner.direction;
            if (Owner.direction < 0)
            {
                Projectile.position = Owner.RotatedRelativePoint(Owner.Center, true) - Projectile.Size / 2 + new Vector2(4f, 0f);
            } 
            
            Projectile.rotation = -1f + EaseInBack(RotationTimer / 8f) * velocityXSign;
            //Main.NewText(Projectile.rotation);
            if (Timer == MaxTime * 0.72f)
            {
                for (int i = 0; i < 3; i++)
                {
                    float f = 0.25f * i * MathHelper.TwoPi;
                    Vector2 vector51 = Owner.RotatedRelativePoint(Owner.itemLocation) + f.ToRotationVector2() * MathHelper.Lerp(20f, 60f, 0.25f * i);
                    vector51.Y -= Owner.height / 2f;

                    Vector2 v5 = Main.MouseWorld - vector51;
                    Vector2 vector52 = new Vector2(mousePosX, mousePosY).SafeNormalize(Vector2.UnitY) * 9f;
                    v5 = v5.SafeNormalize(vector52) * 9f;
                    v5 = Vector2.Lerp(v5, vector52, 0.25f);
                    Projectile coinProj = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), vector51, v5, ProjectileID.GoldCoin, Projectile.damage / 3, Projectile.knockBack, Projectile.owner);
                    coinProj.timeLeft = 40;
                }
                Timer++;
            }

            if (Timer >= MaxTime * 0.33f)
            {                
                SoundEngine.PlaySound(SoundID.Item169, Projectile.position);
            }

            if (Timer >= MaxTime)
            {                
                Projectile.alpha += 16;
            }

            if (Projectile.alpha > 255)
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }

            //Projectile.rotation = Projectile.velocity.ToRotation();
            Timer++;
            RotationTimer += MathHelper.PiOver4 / 2f;
        }

        private void SetPlayerValues()
        {            
            Owner.heldProj = Projectile.whoAmI;            
            Owner.itemTime = Owner.itemAnimation = 2;
            Owner.itemRotation = Projectile.rotation;
            Owner.SetDummyItemTime(2);
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation + MathHelper.ToRadians(240));
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Color color = Projectile.GetAlpha(lightColor);
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, color, Projectile.rotation, new Vector2(0f * Owner.direction, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
