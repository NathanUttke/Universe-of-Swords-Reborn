using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class LuminiteBulletSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Luminite bullets");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1.8f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 100;
		Item.knockBack = 6.55f;
		Item.UseSound = SoundID.Item11;
		Item.value = 325000;
		Item.shoot = ProjectileID.MoonlordBullet;
		Item.shootSpeed = 20f;
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
		val.AddIngredient(ItemID.MoonlordBullet, 999);
		val.AddIngredient(Mod, "SwordMatter", 99);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}
}
