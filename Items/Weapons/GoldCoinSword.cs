using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GoldCoinSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots gold coins");
	}

	public override void SetDefaults()
	{
		Item.width = 72;
		Item.height = 72;
		Item.scale = 0.8f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 10;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item11;
		Item.shoot = ProjectileID.GoldCoin;
		Item.shootSpeed = 10f;
		Item.value = 10000;
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
		val.AddIngredient(ItemID.GoldCoin, 20);
		val.AddIngredient(Mod, "SwordMatter", 50);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
