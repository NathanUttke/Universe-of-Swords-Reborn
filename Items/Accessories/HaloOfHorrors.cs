using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrors : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("15 defense\n25% increased armor penetration\nIncreased health regeneration\n15% increased damage\nCurses the wearer with infinite Potion Sickness debuff\n20% decreased melee speed");
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
		player.statDefense += 15;
		player.GetArmorPenetration(DamageClass.Generic) += 25;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.20f;
		player.statLifeMax2 += 25;
		player.GetDamage(DamageClass.Generic) += 0.15f;
		player.AddBuff(BuffID.RapidHealing, 100, true);
        player.AddBuff(BuffID.Rabies, 300, true);     
	}
}
