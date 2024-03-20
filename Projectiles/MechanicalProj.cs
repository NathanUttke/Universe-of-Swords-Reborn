using Microsoft.Xna.Framework.Graphics;
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
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 36;

            Projectile.scale = 1.5f;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 4;
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
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, new Color(230, 100, 50), 1.5f);
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, new Color(230, 100, 50), 1.25f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.10f, Projectile.oldVelocity.Y * 0.10f, 0, new Color(230, 100, 50), 1.25f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Color projColor = Color.White with { A = 127 };
            Color projColor2 = projColor;

            Vector2 drawOrigin = texture.Size() / 2f;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                if (i % 2 != 0)
                {
                    continue;
                }

                Vector2 drawPos = Projectile.Size / 2f + Projectile.oldPos[i] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                
                projColor2 *= 0.6f;

                Main.spriteBatch.Draw(texture, drawPos, null, projColor2, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }            
            
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), Color.IndianRed with { A = 0 } * 0.75f, Projectile.rotation, drawOrigin, Projectile.scale * 1.125f, spriteEffects, 0);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), texture.Frame(), projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
