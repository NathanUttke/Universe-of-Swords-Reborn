using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class TwinsProjectile : ModProjectile
    {
        public override string Texture => $"UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetDefaults()
        {
            Projectile.width = 25;
            Projectile.height = 25;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.4f;
            Projectile.timeLeft = 60;
        }
        public override void AI()
        {
            Vector2 vector9 = new(8f, 10f);
            float dustScale = 1.25f;

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

            Vector2 dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + 1 * MathHelper.Pi) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
            Dust redDust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.Clentaminator_Green, 0f, 0f, 160, Color.White with { A = 0 })];
            redDust.scale = dustScale;
            redDust.noGravity = true;
            redDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
            redDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 2f * 8f - redDust.position) * 2f + Projectile.velocity * 2f;

            Dust greenDust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.Clentaminator_Red, 0f, 0f, 160, Color.White with { A = 0 }, dustScale)];
            dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + 2 * MathHelper.Pi) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
            greenDust.noGravity = true;
            greenDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
            greenDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 2f * 8f - greenDust.position) * 2f + Projectile.velocity * 2f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust terraDust = Dust.NewDustDirect(Projectile.position, 8, 8, DustID.Clentaminator_Green, Projectile.oldVelocity.X * 0.8f, Projectile.oldVelocity.Y * 0.8f, 100, default, 1.25f);                
                terraDust.noGravity = true;
                terraDust.velocity *= 0.5f;

                Dust terraDust2 = Dust.NewDustDirect(Projectile.position, 8, 8, DustID.Clentaminator_Red, Projectile.oldVelocity.X * 0.8f, Projectile.oldVelocity.Y * 0.8f, 100, default, 1.25f);
                terraDust2.noGravity = true;
                terraDust2.velocity *= 0.5f;
            }
        }
    }
}
