using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;

namespace UniverseOfSwordsMod.Projectiles
{    
    public class SwordOfTheMultiverseProjectile : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Items/Weapons/SwordOfTheMultiverseNew";
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
            Projectile.light = 0.5f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;            
        }

        public override void AI()
        {
            base.AI();
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
            Projectile.rotation += 0.25f;            
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
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Purple;            


            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);

                Color color = Lighting.GetColor((int)(Projectile.position.X + (double)Projectile.width / 2) / 16, (int)((Projectile.position.Y + Projectile.height * 0.5) / 16.0));
                color = Projectile.GetAlpha(color);
                float multValue = 5 - j;
                color *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, MathHelper.Lerp(Projectile.scale, 1f, j / 15f), SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);

            drawColorGlow.A = 0;
            Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 2f + Projectile.scale, SpriteEffects.None, 0);
            DrawTrail(Projectile);

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
