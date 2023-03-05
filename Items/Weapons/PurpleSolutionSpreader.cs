using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PurpleSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.UseSound = SoundID.Item34;
		Item.shoot = ProjectileID.CorruptSpray;
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
		val.AddIngredient(ItemID.PurpleSolution, 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
