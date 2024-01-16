using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{    
    public class SwordOfTheMultiverseProjectileYoyo : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<SwordOfTheMultiverseNew>().Texture;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.width = 94;
            Projectile.height = 94;
            Projectile.scale = 2f;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;            
        }

        public override void AI()
        {
            base.AI();
            Lighting.AddLight(Projectile.Center, 1.5f, 1f, 1.5f);
            Player player = Main.player[Projectile.owner];

            if (Projectile.owner == Main.myPlayer && (!player.controlUseItem))
            {
                Projectile.Kill();
                return;
            }

            if (player.dead || !player.active)
            {
                Projectile.Kill();
                return;
            }

            player.heldProj = Projectile.whoAmI;
            player.itemTime = player.itemAnimation = 2;

            Projectile.position = Projectile.Center;
            Projectile.velocity = Vector2.Zero;
            Projectile.Center = Main.MouseWorld;
            Projectile.rotation += 0.15f;            
        }       
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
            {
                target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 800, true);
            }
        }

        public const int TotalIllusions = 1;

        public const int FramesPerImportantTrail = 60;

        private static readonly VertexStrip _vertexStrip = new();

        public Color ColorStart;

        public Color ColorEnd;

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Purple with { A = 0 };

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            DrawTrail(Projectile);

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);

                Color color = Lighting.GetColor((int)Projectile.Center.X / 16, (int)(Projectile.Center.Y / 16));
                color = Projectile.GetAlpha(color);
                float multValue = 5 - j;
                color *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation - MathHelper.PiOver4, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation - MathHelper.PiOver4, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            drawColorGlow.A = 0;
            
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, 2f + Projectile.scale, SpriteEffects.None, 0);
            
            return false;
        }

        public void DrawTrail(Projectile proj)
        {
            MiscShaderData miscShaderData = GameShaders.Misc["EmpressBlade"];
            miscShaderData.UseShaderSpecificData(new Vector4(1, 0, 0, 0.6f));            
            miscShaderData.Apply();
            _vertexStrip.PrepareStrip(proj.oldPos, proj.oldRot, StripColors, StripWidth, -Main.screenPosition + proj.Size / 2f, proj.oldPos.Length, includeBacksides: false);
            _vertexStrip.DrawTrail();
            Main.pixelShader.CurrentTechnique.Passes[0].Apply();
        }

        private Color StripColors(float progressOnStrip)
        {
            Color result = Color.Lerp(Color.HotPink, ColorEnd, Utils.GetLerpValue(0f, 0.7f, progressOnStrip, clamped: true)) * (1f - Utils.GetLerpValue(0f, 0.98f, progressOnStrip, clamped: true));
            result.A /= 2;
            return result;
        }

        private float StripWidth(float progressOnStrip)
        {
            return 74f * Projectile.scale;
        }

    }
}
