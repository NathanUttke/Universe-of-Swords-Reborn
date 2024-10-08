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

namespace UniverseOfSwordsMod.Projectiles
{
    public class CosmoStormProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.MagicMissile}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(24);
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 250;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 30;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, Scale:1.25f);
                dust.noGravity = true;
                dust.velocity *= 0.5f;
                dust.position = Projectile.Center - Projectile.velocity / 20f * i;
            }

            Lighting.AddLight(Projectile.Center, Color.LightCyan.ToVector3());
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 30; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.SpectreStaff, newColor:Color.LightCyan, Scale: 1.25f);
                dust.noGravity = true;
                dust.velocity *= 2f;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            //Main.instance.LoadProjectile(ProjectileID.StardustJellyfishSmall);
            Texture2D texture = TextureAssets.Extra[46].Value;
            Vector2 drawOrigin = Vector2.UnitX * texture.Width / 2;
            Color trailColor = Color.White with { A = 0 };

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                trailColor *= 0.75f;
                Vector2 drawPos = Projectile.oldPos[j] + Projectile.Size / 2 - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

                Main.EntitySpriteDraw(texture, drawPos, null, trailColor, Projectile.rotation, drawOrigin, MathHelper.SmoothStep(Projectile.scale, 0f, j * 0.1f), SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White with { A = 0 } * 0.5f, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None);
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Color.White with { A = 0 } * 0.25f, Projectile.rotation, drawOrigin, Projectile.scale * 1.5f, SpriteEffects.None);
            return false;
        }
    }
}
