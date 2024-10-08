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
            Projectile.penetrate = 1;
            Projectile.alpha = 127;
            Projectile.timeLeft = 40;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation += Projectile.direction * MathHelper.PiOver4;
            Projectile.ai[0] += 1f;

            Lighting.AddLight(Projectile.Center, 0.68f, 0.25f, 1f);

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

            for (int i = 0; i < 16; i++)
            {
                Vector2 newVelocity = Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 16f);
                Dust dust = Dust.NewDustPerfect(Projectile.position, ModContent.DustType<GlowDust>(), newColor: new Color(174, 74, 255, 0), Scale: 0.75f);
                dust.position = Projectile.Center;
                dust.velocity = newVelocity;
            }
        }

        public override Color? GetAlpha(Color lightColor) => Color.White with { A = 0 } * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = new(174, 74, 255, 0);            

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);                

                Color color = Projectile.GetAlpha(lightColor);
                color *= 0.5f;
                drawColorGlow *= 0.5f;

                spriteBatch.Draw(glowSphere, drawPos, null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
            }
            return true;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int z = 0; z < 30; z++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 0, new Color(174, 74, 255));
            }
        }
    }
}
