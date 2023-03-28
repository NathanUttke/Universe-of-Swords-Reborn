using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;

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
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.scale = Main.rand.NextFloat(0.75f, 1.35f);
            Projectile.Opacity = 0.5f;
            Projectile.light = 0.5f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 14;
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
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/SOTUV2Glow");

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;
            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, null, null, null, null, Main.GameViewMatrix.TransformationMatrix);

            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, defaultColor, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), Projectile.scale * 2f, SpriteEffects.None, 0);

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, defaultColor, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);

   

            return false;
        }
    }
}
