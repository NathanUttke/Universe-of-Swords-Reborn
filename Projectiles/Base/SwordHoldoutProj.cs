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
            if (Main.myPlayer == Projectile.owner && (Owner.dead || Owner.noItems || Owner.CCed || !Owner.active))
            {
                Projectile.Kill();
                return;
            }

            if (Main.myPlayer == Projectile.owner && Main.mapFullscreen)
            {
                Projectile.Kill();
            }            

            if (Timer == MaxTime && !Owner.controlUseItem)
            {
                Projectile.Kill();
            }

            Projectile.spriteDirection = Projectile.direction;
            Projectile.Center = Owner.RotatedRelativePoint(Owner.Center, true);
            Projectile.rotation = Projectile.velocity.ToRotation() + (-1.75f * Owner.direction) + EaseInBack(RotationTimer / 8f) * Owner.direction;         

            if (Timer >= MaxTime)
            {                
                Projectile.alpha += 16;               
            }

            if (Projectile.alpha > 255)
            {
                Projectile.scale -= 0.1f;
                Projectile.alpha = 255;
                Projectile.Kill();
            }
            
            Timer++;
            RotationTimer += MathHelper.PiOver4 / 2f;

            Shoot();
            SetPlayerValues();
            CreateDust();
        }

        public virtual void Shoot()
        {
            if (Timer == 12f && Main.myPlayer == Projectile.owner)
            {
                Vector2 newPosition = Owner.RotatedRelativePoint(Owner.Center);
                Vector2 newVelocity = Vector2.Normalize(Main.MouseWorld - newPosition) * 11f;
                Projectile.NewProjectile(Projectile.GetSource_FromAI(), newPosition, newVelocity, ProjectileToShoot, Projectile.damage, Projectile.knockBack, Owner.whoAmI);
                Timer++;
            }
        }

        public virtual void CreateDust()
        {
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin, 0f, 0f, 0, default, 1f);
            }
        }

        public virtual void SetPlayerValues()
        {            
            Owner.heldProj = Projectile.whoAmI;           
            Owner.itemRotation = Projectile.rotation;
            Owner.SetDummyItemTime(2);
            float rotation = Projectile.rotation - MathHelper.PiOver4 - 0.4f;
            if (Owner.direction == -1)
            {
                rotation -= MathHelper.PiOver2 - 0.8f;
            }
            Owner.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, rotation);
        }

        public virtual Color TrailColor => Color.White;

        public override bool PreDraw(ref Color lightColor)
        {
            Color drawColor = Projectile.GetAlpha(lightColor);
            Color trailColor = TrailColor;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;
            float rotation = Projectile.rotation + MathHelper.PiOver4;


            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                float oldRotation = Projectile.oldRot[i] + MathHelper.PiOver4;

                trailColor *= 0.75f;
                spriteBatch.Draw(texture, Projectile.oldPos[i] + Projectile.Size / 2f - Main.screenPosition, null, trailColor with { A = 0 }, oldRotation, new(0f, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, rotation, new(0f, texture.Height), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
