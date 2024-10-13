using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class TwinsProjectile : ModProjectile
    {
        public override string Texture => $"UniverseOfSwordsMod/Projectiles/InvisibleProj";
        public override void SetDefaults()
        {
            Projectile.Size = new(25);
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.4f;
            Projectile.timeLeft = 120;
        }

        public override void AI()
        {
            Vector2 offset = new(8f, 10f);

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                Projectile.localAI[0] = -Main.rand.Next(48);
            }

            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] == 48f)
            {
                Projectile.localAI[0] = 0f;
            }

            for (int i = 0; i < 2; i++)
            {
                Vector2 dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + MathHelper.Pi) * offset - Projectile.rotation.ToRotationVector2() * 10f;
                Dust redDust = Dust.NewDustDirect(Projectile.Center, 0, 0, ModContent.DustType<GlowDust>(), Alpha: 0, newColor: Color.Red, Scale: 1.25f);
                redDust.noGravity = true;
                redDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
                redDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 16f - redDust.position) * 2f - Projectile.velocity / 2;

                Dust greenDust = Dust.NewDustDirect(Projectile.Center, 0, 0, ModContent.DustType<GlowDust>(), Alpha: 0, newColor: Color.Green, Scale: 1.25f);
                dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + MathHelper.TwoPi) * offset - Projectile.rotation.ToRotationVector2() * 10f;
                greenDust.noGravity = true;
                greenDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
                greenDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 16f - greenDust.position) * 2f - Projectile.velocity / 2;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust deathDust = Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Alpha: 0, newColor: Color.Green, Scale:1.25f);                
                deathDust.noGravity = true;
                Dust deathDust2 = Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Alpha: 0, newColor: Color.Red, Scale:1.25f);
                deathDust2.noGravity = true;
            }
        }
    }
}
