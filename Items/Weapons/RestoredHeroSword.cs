using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class RestoredHeroSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.4f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 9;
		Item.useAnimation = 9;
		Item.damage = 55;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 500900;
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
		val.AddIngredient(ItemID.BrokenHeroSword, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
