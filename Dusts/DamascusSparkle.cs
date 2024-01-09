using Microsoft.Xna.Framework;
using Terraria;
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
		dust.alpha = 100;
		dust.frame = new Rectangle(0, 0, 22, 22);
	}

    public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;
		//dust.rotation += dust.velocity.X * 0.01f;
		dust.scale *= 0.95f;
		if (dust.scale < 0.25f)
		{
			dust.active = false;
		}
		return false;
	}
}
