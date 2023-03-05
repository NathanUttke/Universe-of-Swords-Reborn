using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class IchorBulletSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Ichor bullets");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 65;
		Item.knockBack = 6.1f;
		Item.UseSound = SoundID.Item11;
		Item.value = 210000;
		Item.shoot = ProjectileID.IchorBullet;
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
		val.AddIngredient(ItemID.IchorBullet, 999);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
