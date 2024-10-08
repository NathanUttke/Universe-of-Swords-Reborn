using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Utilities;
using Terraria.ID;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheUniverseProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(42);
            Projectile.tileCollide = false;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 2;
            Projectile.scale = 1f;            
            Projectile.light = 0.4f;
            Projectile.timeLeft = 2000;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 20;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(Utils.SelectRandom(Main.rand, BuffID.Ichor, BuffID.Venom, BuffID.Weak, BuffID.DryadsWardDebuff, BuffID.CursedInferno, BuffID.Bleeding, BuffID.Oiled), 400);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(target.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Main.DiscoColor, Scale: 1f);
                dust.position = target.Center;
                dust.velocity *= 4f;
            }
        }

        public override void AI()
        {
            Projectile.frame = (int)Projectile.ai[0];
            Projectile.alpha += 3;
            if (Projectile.alpha > 255) 
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }

            Lighting.AddLight(Projectile.Center, Main.DiscoColor.ToVector3());

            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Main.DiscoColor with { A = 0 }, Scale: 0.5f);
                dust.velocity *= 0.5f;
            }

            float detectRadiusMax = 300f;
            float projSpeed = 16f;

            Projectile.rotation += 0.1f * (Projectile.frame + 1) * Projectile.direction;

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
            Color defaultColor = Main.DiscoColor with { A = 0 } * Projectile.Opacity;

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/SOTUV2Glow");

            int frameHeight = texture.Height / Main.projFrames[Type];
            int frameY = Projectile.frame * frameHeight;
            Rectangle sourceRectangle = new(0, frameY, texture.Width, frameHeight);

            Vector2 drawOrigin = sourceRectangle.Size() / 2f;
            Vector2 drawnOriginGlow = glowSphere.Size() / 2f;
            
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, defaultColor * 0.5f, Projectile.rotation, drawnOriginGlow, Projectile.scale * 2f, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, defaultColor, Projectile.rotation, drawOrigin, Projectile.scale * 1.125f, SpriteEffects.None, 0);  
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, defaultColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);  

            return false;
        }
    }
}
