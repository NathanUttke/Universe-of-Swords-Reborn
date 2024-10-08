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
    public class SwordHoldoutProj : ModProjectile
    {
        public virtual float SwordSize => 32f;
        public virtual int ProjectileToShoot => ProjectileID.Bullet;
        public override string Texture => ModContent.GetInstance<SuperInflation>().Texture;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(16);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.hide = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 23;
        }

        Player Owner => Main.player[Projectile.owner];
        public ref float Timer => ref Projectile.ai[0];
        public ref float RotationTimer => ref Projectile.ai[1];
        
        private const float MaxTime = 12.5f;
        private static float EaseInBack(float value)
        {
            float c1 = 1.70158f;
            float c3 = c1 + 1;

            return c3 * value * value * value - c1 * value * value;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float projRotation = Projectile.rotation - MathHelper.PiOver4;
            float _ = 0f;

            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center, Projectile.Center - projRotation.ToRotationVector2() * SwordSize * -Projectile.scale, 20f, ref _);
        }

        public override void AI()
        {
            Shoot();
            SetPlayerValues();
            CreateDust();
        }

        public virtual void Shoot()
        {
        }

        public virtual void CreateDust()
        {
        }

        public virtual void SetPlayerValues()
        {            
            Owner.heldProj = Projectile.whoAmI;           
            Owner.itemRotation = Projectile.rotation;
            float rotation = Projectile.rotation - MathHelper.PiOver2;
            if (Owner.direction == -1)
            {
                rotation -= MathHelper.PiOver4 / 4;
            }
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, rotation);
        }

        public virtual Color TrailColor => Color.White;

        public override bool PreDraw(ref Color lightColor)
        {
            Color drawColor = Projectile.GetAlpha(lightColor);
            Color trailColor = TrailColor with { A = 0 } * Projectile.Opacity;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;
            float rotation = Projectile.rotation + MathHelper.PiOver4;


            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float oldRotation = Projectile.oldRot[i] + MathHelper.PiOver4;

                trailColor *= 0.75f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] + Projectile.Size / 2f - Main.screenPosition, null, trailColor, oldRotation, new(0f, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, rotation, new(0f, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
