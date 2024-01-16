﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent;
using UniverseOfSwordsMod.Dusts;
using Terraria.Audio;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class MechanicalProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Projectile");
            ProjectileID.Sets.TrailCacheLength[Type] = 12;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 36;

            Projectile.scale = 1.5f;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 8;
            Projectile.alpha = 255;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 40;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.ArmorPenetration = 20;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {            
            if (Projectile.scale > 0f)
            {                
                Projectile.scale -= 0.01f;
            }
            else
            {
                Projectile.scale = 0f;
                Projectile.Kill();
            }

            if (Main.rand.NextBool(2))
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, Color.OrangeRed with { A = 0 }, 2f);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, Color.OrangeRed, 1.5f);
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.10f, Projectile.oldVelocity.Y * 0.10f, 0, Color.OrangeRed, 1.5f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Color projColor = Color.OrangeRed;
            projColor.A = 0;
            Vector2 drawOrigin = texture.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.Size / 2f + Projectile.oldPos[i] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                
                projColor = Projectile.GetAlpha(projColor);
                projColor *= 0.75f;

                Main.spriteBatch.Draw(texture, drawPos, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }            
            
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
