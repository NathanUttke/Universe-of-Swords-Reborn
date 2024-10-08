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
        dust.rotation += 0.25f;
        dust.scale *= 0.9f;
        if (dust.scale < 0.125f)
        {
            dust.active = false;
        }
        return false;
    }

    public override bool PreDraw(Dust dust)
    {
        Color skullColor = Color.White with { A = 0 };
        Main.spriteBatch.Draw(Texture2D.Value, dust.position - Main.screenPosition, dust.frame, skullColor, dust.rotation, dust.frame.Size() / 2, dust.scale, SpriteEffects.None, 0);
        return false;
    }
}
