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
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.StarCannonStar}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 8;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(30);
            Projectile.aiStyle = -1;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 8;
            Projectile.friendly = true;
            Projectile.hostile = false; 
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.5f;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.rotation += 0.4f;
            Projectile.velocity.Y += 0.15f;

            if (Projectile.soundDelay == 0)
            {
                Projectile.soundDelay = 80;
                SoundEngine.PlaySound(SoundID.Item9, Projectile.Center);  
            }

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.Yellow, 0.5f);
            dust.position = Projectile.Center - Projectile.velocity / 10f * 5f;
            dust.velocity *= 0.5f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            Projectile.penetrate--;
            if (Projectile.velocity.Y != Projectile.oldVelocity.Y)
            {
                Projectile.velocity.Y = -8f;
            }
            if (Projectile.velocity.X != Projectile.oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }

            return false;
        }
   
        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item10, Projectile.Center);
            for (int i = 0; i < 3; i++) 
            {
                int randomStar = Utils.SelectRandom(Main.rand, 16, 17, 17, 17);
                Gore.NewGore(Projectile.GetSource_Death(), Projectile.position, Projectile.velocity * 0.2f, randomStar);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Color projColor = Color.White with { A = 0 } * Projectile.Opacity;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] + texture.Size() / 2 - Main.screenPosition;
                projColor *= 0.8f;
                Main.EntitySpriteDraw(texture, drawPos, texture.Frame(), projColor, Projectile.rotation, texture.Frame().Size() / 2, Projectile.scale - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, texture.Frame(), new Color(205, 201, 14, 40) * Projectile.Opacity, Projectile.rotation, texture.Frame().Size() / 2, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }
    }
}
