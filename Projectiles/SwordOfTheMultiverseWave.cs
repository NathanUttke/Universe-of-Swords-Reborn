using Microsoft.Xna.Framework;
using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheMultiverseWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 15;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 4;
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
            Projectile.localNPCHitCooldown = 8;
            Projectile.alpha = 0;            
            Projectile.ownerHitCheck = true;
            Projectile.ownerHitCheckDistance = 600f;
            Projectile.light = 0.25f;
            Projectile.extraUpdates = 1;
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

            //Projectile.scale *= 0.99f;
            Projectile.velocity *= 0.97f;
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/SwordOfTheMultiverseWave");

            Color projColor = Projectile.GetAlpha(lightColor);            
            Color projColor2 = projColor;

            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            Vector2 drawOriginGlow = new(glowTexture.Width / 2, glowTexture.Height / 2);

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.Size / 2f + Projectile.oldPos[i] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                
                projColor2.A = 0;
                projColor2 *= 0.75f;                

                Main.spriteBatch.Draw(texture, drawPos, null, projColor2, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }

            //projColor.A = 127;                     
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

            //projColor.A = 0;
            Main.spriteBatch.Draw(glowTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, drawOriginGlow, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
