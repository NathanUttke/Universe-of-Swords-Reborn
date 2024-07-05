using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles.Base;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles
{
    public class PrimeSlashProj : SwingEnergySwordProj
    {
        public override float ScaleAdder => 1f;
        public override float ScaleMulti => 1f;

        public override Color BackDarkColor => new Color(128, 0, 0, 128);
        public override Color MiddleMediumColor => new(232, 60, 162);
        public override Color FrontLightColor => new Color(255, 128, 128);

        public override void AI()
        {
            base.AI();
            GenerateDust();
        }
    }
}
