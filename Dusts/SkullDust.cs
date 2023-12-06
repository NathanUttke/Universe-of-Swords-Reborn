using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class SkullDust : ModDust
{
    public override void OnSpawn(Dust dust)
    {
        dust.velocity *= 0.6f;
        dust.noGravity = true;
        dust.noLight = true;
        dust.scale *= 0.5f;
        dust.frame = new Rectangle(0, 0, 32, 32);
    }

    public override bool Update(Dust dust)
    {
        dust.position += dust.velocity;
        dust.rotation += dust.velocity.X * 0.1f;
        dust.scale *= 0.9f;
        if (dust.scale < 0.125f)
        {
            dust.active = false;
        }
        return false;
    }

    public override bool PreDraw(Dust dust)
    {
        Color skullColor = Color.White;
        skullColor.A = 0;
        Main.spriteBatch.Draw(Texture2D.Value, dust.position - Main.screenPosition, dust.frame, skullColor, dust.rotation, new Vector2(4f, 4f), dust.scale, SpriteEffects.None, 0);
        return false;
    }
}
