using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheUniverseV2Projectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 42;
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.alpha = 0;
            Projectile.scale = Main.rand.NextFloat(0.75f, 1.35f);
            Projectile.Opacity = 0.5f;
            Projectile.light = 0.4f;
        }
        public override void AI()
        {
            base.AI();
            Projectile.alpha += 1;
            if (Projectile.alpha > 255) 
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }

            float detectRadiusMax = 300f;
            float projSpeed = 20f;

            NPC closestNPC = FindClosestNPC(detectRadiusMax);
            if (closestNPC == null)
            {
                return;
            }
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;

        }
        public NPC FindClosestNPC(float maxDistance)
        {
            NPC closestNPC = null;

            float sqrMaxDistance = maxDistance * maxDistance;
            for (int j = 0; j < Main.maxNPCs; j++)
            {
                NPC target = Main.npc[j];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);
                    if (sqrDistanceToTarget < sqrMaxDistance)
                    {
                        sqrMaxDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }

            }
            return closestNPC;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);
            defaultColor.A = 0;

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/SOTUV2Glow");

            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            Vector2 drawnOriginGlow = new(glowSphere.Width / 2, glowSphere.Height / 2);

            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, defaultColor, Projectile.rotation, drawnOriginGlow, Projectile.scale * 2f, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, defaultColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);  

            return false;
        }
    }
}
