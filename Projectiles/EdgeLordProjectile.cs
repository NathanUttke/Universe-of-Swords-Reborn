using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;
using static Terraria.ModLoader.PlayerDrawLayer;
using log4net.Util;
using Terraria.Graphics;

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
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            Projectile.alpha = 100;
        }
        public override void AI()
        {
            base.AI();
            if (Projectile.velocity.X < 0f)
            {
                Projectile.spriteDirection = -1;
            }
            Projectile.rotation += Projectile.direction * 0.05f;
            Projectile.rotation += Projectile.direction * 0.5f * (Projectile.timeLeft / 180f);
            Projectile.velocity *= 0.96f;

            for(int i = 0; i < 2; i++)
            {
                Dust newDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100)];
                newDust.noGravity = true;
            }
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            if (Main.rand.NextBool(3) && !NPCID.Sets.CountsAsCritter[target.type] && target.type != NPCID.TargetDummy)
            {
                float newDamage = Main.rand.Next(1, 5);
                if ((int)newDamage != 0 && !(Main.player[Main.myPlayer].lifeSteal <= 0f))
                {
                    Main.player[Main.myPlayer].lifeSteal -= newDamage;
                    int num2 = Projectile.owner;
                    Projectile.NewProjectile(Projectile.GetSource_OnHit(target), target.Center.X, target.Center.Y, 0f, 0f, ProjectileID.VampireHeal, 0, 0f, Projectile.owner, num2, newDamage);
                }
            }
        }

        public override void Kill(int timeLeft)
        {
            Projectile.alpha += 5;
        }

        public override Color? GetAlpha(Color lightColor) => new Color(253, 122, 122, 0) * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Red;

            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 2f, SpriteEffects.None, 0);

            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
            Vector2 origin = sourceRectangle.Size() / 2f;            
            
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), sourceRectangle, Color.White, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);
            return false;
        }
    }
}
