using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class ShaderProjectile : ModProjectile
    {
        public override string Texture => "UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 60;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.aiStyle = ProjAIStyleID.MagicMissile;
            Projectile.friendly = true;
            Projectile.light = 0.8f;
            Projectile.penetrate = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 60;
            AIType = ProjectileID.RainbowRodBullet;
        }

        private static readonly VertexStrip vertexStrip = new();

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 6; i++)
            {
                int deathDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, 0f, 0f, 0, default, 5f);
                Main.dust[deathDust].noGravity = true;
                Dust deathDust2 = Main.dust[deathDust];
                deathDust2.velocity *= 3f;
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {
            MiscShaderData miscShaderData = GameShaders.Misc["RainbowRod"];
            miscShaderData.UseSaturation(-0.5f);
            miscShaderData.UseOpacity(2.25f);
            miscShaderData.Apply();
            vertexStrip.PrepareStrip(Projectile.oldPos, Projectile.oldRot, StripColors, StripWidth, -Main.screenPosition + Projectile.Size / 2f, Projectile.oldPos.Length, false);
            //vertexStrip.PrepareStripWithProceduralPadding(Projectile.oldPos, Projectile.oldRot, StripColors, StripWidth, -Main.screenPosition + Projectile.Size / 2f);
            vertexStrip.DrawTrail();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();

            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D galacTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowThing_Cyan");

            Vector2 origin = new(galacTexture.Width / 2, galacTexture.Height / 2);

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(galacTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation + Main.GlobalTimeWrappedHourly * 2.25f, origin, 1.5f, spriteEffects, 1);
            return false;
        }

        private Color StripColors(float progressOnStrip)
        {
            return Color.Lerp(Color.White, new Color(133, 238, 245), 0.25f);
        }

        private float StripWidth(float progressOnStrip)
        {
            return Projectile.width * 1f * Utils.GetLerpValue(0.2f, 0f, progressOnStrip, true);
        }

    }
}
