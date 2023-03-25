using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BetterShroomiteBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Bigger and better!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 78;
		Item.knockBack = 7.2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 380000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "ShroomiteBlade", 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
