using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{    
    public class DestroyerLaser : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.DeathLaser}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(6);
            Projectile.aiStyle = -1;
            Projectile.penetrate = 10;
            Projectile.extraUpdates = 2;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.timeLeft = 50;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            for (int i = 0; i < 2; i++)
            {
                Dust laserDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 100, Color.OrangeRed, 0.75f);
                laserDust.position = Projectile.Center;
                laserDust.velocity *= 0.1f;
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item33, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;            
            SpriteEffects spriteEffects = SpriteEffects.None;

            Color projColor = Color.White with { A = 0 };
            Color trailColor = projColor;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 oldPos = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                trailColor *= 0.8f;

                Main.spriteBatch.Draw(texture, oldPos, null, trailColor, Projectile.rotation, Vector2.UnitX * texture.Width / 2, Projectile.scale * 1.25f, spriteEffects, 0);
            }

            return false;
        }
    }
}
