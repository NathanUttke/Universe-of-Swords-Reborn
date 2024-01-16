using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts
{
    internal class StarDust : ModDust
    {
        public override string Texture => "UniverseOfSwordsMod/Assets/Extra_Light";
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.6f;
            dust.noGravity = true;
            dust.scale *= 0.5f;
            dust.frame = new Rectangle(0, 0, 72, 72);
            dust.noLightEmittence = false;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale *= 0.9f;
            if (dust.scale < 0.01f)
            {
                dust.active = false;
            }
            return false;
        }

        public override Color? GetAlpha(Dust dust, Color lightColor)
        {
            dust.color.A = 0;
            return dust.color;
        }
    }
}
