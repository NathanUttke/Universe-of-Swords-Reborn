using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class EmperorBlaze : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		dust.velocity *= 0.75f;
		dust.noGravity = true;
		dust.noLight = true;
		dust.scale *= 1.5f;
	}
	public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;
		dust.rotation += dust.velocity.X * 0.2f;
		dust.scale *= 0.8f;
		if (dust.scale < 0.5f)
		{
			dust.active = false;
		}
		return false;
	}
}
