using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class DamascusSparkle : ModDust
{
    public override void OnSpawn(Dust dust)
	{
		dust.velocity *= 0.5f;
		dust.noGravity = true;
		dust.noLight = true;
		dust.scale *= 1.25f;		
		dust.frame = new Rectangle(0, 0, 22, 22);
	}

    public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;		
		dust.scale *= 0.94f;
		if (dust.scale < 0.2f)
		{
			dust.active = false;
		}
		return false;
	}
    public override bool PreDraw(Dust dust)
    {
		Texture2D texture = TextureAssets.Extra[ExtrasID.SharpTears].Value;

        Color drawColor = Lighting.GetColor((int)(dust.position.X + 4) / 16, (int)(dust.position.Y + 4) / 16);
        Main.spriteBatch.Draw(texture, dust.position - Main.screenPosition, null, new Color(103, 165, 216, 0), dust.rotation, new Vector2(36f, 36f), dust.scale, SpriteEffects.None, 0);

        Main.spriteBatch.Draw(Texture2D.Value, dust.position - Main.screenPosition, dust.frame, Color.White with { A = 0 }, dust.rotation, new Vector2(11f, 11f), dust.scale, SpriteEffects.None, 0);
        return false;
    }
}
