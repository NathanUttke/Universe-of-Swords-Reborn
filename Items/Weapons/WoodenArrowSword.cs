using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WoodenArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("Shoots Wooden Arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 60;
		Item.useAnimation = 30;
		Item.damage = 8;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.WoodenArrowFriendly;
		Item.shootSpeed = 10f;
		Item.value = 3500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.ResearchUnlockCount = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ItemID.WoodenArrow, 500)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
			.AddTile(TileID.Anvils)
			.Register();
	}
}
