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
            Projectile.Size = new(56);
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
        }

        Player Owner => Main.player[Projectile.owner];

        public float AITimer
        {
            get => Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }

        public override void AI()
        {
            if (Main.myPlayer == Projectile.owner && (!Owner.channel || !Owner.controlUseItem || Owner.noItems || Owner.CCed))
            {
                Projectile.Kill();
            }

            Projectile.frame = (int)Projectile.ai[0];
            float rad = MathHelper.ToRadians(AITimer * 5f) * Owner.direction;
            Vector2 position = Owner.Center - rad.ToRotationVector2() * 90f - Projectile.Size / 2;

            AITimer++;            

            // Point to the player's center
            Projectile.rotation = Owner.Center.AngleTo(Projectile.Center) + MathHelper.PiOver4;
            Projectile.position = position;
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
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + Projectile.Size / 2f;
                projColor *= 0.75f;
                spriteBatch.Draw(texture, drawPos, sourceRectangle, projColor, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, Color.White with { A = 0 } * 0.25f, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale * 1.125f, SpriteEffects.None, 0);

            return false;
        }
    }
}
