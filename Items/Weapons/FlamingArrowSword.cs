using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FlamingArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Flaming arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.White;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 18;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.FireArrow;
		Item.shootSpeed = 10f;
		Item.value = 4500;
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
		val.AddIngredient(ItemID.FlamingArrow, 999);
		val.AddIngredient(Mod, "SwordMatter", 90);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
