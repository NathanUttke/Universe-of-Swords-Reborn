using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WoodenArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Wooden Arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 76;
		Item.height = 76;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 10;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.WoodenArrowFriendly;
		Item.shootSpeed = 10f;
		Item.value = 3500;
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
		val.AddIngredient(ItemID.WoodenArrow, 999);
		val.AddIngredient(Mod, "SwordMatter", 80);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
