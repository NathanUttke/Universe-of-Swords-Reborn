using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PekkaSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'DESTROY'");
	}

	public override void SetDefaults()
	{
		Item.width = 56;
		Item.height = 62;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 22;
		Item.useAnimation = 22;
		Item.damage = 25;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 10000;
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
		val.AddIngredient(ItemID.GoldBroadsword, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.PlatinumBroadsword, 1);
		val2.AddIngredient(Mod, "UpgradeMatter", 1);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
