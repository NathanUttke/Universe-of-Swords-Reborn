using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class BlackOre : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		dust.velocity *= 0.2f;
		dust.noGravity = true;
		dust.noLight = true;
		dust.scale *= 3f;
	}

	public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;
		dust.rotation += dust.velocity.X * 0.5f;
		dust.scale *= 0.9f;
		if (dust.scale < 0.5f)
		{
			dust.active = false;
		}
		return false;
	}
}
