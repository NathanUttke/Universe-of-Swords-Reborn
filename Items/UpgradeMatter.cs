using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items;

public class UpgradeMatter : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Upgrade Matter");
		Tooltip.SetDefault("'Source for upgrading swords'");
		Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		ItemID.Sets.AnimatesAsSoul[Item.type] = true;
		ItemID.Sets.ItemIconPulse[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = false;
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.maxStack = 999;
		Item.value = 1800;
		Item.rare = ItemRarityID.Green;
		SacrificeTotal = 25;
	}

	public override void AddRecipes()
	{
		if (Main.hardMode)
		{
            CreateRecipe()
				.AddIngredient(Mod, "SwordMatter", 200)
                .AddIngredient(ItemID.SoulofLight, 20)
                .AddIngredient(ItemID.SoulofNight, 20)
                .AddTile(TileID.Anvils)
				.Register();
        }
		else
		{
			CreateRecipe()
				.AddIngredient(Mod, "SwordMatter", 200)
                .AddTile(TileID.Anvils)
				.Register();
		}

	}
}
