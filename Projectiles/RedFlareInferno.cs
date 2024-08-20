using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class RedFlareInferno : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.BeeArrow}"; 
        public override void SetDefaults()
        {
            Projectile.Size = new(64);
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 50;
        }

        public override void AI()
        {
            for (int i = 0; i < 6; i++) 
            {
                Vector2 newVelocity = Vector2.Normalize(Utils.RandomVector2(Main.rand, -100f, 100f)) * Main.rand.Next(2, 5);
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.Red);
                dust.noGravity = true;
                dust.position = Projectile.Center;
                dust.velocity = newVelocity;
            }
        }
    }
}
