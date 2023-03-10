using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BlueSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.UseSound = SoundID.Item34;
		Item.shoot = ProjectileID.MushroomSpray;
		Item.shootSpeed = 10f;
		Item.value = 830000;
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
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(ItemID.DarkBlueSolution, 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
