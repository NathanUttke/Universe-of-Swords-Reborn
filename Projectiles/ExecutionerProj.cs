using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class ExecutionerProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(12);
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 20;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.LimeGreen, Scale: 0.25f);
                dust.position = Projectile.Center - Projectile.velocity / 10f * i;
                dust.velocity *= 0.3f;
                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.Poisoned, 300);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.LimeGreen, Scale: 0.75f);
                dust.position = Projectile.Center;
                dust.velocity *= 3f;
                dust.noGravity = true;
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;
            Color drawColor = Color.White with { A = 90 } * Projectile.Opacity;
            Color trailColor = drawColor;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + Projectile.Size / 2 + new Vector2(0f, Projectile.gfxOffY);
                trailColor *= 0.8f;

                spriteBatch.Draw(texture, drawPos, null, trailColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }
            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
