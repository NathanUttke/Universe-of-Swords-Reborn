using Terraria.Audio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class FrozenCrystallusProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 14;

            Projectile.scale = 1.25f;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 2;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;

            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(2))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Frost);
                dust.noGravity = true;
                dust.scale = 1.1f;
            }
        }

        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 10; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Frost, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Frost, Projectile.oldVelocity.X * 0.10f, Projectile.oldVelocity.Y * 0.10f);
            }
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
        }
		
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.Frostburn))
            {
                target.AddBuff(BuffID.Frostburn, 400);
            }
        }
    }
}