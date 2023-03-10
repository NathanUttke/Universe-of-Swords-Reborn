using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Buffs;

public class MeleePower : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Melee Power");
		Description.SetDefault("Increased melee stats: 4% increased melee crit, 10% increased melee damage and 10% increased melee speed");
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetCritChance(DamageClass.Generic) += 4;
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.GetAttackSpeed(DamageClass.Melee) += 0.1f;
	}
}
