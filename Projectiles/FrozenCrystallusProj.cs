using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;

namespace UniverseOfSwordsMod.Projectiles
{
    public class FrozenCrystallusProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 8;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 24;

            Projectile.scale = 1f;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 2;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 100;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(2))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Frost, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.1f);
                dust.noGravity = true;
                dust.scale = 1.1f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(0, 162, 232, 40) * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Color projColor = Projectile.GetAlpha(lightColor);
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                projColor *= (8 - i) / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.EntitySpriteDraw(texture, drawPos, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Frost, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Frost, Projectile.oldVelocity.X * 0.10f, Projectile.oldVelocity.Y * 0.10f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Frostburn))
            {
                target.AddBuff(BuffID.Frostburn, 400);
            }
        }
    }
}