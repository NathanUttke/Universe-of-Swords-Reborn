using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics;
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
            Projectile.light = 0.7f;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 80;
            Projectile.ArmorPenetration = 10;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 14;
        }

        public override void AI()
        {
            base.AI();
            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;                     
                SoundEngine.PlaySound(SoundID.Item8, Projectile.position);
            }

            int RedDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, Projectile.oldVelocity.X, Projectile.oldVelocity.Y, 100, default, 1.5f);
            Dust dust2 = Main.dust[RedDust];
            dust2.velocity *= -0.25f;
            Main.dust[RedDust].noGravity = true;

            Projectile.rotation = MathF.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + MathHelper.PiOver4;

            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);
  
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);

            spriteBatch.Draw(texture, new Vector2(Projectile.position.X - Main.screenPosition.X + Projectile.width / 2, Projectile.position.Y - Main.screenPosition.Y + Projectile.height / 2), sourceRectangle, Color.White, Projectile.rotation, new Vector2(TextureAssets.Projectile[Projectile.type].Width(), 0f), Projectile.scale, SpriteEffects.None, 0);
            default(FlameLashDrawer).Draw(Projectile);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);

            for (int i = 1; i < 24; i++)
            {
                float oldVelX = Projectile.velocity.X * (30f / i);
                float oldVelY = Projectile.velocity.Y * (30f / i);
                int redDust = Dust.NewDust(new Vector2(Projectile.position.X - oldVelX, Projectile.position.Y - oldVelY), 4, 4, DustID.RedTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.8f);
                Main.dust[redDust].noGravity = true;
                redDust = Dust.NewDust(new Vector2(Projectile.position.X - oldVelX, Projectile.position.Y - oldVelY), 4, 4, DustID.RedTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.4f);
                Main.dust[redDust].noGravity = true;
            }
        }


    }
}
