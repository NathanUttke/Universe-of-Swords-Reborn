using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ChlorophyteArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Chlorophyte arrows");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 68;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item5;
		Item.shoot = ProjectileID.ChlorophyteArrow;
		Item.shootSpeed = 10f;
		Item.value = 78500;
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
		val.AddIngredient(ItemID.ChlorophyteArrow, 999);
		val.AddIngredient(Mod, "SwordMatter", 110);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
