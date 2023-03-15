using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items;

public class HaloOfHorrors : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("'The fearsome power of the Dungeon Guardian is now yours!'\n100 defense\n100% increased armor penetration\nMaximum life increased by 2000\nProvides ultimate health regeneration\n15% increased damage\nCurses the wearer with infinite Potion Sickness debuff\n30% decreased melee speed");
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
		player.statDefense += 80;
		player.GetArmorPenetration(DamageClass.Generic) += 100;
		player.lifeRegen += 35;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.25f;
		player.statLifeMax2 += 500;
		player.GetDamage(DamageClass.Generic) += 0.15f;
		player.AddBuff(21, 2, true);
	}
}
