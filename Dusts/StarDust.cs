using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

        public override bool PreDraw(Dust dust)
        {
            float opacity = 1f - dust.alpha / 255f;
            Color drawColor = Lighting.GetColor((int)(dust.position.X + 4) / 16, (int)(dust.position.Y + 4) / 16);
            Main.spriteBatch.Draw(Texture2D.Value, dust.position - Main.screenPosition, dust.frame, dust.color with { A = 0 } * opacity, dust.rotation, dust.frame.Size() / 2, 0.5f * dust.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
