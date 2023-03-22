using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ForceBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Sword with a very strong knockback'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.damage = 50;
		Item.knockBack = 12f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.BreakerBlade, 1);
		val.AddIngredient(Mod, "OrcWarSword", 1);
		val.AddIngredient(ItemID.CobaltBar, 11);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddTile(TileID.Anvils);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.BreakerBlade, 1);
		val2.AddIngredient(Mod, "OrcWarSword", 1);
		val2.AddIngredient(ItemID.PalladiumBar, 11);
		val2.AddIngredient(Mod, "UpgradeMatter", 1);
		val2.AddTile(TileID.Anvils);
		val2.Register();
	}
}
