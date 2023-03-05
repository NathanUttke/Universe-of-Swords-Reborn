using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Orcrist : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword forged by Elves'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 73;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 100900;
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
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(ItemID.TitaniumSword, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "UpgradeMatter", 1);
		val2.AddIngredient(ItemID.AdamantiteSword, 1);
		val2.AddTile(TileID.MythrilAnvil);
		val2.Register();
	}
}
