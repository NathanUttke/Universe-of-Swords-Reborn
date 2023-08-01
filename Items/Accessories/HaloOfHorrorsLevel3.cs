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
		// DisplayName.SetDefault("Skull of Insanity");
		// Tooltip.SetDefault("Level 3\n10 defense\n15% increased armor penetration\nIncreased health regeneration\n15% increased damage\n10% decreased melee speed\nCurses the wearer with a 20% Feral bite chance");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(0, 7, 40, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		Item.ResearchUnlockCount = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.boneGloveItem = Item;
		player.honeyCombItem = Item;
		player.statDefense += 10;
		player.GetArmorPenetration(DamageClass.Generic) += 15;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.10f;
		player.statLifeMax2 += 20;
		player.GetDamage(DamageClass.Generic) += 0.15f;
		player.AddBuff(BuffID.RapidHealing, 300, true);
		player.AddBuff(BuffID.Honey, 300, true);
        if (Main.rand.NextBool(5))
        {
            player.AddBuff(BuffID.Rabies, 300, true);
        }
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
			.AddIngredient(ItemID.SharkToothNecklace, 1)
            .AddTile(TileID.TinkerersWorkbench)
			.Register();
        CreateRecipe()
            .AddIngredient(ModContent.ItemType<HaloOfHorrors>())
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
            .AddIngredient(ItemID.Bone, 200)
            .AddIngredient(ItemID.SpectreBar, 25)
            .AddIngredient(ItemID.StingerNecklace, 1)
            .AddIngredient(ItemID.BeeWax, 100)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
    }
}
