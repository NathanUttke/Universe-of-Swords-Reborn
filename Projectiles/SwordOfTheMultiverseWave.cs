using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using System;

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
            Projectile.scale = 2f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.friendly = true;            
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.localNPCHitCooldown = 11;
            Projectile.alpha = 0;        
            Projectile.extraUpdates = 1;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float _ = 0f;
            Vector2 projVelocity = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(-MathHelper.PiOver2) * Projectile.scale;            
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center - projVelocity * 80f, Projectile.Center + projVelocity * 80f, 16f * Projectile.scale, ref _);
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            if (Projectile.alpha < 255)
            {
                Projectile.alpha += 2;
            }
            else if (Projectile.alpha > 255)
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }
            
            Projectile.velocity *= 0.96f;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White * Projectile.Opacity;


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;            

            Color projColor = Color.White;            
            Color projColor2 = Projectile.GetAlpha(lightColor);            

            Vector2 drawOrigin = texture.Size() / 2f;            

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                if (i % 4 != 0)
                {
                    continue;
                }

                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);                

                projColor *= 0.5f;
                
                Main.spriteBatch.Draw(texture, drawPos, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);                
            }
                  

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor2, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);


            return false;
        }
    }
}
