using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class FlyingSlash : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.SuperStarSlash}";
        public override void SetDefaults() 
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 152;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f * Main.rand.Next(30) * 0.01f;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 10 * Projectile.MaxUpdates;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 10;
            AIType = ProjectileID.SuperStarSlash;
        }

        public override void AI()
        {
            base.AI();
        }
    }
}
