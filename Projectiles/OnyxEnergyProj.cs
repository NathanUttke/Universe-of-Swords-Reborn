using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class OnyxEnergyProj : SwingEnergySwordProj
    {
        public override Color DustColor1 => Color.Magenta;
        public override Color DustColor2 => Color.HotPink;

        public override Color BackDarkColor => Color.DarkSlateBlue with { A = 180 };
        public override Color MiddleMediumColor => new(255, 100, 255);
        public override Color FrontLightColor => Color.MediumPurple;

        public override float ScaleAdder => 0.75f;
        public override float ScaleMulti => base.ScaleMulti;


        public override void AI()
        {
            base.AI();
            GenerateDust();
        }
    }
}
