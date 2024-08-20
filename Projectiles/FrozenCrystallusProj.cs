using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class FrozenCrystallusProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(16);
            Projectile.aiStyle = -1;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 50;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float _ = 0f;
            Vector2 projVelocity = Projectile.velocity.SafeNormalize(Vector2.UnitY).RotatedBy(-MathHelper.PiOver2) * Projectile.scale;            
            return Collision.CheckAABBvLineCollision(targetHitbox.TopLeft(), targetHitbox.Size(), Projectile.Center - projVelocity * 80f, Projectile.Center + projVelocity * 80f, 16f * Projectile.scale, ref _);
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 18f)
            {
                Projectile.scale *= 0.98f;
                Projectile.alpha++;
                Projectile.velocity *= 0.9f;
            }
            if (Projectile.ai[1] == 1f)
            {
                Projectile.tileCollide = false;
                Projectile.velocity *= 0.9f;
                Projectile.alpha += 16;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Color projColor = Color.White * Projectile.Opacity;
            Color trailColor = projColor;
            Vector2 drawOrigin = texture.Size() / 2f;

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] + Projectile.Size / 2f - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);
                trailColor *= 0.8f;
                Main.EntitySpriteDraw(texture, drawPos, null, trailColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity = oldVelocity / 2f;
            Projectile.ai[1] = 1f;
            Projectile.netUpdate = true;
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            /*for (int k = 0; k < 20; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.SkyBlue, Scale: 0.5f);
            }*/
        }
		
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Frostburn, 400);
        }
    }
}