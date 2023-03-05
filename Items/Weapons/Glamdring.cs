using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Glamdring : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword forged by Elves'");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 2f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 65;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 98900;
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
		val.AddIngredient(ItemID.OrichalcumSword, 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(Mod, "UpgradeMatter", 1);
		val2.AddIngredient(ItemID.MythrilSword, 1);
		val2.AddTile(TileID.MythrilAnvil);
		val2.Register();
	}
}
