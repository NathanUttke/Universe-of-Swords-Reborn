using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class UltimateSaberProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {            
            Main.projFrames[Projectile.type] = 7;
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {            
            Projectile.width = 56;
            Projectile.height = 56;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
        }

        private bool _initialized;
        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            base.AI();          

            float rad = MathHelper.ToRadians(Projectile.ai[1] * 5f);            
            float distance = 90;
            Projectile.ai[1] += 1f;

            float posX = Owner.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = Owner.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;            

            Projectile.rotation = Owner.Center.AngleTo(Projectile.Center) + MathHelper.PiOver4;
            Projectile.position = new Vector2(posX, posY);

            if (Main.myPlayer == Projectile.owner && (!Owner.channel || !Owner.controlUseItem || Owner.noItems || Owner.CCed))
            {
                Projectile.Kill();
            }

            if (!_initialized)
            {                 
                Projectile.frame = Owner.ownedProjectileCounts[Type];                
                _initialized = true;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            Color projColor = Projectile.GetAlpha(lightColor);
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            SpriteBatch spriteBatch = Main.spriteBatch;

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;            
            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);            

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + sourceRectangle.Size() / 2f;
                projColor *= 0.75f;
                spriteBatch.Draw(texture, drawPos, sourceRectangle, projColor, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);            
            return false;
        }
    }
}
