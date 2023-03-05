using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CopperCoinSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots copper coins");
	}

	public override void SetDefaults()
	{
		Item.width = 56;
		Item.height = 56;
		Item.scale = 0.8f;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 2;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item11;
		Item.shoot = ProjectileID.CopperCoin;
		Item.shootSpeed = 10f;
		Item.value = 500;
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
		val.AddIngredient(ItemID.CopperCoin, 99);
		val.AddIngredient(Mod, "SwordMatter", 10);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
