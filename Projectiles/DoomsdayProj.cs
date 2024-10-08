using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class DoomsdayProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.DD2FlameBurstTowerT1Shot}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 15;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(16);
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 50;
            Projectile.alpha = 0;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 100, Color.Orange, 0.5f);
            fireDust.velocity *= 0.6f;

            Projectile.velocity.Y += 0.4f;
            Projectile.ai[0]++;

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                for (int i = 0; i < 40; i++)
                {
                    Dust fireDust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Alpha:100, newColor:Color.Orange);
                    fireDust2.velocity *= 4f;
                    fireDust2.scale *= 1.25f;
                }
            }
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 300);
            target.AddBuff(BuffID.Weak, 300);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 40; i++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, Color.Orange, 1f);
                fireDust.velocity *= 4f;
                fireDust.scale *= 1.5f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");

            Color drawColorTrail = Color.White;
            Color drawColorSphere = Color.Yellow with { A = 0 };

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
                drawColorTrail *= 0.8f;

                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail, Projectile.rotation, Projectile.Size / 2, Projectile.scale, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail with { A = 0 } * 0.25f, Projectile.rotation, Projectile.Size / 2, Projectile.scale * 1.25f, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White with { A = 0 } * 0.25f, Projectile.rotation, Projectile.Size / 2, Projectile.scale, SpriteEffects.None, 0);


            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] + Projectile.Size / 2 - Main.screenPosition;
                drawColorSphere *= 0.75f;

                Main.EntitySpriteDraw(glowSphere, drawPos, null, drawColorSphere * 0.4f, Projectile.rotation, glowSphere.Size() / 2, Projectile.scale * 0.4f, SpriteEffects.None, 0);
            }

            return false;
        }
    }
}
