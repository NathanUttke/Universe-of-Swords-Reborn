using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Utilities;
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
            Projectile.penetrate = 2;
            Projectile.alpha = 0;
            Projectile.scale = 1f;            
            Projectile.light = 0.4f;
            Projectile.timeLeft = 2000;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(Utils.SelectRandom(Main.rand, BuffID.Ichor, BuffID.Venom, BuffID.Weak, BuffID.DryadsWardDebuff, BuffID.CursedInferno, BuffID.Bleeding), 300);
            ParticleOrchestrator.RequestParticleSpawn(true, ParticleOrchestraType.ShimmerTownNPCSend, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center,                

            }, Projectile.owner);
        }

        public override void AI()
        {
            Projectile.alpha += 3;
            if (Projectile.alpha > 255) 
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }

            float detectRadiusMax = 500f;
            float projSpeed = 16f;

            NPC closestNPC = UniverseUtils.FindClosestNPC(detectRadiusMax, Projectile.Center);
            if (closestNPC is null)
            {
                return;
            }
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.05f);
        }

        public override Color? GetAlpha(Color lightColor) => Color.White with { A = 0 } * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/SOTUV2Glow");

            Vector2 drawOrigin = texture.Size() / 2f;
            Vector2 drawnOriginGlow = glowSphere.Size() / 2f;
            
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, defaultColor * 0.75f, Projectile.rotation, drawnOriginGlow, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, defaultColor, Projectile.rotation + (float)Main.timeForVisualEffects * 0.5f * Projectile.direction, drawOrigin, Projectile.scale, SpriteEffects.None, 0);  

            return false;
        }
    }
}
