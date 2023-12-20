using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrorsLevel4 : ModItem
{
    public override string Texture => "UniverseofSwordsMod/Items/Accessories/HaloOfHorrors";
    public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Skull of Insanity");
		// Tooltip.SetDefault("Level 4\n15 defense\n15% increased armor penetration\nIncreased health regeneration\n15% increased damage\n8% decreased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		Item.ResearchUnlockCount = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.boneGloveItem = Item;
		player.statDefense += 15;
		player.GetArmorPenetration(DamageClass.Generic) += 15;		
		player.statLifeMax2 += 25;
		player.GetDamage(DamageClass.Melee) += 0.15f;
		player.AddBuff(BuffID.RapidHealing, 300, true);
		player.AddBuff(BuffID.Honey, 300, true);
		player.AddBuff(BuffID.Regeneration, 300, true);		
	}

    public override void AddRecipes()
    {
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HaloOfHorrorsLevel3>())
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 20)
			.AddIngredient(ItemID.LifeCrystal, 15)
			.AddIngredient(ItemID.RegenerationPotion, 30)
			.AddIngredient(ItemID.BandofRegeneration, 1)
			.AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
            .AddTile(TileID.LunarCraftingStation)
			.Register();
    }
}
