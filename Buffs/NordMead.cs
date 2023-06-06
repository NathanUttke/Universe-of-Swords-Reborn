using Terraria;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Buffs;

public class NordMead : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Nord Mead");
		Description.SetDefault("'When we raise our flagon to another dead dragon, there is just one drink we need!'\nReduced defense");
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetCritChance(DamageClass.Generic) += 2;
		player.GetDamage(DamageClass.Melee) += 0.1f;
		player.GetAttackSpeed(DamageClass.Melee) += 0.05f;
		player.endurance += 0.25f;
		player.statDefense -= 6;
	}
}
