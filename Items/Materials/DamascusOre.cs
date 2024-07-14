using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Tiles;

namespace UniverseOfSwordsMod.Items.Materials;

public class DamascusOre : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 100;
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
		Item.createTile = ModContent.TileType<DamascusOreTile>();
		Item.maxStack = Item.CommonMaxStack;
	}
}
