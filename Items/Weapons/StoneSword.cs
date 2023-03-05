using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StoneSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'You Rock!'");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 0.8f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 7;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 100;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
				
				Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.StoneBlock, 20);
		val.AddTile(TileID.WorkBenches);
		val.Register();
	}
}
