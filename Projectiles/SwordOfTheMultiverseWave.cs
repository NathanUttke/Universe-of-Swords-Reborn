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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 168;
            Projectile.height = 64;
            Projectile.scale = 1.5f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.friendly = true;            
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            //Projectile.usesLocalNPCImmunity = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            //Projectile.localNPCHitCooldown = 11;
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
                PositionInWorld = target.Center,
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
            
            Projectile.velocity *= 0.97f;
            if (Projectile.velocity.Length() < 10f && Projectile.scale > 0f)
            {
                Projectile.scale -= 0.01f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;            
            Texture2D textureExtra = TextureAssets.Extra[27].Value;            

            Color projColor = Color.White;            
            Color projColor2 = Projectile.GetAlpha(lightColor);            

            Vector2 drawOrigin = texture.Size() / 2f;            

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }          
           

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor2, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.LightPink with { A = 0 } * 0.25f, Projectile.rotation, drawOrigin, Projectile.scale * 1.1f, spriteEffects, 0);
            Main.EntitySpriteDraw(texture, Projectile.oldPos[2] + Projectile.Size / 2 - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor2 with { A = 0 } * 0.125f, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

            return false;
        }
    }
}
