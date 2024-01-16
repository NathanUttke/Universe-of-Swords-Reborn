using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using UniverseOfSwordsMod.Utilities;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Dusts;
using Terraria.Audio;

namespace UniverseOfSwordsMod.Projectiles
{
    public class DemonScytheClone : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 10;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 48;
            Projectile.scale = 1.25f;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.light = 0.33f;
            Projectile.alpha = 127;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 30;
        }
        public override void AI()
        {
            base.AI();
            Projectile.rotation += 0.8f;
            Projectile.ai[0] += 1f;

            if (Projectile.ai[0] > 30f)
            {
                if (Projectile.ai[0] < 100f)
                {
                    Projectile.velocity *= 1.075f;
                }
                else
                {
                    Projectile.ai[0] = 200f;
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(58, 211, 197, 0), 1f);
                newDust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.netMode != NetmodeID.Server)
            {
                UniverseUtils.Spawn_TrueNightsEdgeCyan(new ParticleOrchestraSettings
                {
                    PositionInWorld = target.Center,
                    IndexOfPlayerWhoInvokedThis = (byte)Main.myPlayer
                });
            }
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 14; i++)
            {
                int deathDust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(58, 211, 197, 0), 1.5f);  
                Dust deathDust2 = Main.dust[deathDust];
                deathDust2.velocity *= 4f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;

            Texture2D glowSphereTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = new Color(58, 211, 197, 0);
            Color drawColor = Projectile.GetAlpha(lightColor);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                
                drawColorGlow *= 0.5f;
                drawColor *= 0.5f;

                spriteBatch.Draw(glowSphereTexture, drawPos, null, drawColorGlow, Projectile.rotation, glowSphereTexture.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                spriteBatch.Draw(texture, drawPos, null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);

            }            

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White with { A = 0 }, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }
    }
}
