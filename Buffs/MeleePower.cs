using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Buffs;

public class MeleePower : ModBuff
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Melee Power");
		// Description.SetDefault("Minor improvements to melee stats");
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetCritChance(DamageClass.Generic) += 4;
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
	}
}
