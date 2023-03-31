using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrors : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("Level 1\n5 defense\n5% increased armor penetration\nIncreased health regeneration\n5% increased damage\n30% decreased melee speed\nCurses the wearer with Feral bite");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statDefense += 5;
		player.GetArmorPenetration(DamageClass.Generic) += 5;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.30f;
		player.statLifeMax2 += 10;
		player.GetDamage(DamageClass.Generic) += 0.05f;
        player.AddBuff(BuffID.Rabies, 300, true);     
	}
}
