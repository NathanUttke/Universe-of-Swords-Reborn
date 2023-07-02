using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class GrandPianoProjectile : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Items/Weapons/GrandPiano";
        public override void SetDefaults()
        {
            Projectile.width = Projectile.height = 142;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.light = 0.33f;
            Projectile.aiStyle = ProjAIStyleID.Boomerang;
            AIType = ProjectileID.PaladinsHammerFriendly;
        }
    }
}
