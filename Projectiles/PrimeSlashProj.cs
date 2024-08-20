using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class PrimeSlashProj : SwingEnergySwordProj
    {
        public override float ScaleAdder => 1f;
        public override float ScaleMulti => 1f;

        public override Color BackDarkColor => new(128, 0, 0, 128);
        public override Color MiddleMediumColor => new(232, 60, 162);
        public override Color FrontLightColor => new(255, 128, 128);

        public override void AI()
        {
            base.AI();
            GenerateDust();
        }
    }
}
