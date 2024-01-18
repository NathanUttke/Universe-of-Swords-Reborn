using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrors : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Skull of Insanity");
		// Tooltip.SetDefault("Level 1 \n5 defense\n5% increased armor penetration\nIncreased health regeneration\n5% increased damage\nCurses the wearer with Feral bite\n30% decreased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 38;
		Item.height = 40;
		Item.value = Item.sellPrice(0, 6, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		Item.ResearchUnlockCount = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.statDefense += 5;
		player.GetArmorPenetration(DamageClass.Melee) += 5;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.30f;
		player.statLifeMax2 += 10;
		player.GetDamage(DamageClass.Melee) += 0.05f;
        player.AddBuff(BuffID.Rabies, 300, true);     
	}
}
