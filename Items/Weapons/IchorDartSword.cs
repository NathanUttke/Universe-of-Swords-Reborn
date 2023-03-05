using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class IchorDartSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 2f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 59;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item99;
		Item.shoot = ProjectileID.IchorDart;
		Item.shootSpeed = 20f;
		Item.value = 311200;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 125);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(ItemID.IchorDart, 999);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
