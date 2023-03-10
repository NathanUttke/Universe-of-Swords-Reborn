using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HellfireArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Hellfire arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 25;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.HellfireArrow;
		Item.shootSpeed = 10f;
		Item.value = 14500;
		Item.autoReuse = true;
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
		val.AddIngredient(ItemID.HellfireArrow, 999);
		val.AddIngredient(Mod, "SwordMatter", 110);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
