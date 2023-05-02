using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class MechanicalProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 80;
            Projectile.height = 36;

            Projectile.scale = 2f;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 8;
            Projectile.alpha = 255;

            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;

            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 300;

            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if (Projectile.scale > 0f)
            {
                Projectile.scale -= 0.0075f;
            }
            else
            {
                Projectile.scale = 0f;
                Projectile.Kill();
            }

            if (Main.rand.NextBool(2))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.OrangeTorch, Projectile.velocity.X, Projectile.velocity.Y, 100, default, 1.25f);
                dust.noGravity = true;
                dust.scale = 1.1f;
            }
        }
        public override Color? GetAlpha(Color lightColor) => new Color(247, 119, 91, 50) * Projectile.Opacity;

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
                Vector2 drawPos = Projectile.Size / 2f + Projectile.oldPos[i] - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);     

                projColor *= (8 - i) / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
                Main.EntitySpriteDraw(texture, drawPos, null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}
