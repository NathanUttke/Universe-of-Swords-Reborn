using Terraria.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;
using System;
using System.Security.Cryptography.X509Certificates;
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
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.extraUpdates = 2;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.light = 0.5f;
        }

        public override void AI()
        {
            base.AI();
            Vector2 vector9 = new(8f, 10f);
            float dustScale = 1.25f;
            Projectile.alpha -= 40;
            if (Projectile.alpha < 0)
            {
                Projectile.alpha = 0;
            }

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                Projectile.localAI[0] = -Main.rand.Next(48);
            }
            else if (Projectile.ai[1] == 1f && Projectile.owner == Main.myPlayer)
            {
                int num35 = -1;
                float num36 = 250f;
                if (num36 < 20f)
                {
                    Projectile.Kill();
                    return;
                }
                if (num35 != -1)
                {
                    Projectile.ai[1] = 5f + 1f;
                    Projectile.ai[0] = num35;
                    Projectile.netUpdate = true;
                }
            }
            if (Projectile.ai[1] >= 1f && Projectile.ai[1] < 5f)
            {
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] == 5f)
                {
                    Projectile.ai[1] = 1f;
                }
            }

            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.localAI[0] += 1f;
            if (Projectile.localAI[0] == 48f)
            {
                Projectile.localAI[0] = 0f;
            }
            else if (Projectile.alpha == 0)
            {            
                
                Vector2 vector11 = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * ((float)Math.PI / 24f) + 1 * (float)Math.PI) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
                Dust redDust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.Clentaminator_Green, 0f, 0f, 160)];
                redDust.scale = dustScale;
                redDust.noGravity = true;
                redDust.position = Projectile.Center + vector11 + Projectile.velocity * 2f;
                redDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 2f * 8f - redDust.position) * 2f + Projectile.velocity * 2f;
                Dust greenDust = Main.dust[Dust.NewDust(Projectile.Center, 0, 0, DustID.Clentaminator_Red, 0f, 0f, 160, default, dustScale)];
                vector11 = -Vector2.UnitY.RotatedBy(Projectile.localAI[0] * ((float)Math.PI / 24f) + 2 * (float)Math.PI) * vector9 - Projectile.rotation.ToRotationVector2() * 10f;
                greenDust.noGravity = true;
                greenDust.position = Projectile.Center + vector11 + Projectile.velocity * 2f;
                greenDust.velocity = Vector2.Normalize(Projectile.Center + Projectile.velocity * 2f * 8f - greenDust.position) * 2f + Projectile.velocity * 2f;

            }                       
        }
        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);
        }
    }
}
