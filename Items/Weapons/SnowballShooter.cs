using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SnowballShooter : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 67;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.RocketSnowmanI;
		Item.shootSpeed = 10f;
		Item.value = 420500;
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
		val.AddIngredient(ItemID.SnowmanCannon, 1);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
