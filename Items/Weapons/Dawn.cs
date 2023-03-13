using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Dawn : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword of the morning'");
	}

	public override void SetDefaults()
	{
		Item.width = 68;
		Item.height = 68;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 18;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 16, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.Feather, 30)
		.AddIngredient(ItemID.IronBroadsword, 1)
		.AddIngredient(ModContent.ItemType<RefinedIronSword>(), 2)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
