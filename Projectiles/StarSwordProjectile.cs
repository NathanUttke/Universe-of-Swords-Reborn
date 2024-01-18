using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using UniverseOfSwordsMod.Dusts;
using System;

namespace UniverseOfSwordsMod.Projectiles
{    
    public class StarSwordProjectile : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.FallingStar}";

        public readonly int numOfBounces = 8;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 8;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.hostile = false; 
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.5f;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.rotation += 0.4f;
            Projectile.velocity.Y += 0.2f;

            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 40;
                SoundEngine.PlaySound(SoundID.Item9, Projectile.Center);  
            }

            if (MathF.Abs(Projectile.velocity.Y) > 16f)
            {
                Projectile.velocity.Y = 16f;
            }      

            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, Color.Yellow, 1.25f);
        }
        public override Color? GetAlpha(Color lightColor) => new Color(205, 201, 14, 40) * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;            

            Color projColor = Projectile.GetAlpha(lightColor);            
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = (Projectile.oldPos[i] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                projColor *= (8 - i) / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                projColor.B = Utils.SelectRandom<byte>(Main.rand, 14, 20, 120, 0);
                Main.EntitySpriteDraw(texture, drawPos, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale - i / Projectile.oldPos.Length, SpriteEffects.None, 0);
            }
            return true;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (Projectile.tileCollide)
            {
                SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
                Projectile.ai[0] += 1f;
                if (Projectile.ai[0] >= (float)numOfBounces)
                {
                    Projectile.position += Projectile.velocity;
                    Projectile.Kill();
                }
                if (Projectile.velocity.Y != Projectile.oldVelocity.Y)
                {
                    Projectile.velocity.Y = (0f - Projectile.oldVelocity.Y) * 0.8f;
                }
                if (Projectile.velocity.X != Projectile.oldVelocity.X)
                {
                    Projectile.velocity.X = 0f - Projectile.oldVelocity.X;
                }
            }
            return false;
        }
   
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            for (int i = 0; i < 3; i++) 
            {
                int randomStar = Utils.SelectRandom(Main.rand, 16, 17, 17, 17);
                Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, Projectile.velocity * 0.2f, randomStar);
            }
        }
    }
}
