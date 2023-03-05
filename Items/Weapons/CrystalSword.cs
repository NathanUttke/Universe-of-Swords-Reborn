using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrystalSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 80;
		Item.height = 80;
		Item.scale = 0.8f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 40;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 100700;
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
		val.AddIngredient(ItemID.CrystalShard, 20);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
