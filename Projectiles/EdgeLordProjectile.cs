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
            Projectile.width = 128;
            Projectile.height = 128;
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
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, Color.Red with { A = 0 });
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        { 
            if (Main.rand.NextBool(3) && !NPCID.Sets.CountsAsCritter[target.type] && target.type != NPCID.TargetDummy)
            {
                float stealDamage = Main.rand.Next(1, 5);
                if ((int)stealDamage != 0 && !(Main.player[Projectile.owner].lifeSteal <= 0f))
                {
                    Main.player[Projectile.owner].lifeSteal -= stealDamage;
                    int playerOwner = Projectile.owner;
                    Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, playerOwner, playerOwner, stealDamage);
                }
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Red;
            drawColorGlow.A = 0;
            Color drawColorEdge = Projectile.GetAlpha(lightColor);
            drawColorGlow.A = 0;

            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, 2f, SpriteEffects.None, 0);

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = sourceRectangle.Size() / 2f;            
            
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, drawColorEdge, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
