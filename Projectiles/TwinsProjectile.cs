﻿using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Projectile.timeLeft = 60;
        }

        public override void AI()
        {
            Vector2 vector9 = new(8f, 10f);

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

            Vector2 dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + MathHelper.Pi) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
            Dust redDust = Dust.NewDustDirect(Projectile.Center, 0, 0, DustID.Clentaminator_Green, Alpha: 160, newColor: Color.White with { A = 0 });
            redDust.scale = 1.25f;
            redDust.noGravity = true;
            redDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
            redDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 16f - redDust.position) * 2f + Projectile.velocity * 2f;

            Dust greenDust = Dust.NewDustDirect(Projectile.Center, 0, 0, DustID.Clentaminator_Red, Alpha:160, newColor:Color.White with { A = 0 }, Scale:1.25f);
            dustRotationWave = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * (MathHelper.PiOver4 / 6f) + MathHelper.TwoPi) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
            greenDust.noGravity = true;
            greenDust.position = Projectile.Center + dustRotationWave + Projectile.velocity * 2f;
            greenDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 16f - greenDust.position) * 2f + Projectile.velocity * 2f;
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust deathDust = Dust.NewDustDirect(Projectile.position + Projectile.velocity, 0, 0, DustID.Clentaminator_Green, Projectile.velocity.X, Projectile.velocity.Y, 100, Scale:1.25f);                
                deathDust.noGravity = true;
                Dust deathDust2 = Dust.NewDustDirect(Projectile.position + Projectile.velocity, 0, 0, DustID.Clentaminator_Red, Projectile.velocity.X, Projectile.velocity.Y, 100, Scale:1.25f);
                deathDust2.noGravity = true;
            }
        }
    }
}
