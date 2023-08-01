using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Materials;

public class DamascusOre : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Damascus Ore");
	}

	public override void SetDefaults()
	{
		Item.width = 16;
		Item.height = 16;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.value = 500;
		Item.rare = ItemRarityID.Green;
		Item.autoReuse = true;
		Item.consumable = true;
		Item.createTile = Mod.Find<ModTile>("DamascusOreTile").Type;
		Item.maxStack = 9999;
		Item.ResearchUnlockCount = 100;
	}
}
