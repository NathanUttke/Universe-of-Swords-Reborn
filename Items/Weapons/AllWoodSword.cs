using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class AllWoodSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Smells like world'");
	}

	public override void SetDefaults()
	{
		Item.width = 54;
		Item.height = 54;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 19;
		Item.knockBack = 1f;
		Item.UseSound = SoundID.Item1;
		Item.value = 6888;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Wood, 15);
		val.AddIngredient(ItemID.BorealWood, 15);
		val.AddIngredient(ItemID.PalmWood, 15);
		val.AddIngredient(ItemID.RichMahogany, 15);
		val.AddIngredient(ItemID.Ebonwood, 15);
		val.AddTile(TileID.WorkBenches);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.Wood, 15);
		val2.AddIngredient(ItemID.BorealWood, 15);
		val2.AddIngredient(ItemID.PalmWood, 15);
		val2.AddIngredient(ItemID.RichMahogany, 15);
		val2.AddIngredient(ItemID.Shadewood, 15);
		val2.AddTile(TileID.WorkBenches);
		val2.Register();
	}
}
