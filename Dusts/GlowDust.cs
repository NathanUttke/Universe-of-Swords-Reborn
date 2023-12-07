using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class GlowDust : ModDust
{   
    public override void OnSpawn(Dust dust)
    {
        dust.velocity *= 0.6f;
        dust.noGravity = true;        
        dust.scale *= 0.5f;
        dust.frame = new Rectangle(0, 0, 128, 128);
        dust.noLightEmittence = false;
    }

    public override bool Update(Dust dust)
    {
        dust.position += dust.velocity;
        dust.rotation += dust.velocity.X * 0.2f;
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
