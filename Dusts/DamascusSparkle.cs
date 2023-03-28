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
		dust.scale *= 2f;
		dust.alpha = 100;
	}

	public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;
		dust.rotation += dust.velocity.X * 0.2f;
		dust.scale *= 0.95f;
		if (dust.scale < 0.5f)
		{
			dust.active = false;
		}
		return false;
	}
}
