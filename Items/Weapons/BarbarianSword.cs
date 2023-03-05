using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BarbarianSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'We gonna need more Barbarians'");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 24;
		Item.useAnimation = 24;
		Item.damage = 20;
		Item.knockBack = 3f;
		Item.UseSound = SoundID.Item1;
		Item.value = 15000;
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
		val.AddIngredient(ItemID.IronBroadsword, 1);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.LeadBroadsword, 1);
		val2.AddIngredient(Mod, "UpgradeMatter", 1);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
