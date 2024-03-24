using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class UnicornHornProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {                     
            Projectile.Size = new(12);
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
        }
        public override void AI()
        {         
            Projectile.velocity.Y += 0.1f;
        }
    }
}
