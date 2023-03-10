using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Fallen Stars");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 33;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.FallingStar;
		Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = 48500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddIngredient(ItemID.StarCannon, 1);
		val.AddIngredient(ItemID.FallenStar, 15);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
