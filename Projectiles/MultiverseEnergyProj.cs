using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class MultiverseEnergyProj : SwingEnergySwordProj
    {
        public override Color DustColor1 => Color.Purple;
        public override Color DustColor2 => Color.Magenta;

        public override Color BackDarkColor => Color.DarkBlue;
        public override Color MiddleMediumColor => base.MiddleMediumColor;

        public override Color FrontLightColor => base.FrontLightColor;

        public override float ScaleAdder => base.ScaleAdder;

        public override float ScaleMulti => base.ScaleMulti;
    }
}
