using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
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
            // DisplayName.SetDefault("Ultimate Saber");
            Main.projFrames[Projectile.type] = 7;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
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
        public override void AI()
        {
            base.AI();

            Player player = Main.player[Projectile.owner];            

            double rad = Projectile.ai[1] * 5.0 * (Math.PI / 180.0);
            double distance = 90;
            Projectile.ai[1] += 1f;
            //Projectile.Center = player.Center + Vector2.One.RotatedBy(Projectile.ai[0]) * (int)rad;
            //Projectile.rotation = Projectile.position.ToRotation() + MathHelper.PiOver2;
            float posX = player.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = player.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;            
            //Projectile.Center = player.RotatedRelativePoint(player.MountedCenter) + Projectile.velocity * (Projectile.ai[1] - 1f);
            Projectile.rotation = player.Center.AngleTo(Projectile.Center) + MathHelper.PiOver4;
            Projectile.position = new Vector2(posX, posY);

            if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem || player.noItems || player.CCed))
            {
                Projectile.Kill();
            }

            if (!_initialized)
            {
                Projectile.frame = player.ownedProjectileCounts[Type];
                _initialized = true;
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            SpriteBatch spriteBatch = Main.spriteBatch;

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;            
            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);


            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, defaultColor, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);            
            return false;
        }
    }
}
