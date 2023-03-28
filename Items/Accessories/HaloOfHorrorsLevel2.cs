using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Accessories;

public class HaloOfHorrorsLevel2 : ModItem
{
    public override string Texture => "UniverseofSwordsMod/Items/Accessories/HaloOfHorrors";
    public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Skull of Insanity");
		Tooltip.SetDefault("Level 2\n15 defense\nIncreased armor penetration\nIncreased health regeneration\n15% increased damage\nCurses the wearer with Feral bite\n20% decreased melee speed");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 60;
		Item.value = Item.sellPrice(0, 8, 20, 0);
		Item.rare = ItemRarityID.Purple;
		Item.expert = true;
		Item.accessory = true; 
		SacrificeTotal = 1;
	}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		player.boneGloveItem = Item;
		player.boneGloveTimer = 30;
		player.statDefense += 10;
		player.GetArmorPenetration(DamageClass.Generic) += 10;
		player.GetAttackSpeed(DamageClass.Melee) -= 0.20f;
		player.statLifeMax2 += 10;
		player.GetDamage(DamageClass.Generic) += 0.10f;
		player.AddBuff(BuffID.RapidHealing, 100, true);
        if (Main.rand.NextBool(3))
		{
            player.AddBuff(BuffID.Rabies, 300, true);
        }
	}

    public override void AddRecipes()
    {
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<HaloOfHorrors>())
            .AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
            .AddIngredient(ItemID.BoneGlove, 1)
			.AddIngredient(ItemID.Bone, 125)
			.AddTile(TileID.TinkerersWorkbench)
			.Register();
    }
}
