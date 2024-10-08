using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;
using Terraria.GameContent.Drawing;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheMultiverseWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.scale = 1.5f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.friendly = true;            
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ignoreWater = true;
            Projectile.alpha = 0;        
            Projectile.extraUpdates = 1;
            Projectile.stopsDealingDamageAfterPenetrateHits = true;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float _ = 0f;
            Vector2 projVelocity = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(-MathHelper.PiOver2) * Projectile.scale;            
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center - projVelocity * 80f, Projectile.Center + projVelocity * 80f, 16f * Projectile.scale, ref _);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Weak, 300);
            target.AddBuff(BuffID.Bleeding, 300);

            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.PrincessWeapon, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center + Main.rand.NextVector2Circular(24f, 24f)
            }, Projectile.owner);
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.alpha += 2;
            if (Projectile.alpha > 255)
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }
            Lighting.AddLight(Projectile.Center + Projectile.rotation.ToRotationVector2() * 64f * Projectile.scale, Color.Magenta.ToVector3());


            Projectile.velocity *= 0.97f;
            if (Projectile.velocity.Length() < 10f && Projectile.scale > 0f)
            {
                Projectile.scale -= 0.01f;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = oldVelocity;
            Projectile.velocity *= 0.01f;
            Projectile.timeLeft = 50;
            return false;
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;            

            Color projColor = Color.White * Projectile.Opacity;            
            Color trailColor = projColor;            

            Vector2 drawOrigin = texture.Size() / 2f;            

            SpriteEffects spriteEffects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
     

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                trailColor *= 0.85f;
                Main.EntitySpriteDraw(texture, Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition, null, trailColor * 0.125f, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.LightPink with { A = 0 } * 0.25f, Projectile.rotation, drawOrigin, Projectile.scale * 1.1f, spriteEffects, 0);
            Main.EntitySpriteDraw(texture, Projectile.oldPos[2] + Projectile.Size / 2 - Main.screenPosition, null, projColor with { A = 0 } * 0.125f, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

            return false;
        }
    }
}
