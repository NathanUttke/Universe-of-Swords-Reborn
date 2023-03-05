using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GrenadeBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Some madman strapped a grenade to a sword to increase its damage. And now someone even crazier is wielding it as a weapon!'");
	}

	public override void SetDefaults()
	{
		Item.width = 56;
		Item.height = 56;
		Item.scale = 1.3f;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 30;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Grenade;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y += 1f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
												Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.Grenade, 99);
		val.AddIngredient(ItemID.Wire, 20);
		val.AddIngredient(Mod, "DamascusBar", 15);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
