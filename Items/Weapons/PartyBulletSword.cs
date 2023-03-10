using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PartyBulletSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Party bullets");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 50;
		Item.knockBack = 4.1f;
		Item.UseSound = SoundID.Item11;
		Item.value = 103000;
		Item.shoot = ProjectileID.PartyBullet;
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
		val.AddIngredient(ItemID.PartyBullet, 999);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
