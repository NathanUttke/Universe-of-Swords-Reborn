using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;
using UniverseOfSwordsMod.Utilities;
using Terraria.GameContent.Drawing;

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
            Projectile.penetrate = -1;
            Projectile.timeLeft = 150;
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
                Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Cyan, 0f, 0f, 100, default, 0.75f);
                newDust.rotation += 0.05f;
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

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Texture2D glowSphereTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Cyan;
            drawColorGlow.A = 0;            

            spriteBatch.Draw(glowSphereTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphereTexture.Width / 2, glowSphereTexture.Height / 2), 0.75f, SpriteEffects.None, 0);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);


                Color color = Projectile.GetAlpha(lightColor);
                color *= 0.75f;

                spriteBatch.Draw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, 0.75f - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);

            }            

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            return false;
        }
    }
}
