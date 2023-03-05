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
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 24;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.shoot = ProjectileID.PurificationPowder;
		Item.useAmmo = AmmoID.Arrow;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
				
								Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.WoodenBow, 1);
		val.AddRecipeGroup("IronBar", 15);
		val.AddIngredient(Mod, "SwordMatter", 60);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
