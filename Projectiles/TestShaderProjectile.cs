using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class TestShaderProjectile : ModProjectile
    {
        public override string Texture => "UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 30;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 27;
            Projectile.height = 27;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.8f;
            Projectile.penetrate = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 60;
        }

        private static readonly VertexStrip vertexStrip = new();

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 12; i++)
            {
                int deathDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 0, default, 1f);
                Main.dust[deathDust].noGravity = true;
                Dust deathDust2 = Main.dust[deathDust];
                deathDust2.velocity *= 3f;
            }
        }

        public override void AI()
        {
            Projectile.velocity *= 0.98f;
        }


        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Color drawColorExtra = Color.SkyBlue with { A = 0 };
            Vector2 origin = glowTexture.Size() / 2f;

            MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
            //MiscShaderData miscShaderData = GameShaders.Misc["GalacticShader"];
            //miscShaderData.UseImage0($"Images/Extra_{ExtrasID.RainbowRodTrailShape}");

            //Main.spriteBatch.End();
            //Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            miscShaderData.UseImage2($"Images/Extra_{ExtrasID.RainbowRodTrailShape}");
            miscShaderData.UseSaturation(-0.5f);
            miscShaderData.UseOpacity(2.25f);

            miscShaderData.Apply();

            vertexStrip.PrepareStrip(Projectile.oldPos, Projectile.oldRot, StripColors, StripWidth, -Main.screenPosition + Projectile.Size / 2f, 30);
            vertexStrip.DrawTrail();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();

            //Main.spriteBatch.End();
            //Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            SpriteBatch spriteBatch = Main.spriteBatch;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);

                drawColorExtra *= 0.75f;
                
                spriteBatch.Draw(glowTexture, drawPos, null, drawColorExtra, Projectile.rotation, origin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(glowTexture, Projectile.oldPos[1] + Projectile.Size / 2f - Main.screenPosition, null, Color.White with { A = 0 }, Projectile.rotation, origin, Projectile.scale / 2f, spriteEffects, 1);
            return false;
        }

        private Color StripColors(float progressOnStrip)
        {
            return Color.Lerp(Color.SkyBlue with { A = 0 }, Color.Cyan with { A = 0 }, progressOnStrip);
        }

        private float StripWidth(float progressOnStrip)
        {
            float num = 1f;
            float lerpValue = Utils.GetLerpValue(0f, 0.2f, progressOnStrip, clamped: true);
            num *= 1f - (1f - lerpValue) * (1f - lerpValue);
            return MathHelper.Lerp(0f, 32f, num) * num;
        }
    }
}