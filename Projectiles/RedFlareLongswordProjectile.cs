using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class RedFlareLongswordProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {            
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            Projectile.timeLeft = 20;
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

            int RedDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(250, 100, 100, 0), 1f);
            Dust dust2 = Main.dust[RedDust];
            dust2.velocity *= -0.25f;
            Main.dust[RedDust].noGravity = true;

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver4;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;             
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D textureExtra = TextureAssets.Extra[ExtrasID.SharpTears].Value;
            Vector2 drawOrigin = new(texture.Width - 4f, 2f);
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
            
            Color drawColor = Color.White;
            Color drawColorTrail = Color.White;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                if (j % 2 != 0)
                {
                    continue;
                }

                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);                
                drawColorTrail *= 0.75f;

                spriteBatch.Draw(texture, drawPos, sourceRectangle, drawColorTrail, Projectile.rotation, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, sourceRectangle, drawColorTrail * 0.25f, Projectile.rotation, drawOrigin, (Projectile.scale * 1.5f) - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(texture, Projectile.position - Main.screenPosition + (Projectile.Size / 2f), sourceRectangle, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);

            for (int i = 0; i < 15; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(250, 100, 100, 0), 1.25f);
            }
        }
    }
}
