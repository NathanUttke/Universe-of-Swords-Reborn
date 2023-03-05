using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BiggoronSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Heavy but strong");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.damage = 30;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 19000;
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
		val.AddRecipeGroup("IronBar", 10);
		val.AddIngredient(ItemID.GoldBar, 10);
		val.AddIngredient(Mod, "SwordMatter", 60);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddRecipeGroup("IronBar", 10);
		val2.AddIngredient(ItemID.PlatinumBar, 10);
		val2.AddIngredient(Mod, "SwordMatter", 60);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
