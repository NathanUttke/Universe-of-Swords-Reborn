using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class GlowDust : ModDust
{
    public override string Texture => "UniverseofSwordsMod/Assets/GlowDust";
    public override void OnSpawn(Dust dust)
    {
        dust.velocity *= 0.6f;
        dust.noGravity = true;
        dust.noLight = true;
        dust.scale *= 1f;
        dust.frame = new Rectangle(0, 0, 128, 128);
        dust.noLightEmittence = true;
    }

    public override bool Update(Dust dust)
    {
        dust.position += dust.velocity;
        dust.rotation += dust.velocity.X * 0.2f;
        dust.scale *= 0.9f;
        if (dust.scale < 0.1f)
        {
            dust.active = false;
        }
        return false;
    }

    public override bool PreDraw(Dust dust)
    {
        Color dustColor = Color.Orange;
        dustColor.A = 0;

        Main.spriteBatch.Draw(Texture2D.Value, dust.position - Main.screenPosition, dust.frame, dustColor, dust.rotation, new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0);
        return false;
    }
}
