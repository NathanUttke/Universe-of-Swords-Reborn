using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Utilities;

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
            Projectile.alpha = 127;
            Projectile.scale = Main.rand.NextFloat(0.75f, 1.5f);            
            Projectile.light = 0.5f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.ShimmerTownNPCSend, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,                

            }, Projectile.owner);
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

            float detectRadiusMax = 400f;
            float projSpeed = 20f;

            NPC closestNPC = UniverseUtils.FindClosestNPC(detectRadiusMax, Projectile.Center);
            if (closestNPC == null)
            {
                return;
            }
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.1f);
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/SOTUV2Glow");

            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            Vector2 drawnOriginGlow = new(glowSphere.Width / 2, glowSphere.Height / 2);

            defaultColor.A = 0;
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, defaultColor, Projectile.rotation, drawnOriginGlow, Projectile.scale * 2f, SpriteEffects.None, 0);
            defaultColor.A = 127;
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);  

            return false;
        }
    }
}
