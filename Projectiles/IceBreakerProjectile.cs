using Terraria.ID;
using System.Diagnostics.Metrics;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class IceBreakerProjectile : ModProjectile
    {
        public override string Texture => "UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.aiStyle = 28;
            Projectile.alpha = 255;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.coldDamage = true;
            AIType = ProjectileID.IceBolt;
        }

        public override void AI()
        {
            base.AI();
        }

    }
}
