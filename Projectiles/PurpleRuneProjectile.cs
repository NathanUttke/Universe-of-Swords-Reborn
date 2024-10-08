using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{       
    public class PurpleRuneProjectile : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Projectiles/InvisibleProj";

        public override void SetDefaults()
        {
            Projectile.Size = new(40);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 4;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 28;
            Projectile.timeLeft = 200;
        }

        public override void AI()
        {
            Projectile.velocity *= 0.95f;
            Lighting.AddLight(Projectile.Center, Color.BlueViolet.ToVector3() * 2f);
            for (int i = 0; i < 16; i++)
            {
                Vector2 spinPoint = Vector2.UnitX.RotatedBy(i * Projectile.ai[1] * MathHelper.TwoPi / 16f * i * Projectile.ai[0]);
                Dust dust = Dust.NewDustPerfect(Projectile.position, ModContent.DustType<GlowDust>(), Vector2.Zero, newColor:Color.BlueViolet, Scale:1f);
                dust.velocity = spinPoint * 2f;
                dust.position = Projectile.Center - Projectile.velocity / 10f * i;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.ShadowFlame, 300);
        }
    }
}
