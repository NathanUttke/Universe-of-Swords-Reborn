using Terraria;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace UniverseOfSwordsMod.Dusts;

public class EmperorBlaze : ModDust
{
    public override void OnSpawn(Dust dust)
	{
		if (dust.velocity.Y > 0f) 
		{
			dust.velocity.Y = -dust.velocity.Y;
		}
		dust.velocity.Y *= 0.75f;
		dust.noGravity = true;
		dust.scale = 0.75f;
		dust.noLight = true;	
	}

	public override bool Update(Dust dust)
	{
        float velocityX = MathHelper.Clamp(dust.velocity.X, 1f, 20f);

        dust.position.Y += dust.velocity.Y;
		dust.position.X += (float)Math.Sin(Main.timeForVisualEffects / 240 * velocityX * 2f);
		dust.rotation = dust.velocity.ToRotation();	
		if (dust.scale < 1.15f)
		{
            dust.scale += 0.003f;
        }
		else
		{
            dust.alpha += 48;
            if (dust.alpha >= 255)
            {
                dust.active = false;
            }
        }
		return false;
	}

	public override Color? GetAlpha(Dust dust, Color lightColor) => dust.color * (1f - dust.alpha / 255f);
}
