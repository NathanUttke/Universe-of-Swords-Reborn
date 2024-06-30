using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class ScarletRedBolt : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.RubyBolt}";
        public override void SetDefaults()
        {
            Projectile.alpha = 255;
            Projectile.Size = new(12);
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 100;
            Projectile.friendly = true;
            Projectile.noEnchantmentVisuals = true;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 18;
        }

        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                Dust redDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.IndianRed, 0.5f);
                redDust.velocity *= 0.25f;
                //redDust.position = Projectile.Center;
                redDust.velocity += Projectile.velocity * 0.2f;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f, 0, Color.IndianRed, 0.5f);
            }
        }
    }
}
