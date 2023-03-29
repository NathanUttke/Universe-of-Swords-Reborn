using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrorsLevel3 : ModItem
{
    public override string Texture => "UniverseofSwordsMod/Items/Accessories/HaloOfHorrors";
    public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("Level 3\n10 defense\n25% increased armor penetration\nIncreased health regeneration\n15% increased damage\nCurses the wearer with infinite Potion Sickness debuff\n10% decreased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(0, 7, 40, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.boneGloveItem = Item;
		player.statDefense += 10;
		player.GetArmorPenetration(DamageClass.Generic) += 15;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.10f;
		player.statLifeMax2 += 20;
		player.GetDamage(DamageClass.Generic) += 0.15f;
		player.AddBuff(BuffID.RapidHealing, 300, true);
		player.AddBuff(BuffID.Honey, 300, true);   
	}

    public override void AddRecipes()
    {
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HaloOfHorrors>())
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddIngredient(ItemID.Bone, 200)
			.AddIngredient(ItemID.SpectreBar, 25)
			.AddIngredient(ItemID.HoneyComb, 1)
			.AddIngredient(ItemID.BeeWax, 100)
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
    }
}
