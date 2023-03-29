using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Uses arrows as ammo");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.15f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 12;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shootSpeed = 7f;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{				
		CreateRecipe()
		.AddIngredient(ItemID.WoodenBow, 1)
		.AddRecipeGroup("IronBar", 15)
		.AddIngredient(Mod, "SwordMatter", 100)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
