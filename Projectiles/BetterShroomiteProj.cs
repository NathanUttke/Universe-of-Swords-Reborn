using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class BetterShroomiteProj : SwingEnergySwordProj
    {
        public override Color BackDarkColor => new(63, 72, 204);
        public override Color MiddleMediumColor => new(0, 162, 232);
        public override Color FrontLightColor => new(153, 217, 234);

        public override Color DustColor1 => Color.Blue;
        public override Color DustColor2 => Color.SkyBlue;
    }
}
