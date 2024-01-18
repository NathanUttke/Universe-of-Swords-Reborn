using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Common.GlobalProjectiles
{
    internal class GlobalProjectileTweaks : GlobalProjectile
    {
        public override void SetDefaults(Projectile entity)
        {
            if (entity.type == ProjectileID.SwordBeam)
            {
                entity.timeLeft = 40;
            }
        }
    }
}
