using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class PurpleScytheClone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.scale = 1f;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.light = 0.33f;
            Projectile.penetrate = -1;
            Projectile.alpha = 127;
            Projectile.timeLeft = 80;
        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.8f;
            Projectile.ai[0] += 1f;

            if (Projectile.ai[0] > 30f)
            {
                if (Projectile.ai[0] < 100f)
                {
                    Projectile.velocity *= 1.075f;
                }
                else
                {
                    Projectile.ai[0] = 200f;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, new Color (174, 74, 255, 0), 1f);
                newDust.rotation += 0.05f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = new Color(174, 74, 255, 0);            

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);                

                Color color = Projectile.GetAlpha(lightColor);
                color *= 0.5f;
                drawColorGlow *= 0.5f;

                spriteBatch.Draw(glowSphere, drawPos, null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int z = 0; z < 30; z++)
            {
                int purpleDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.5f);
                Main.dust[purpleDust].noGravity = true;
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X, Projectile.velocity.Y, 100);
            }
        }
    }
}
