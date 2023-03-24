using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OrcWarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Big and heavy sword of orcs that requires a lot of strenght to wield");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.damage = 50;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 29000;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.IronBar, 25)
			.AddIngredient(Mod, "BiggoronSword", 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
			.AddTile(TileID.Anvils)
			.Register();
		CreateRecipe()
			.AddIngredient(ItemID.LeadBar, 25)
			.AddIngredient(Mod, "BiggoronSword", 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 1)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
