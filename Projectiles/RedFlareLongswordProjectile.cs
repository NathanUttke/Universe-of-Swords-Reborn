using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class RedFlareLongswordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.4f;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 80;
            Projectile.ArmorPenetration = 10;
        }
        
        public override void AI()
        {
            base.AI();
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;                     
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }

            int RedDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 1.25f);
            Dust dust2 = Main.dust[RedDust];
            dust2.velocity *= -0.25f;
            Main.dust[RedDust].noGravity = true;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;             
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(texture.Width - 4f, 2f);
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);

            Color projColor = Color.White;
            projColor.A = 0;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);

                Color color = projColor;                
                color.R += 8;
                color.G *= (byte)0.75f;
                color.B *= (byte)0.75f;


                spriteBatch.Draw(texture, drawPos, sourceRectangle, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.position - Main.screenPosition + (Projectile.Size / 2f), sourceRectangle, projColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);

            for (int i = 1; i < 24; i++)
            {
                int redDust = Dust.NewDust(Projectile.position, 4, 4, DustID.RedTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.8f);
                Main.dust[redDust].noGravity = true;
                redDust = Dust.NewDust(Projectile.position, 4, 4, DustID.RedTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.4f);
                Main.dust[redDust].noGravity = true;
            }
        }


    }
}
