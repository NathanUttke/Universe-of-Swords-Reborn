using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class EdgeLordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.Size = new(128);
            Projectile.friendly = true;
            Projectile.aiStyle = -1;
            Projectile.timeLeft = 200;
            Projectile.light = 0.5f;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.ArmorPenetration = 20;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            Projectile.alpha = 0;
        }

        public override void AI()
        {           
            Projectile.rotation += Projectile.direction * 0.5f * (Projectile.timeLeft / 180f);
            Projectile.velocity *= 0.96f;
            Projectile.alpha += 1;

            if (Projectile.alpha > 255)
            {
                Projectile.alpha = 255;
                Projectile.Kill();
            }

            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Alpha: 100, newColor: Color.Red);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Red with { A = 0 } * Projectile.Opacity;
            Color drawColorEdge = Color.White with { A = 0 } * Projectile.Opacity;

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = sourceRectangle.Size() / 2f;

            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, 2f, SpriteEffects.None, 0);    
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColorEdge, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
