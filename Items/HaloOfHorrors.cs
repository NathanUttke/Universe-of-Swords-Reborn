using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class HaloOfHorrors : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("'The fearsome power of the Dungeon Guardian is now yours!'\n20 defense\n100% increased armor penetration\nIncreased health regeneration\nProvides ultimate health regeneration\n15% increased damage\nCurses the wearer with infinite Potion Sickness debuff\n30% decreased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(1, 0, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statDefense += 20;
		player.GetArmorPenetration(DamageClass.Generic) += 25;
		player.lifeRegen += 35;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.25f;
		player.statLifeMax2 += 100;
		player.GetDamage(DamageClass.Generic) += 0.15f;
		player.AddBuff(21, 2, true);
	}
}
