using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Buffs;

public class Skooma : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skooma");
		Description.SetDefault("Major improvements to movement speed");
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.moveSpeed += 0.25f;
		player.maxRunSpeed += 1.35f;
		player.jumpBoost = true;
		player.jumpSpeedBoost += 1.35f;
		player.extraFall += 10;
	}
}
