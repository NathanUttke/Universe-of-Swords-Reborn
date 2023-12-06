﻿using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;
using Terraria.Audio;

namespace UniverseOfSwordsMod.Projectiles
{
    public class PurpleScytheClone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 8;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DemonScythe);
            AIType = ProjectileID.DemonScythe;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Item[Type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Violet;
            drawColorGlow.A = 0;

            spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 0.5f, SpriteEffects.None, 0);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color color = Lighting.GetColor((int)(Projectile.position.X + (double)Projectile.width / 2) / 16, (int)((Projectile.position.Y + Projectile.height * 0.5) / 16.0));
                color = Projectile.GetAlpha(color);
                float multValue = 8 - j;
                color *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                spriteBatch.Draw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, MathHelper.Lerp(Projectile.scale, 1f, j / 15f), SpriteEffects.None, 0);

            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int z = 0; z < 30; z++)
            {
                int purpleDust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.5f);
                Main.dust[purpleDust].noGravity = true;
                Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Shadowflame, Projectile.velocity.X, Projectile.velocity.Y, 100);
            }
        }
    }
}
