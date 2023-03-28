using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Dusts;

public class NatureBlade : ModDust
{
	public override void OnSpawn(Dust dust)
	{
		dust.velocity *= 0.5f;
		dust.noGravity = true;
		dust.noLight = true;
		dust.frame = new Rectangle(0, 0, 16, 16);
	}
	public override bool Update(Dust dust)
	{
		dust.position += dust.velocity;
		dust.rotation = dust.velocity.ToRotation();
		dust.scale -= 0.025f;
		dust.alpha = 127;
		if (dust.scale < 0.75f)
		{
			dust.active = false;
		}
		return false;
	}
}
