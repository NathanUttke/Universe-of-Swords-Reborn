using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CursedBulletSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Cursed bullets");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 2f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 55;
		Item.knockBack = 6.6f;
		Item.UseSound = SoundID.Item11;
		Item.value = 180000;
		Item.shoot = ProjectileID.CursedBullet;
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
		val.AddIngredient(ItemID.CursedBullet, 999);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
