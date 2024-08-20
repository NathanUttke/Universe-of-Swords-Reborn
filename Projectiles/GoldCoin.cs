using Terraria.Audio;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles
{
    public class GoldCoin : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.GoldCoin}";

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.Size = new(4);
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.penetrate = 1;
            Projectile.alpha = 255;
            Projectile.timeLeft = 40;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            if (Projectile.alpha > 0)
            {
                Projectile.alpha -= 8;
            }

            if (Projectile.alpha >= 180)
            {
                return;
            }

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin);
                dust.noGravity = true;
                dust.velocity *= 0.3f;
                dust.position += Projectile.velocity / 20f * i;
            }
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.GoldCoin);
                dust.noGravity = true;
                dust.velocity -= Projectile.velocity * 0.5f;
            }
        }
    }
}
