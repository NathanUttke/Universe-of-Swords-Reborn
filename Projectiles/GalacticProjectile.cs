using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GalacticProjectile : ModProjectile
    {
        public override string Texture => "UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 0;                     
        }
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 54;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.75f;
            Projectile.scale = 1f;
            Projectile.penetrate = 1; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 90;            
        }

        private static readonly VertexStrip vertexStrip = new();

        public override void AI()
        {
            float projSpeed = 8f;

            Projectile.velocity *= 0.97f;

            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 2f);
            }

            NPC closestNPC = UniverseUtils.FindClosestNPC(400f, Projectile.position);
            if (closestNPC == null) 
            {
                return;
            }
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.12f);
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 12; i++)
            {
                int deathDust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 2f);
                Main.dust[deathDust].noGravity = true;
                Dust deathDust2 = Main.dust[deathDust];
                deathDust2.velocity *= 3f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);    
        
        public override bool PreDraw(ref Color lightColor)
        {
            /*MiscShaderData miscShaderData = GameShaders.Misc["MagicMissile"];
            MiscShaderData miscShaderData = GameShaders.Misc["GalacticShader"];          
            miscShaderData.UseColor(Color.Cyan);
            miscShaderData.UseImage0($"Images/Extra_{ExtrasID.RainbowRodTrailShape}");
            miscShaderData.UseOpacity(2.25f);
            miscShaderData.Apply();

            vertexStrip.PrepareStrip(Projectile.oldPos, Projectile.oldRot, StripColors, StripWidth, -Main.screenPosition + Projectile.Size / 2f, 30, false);
            vertexStrip.DrawTrail();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();*/

            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D galacTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowThing_Cyan");
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Vector2 drawOriginStar = glowTexture.Size() / 2f;
            Vector2 drawOriginThing = galacTexture.Size() / 2f;
            Color drawColorExtra = Color.Cyan with { A = 0 };            
            Color drawColorGalac = Projectile.GetAlpha(lightColor);
            Color drawColor = Projectile.GetAlpha(lightColor);


            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);

                drawColorExtra *= 0.75f;
                drawColorGalac *= 0.75f;

                spriteBatch.Draw(galacTexture, drawPos, null, drawColorGalac, Projectile.rotation, drawOriginThing, Projectile.scale - j / (float) Projectile.oldPos.Length, spriteEffects, 0);
                spriteBatch.Draw(glowTexture, drawPos, null, drawColorExtra, Projectile.rotation, drawOriginStar, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(galacTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation + Main.GlobalTimeWrappedHourly * 3f, drawOriginThing, 1.5f, spriteEffects, 1);
            return false;
        }

        private Color StripColors(float progressOnStrip)
        {
            return Color.Lerp(Color.White, Color.LightCyan, 0.25f);
        }

        private float StripWidth(float progressOnStrip)
        {
            float num = 1f;
            float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, clamped: true);
            num *= 1f - (1f - lerpValue) * (1f - lerpValue);
            return MathHelper.Lerp(0, 40f, num);
        }

    }
}
