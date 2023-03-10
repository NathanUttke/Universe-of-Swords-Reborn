using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BlowpipeSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Watch out for your wrists'");
	}

	public override void SetDefaults()
	{
		Item.width = 38;
		Item.height = 36;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 23;
		Item.useAnimation = 23;
		Item.damage = 16;
		Item.knockBack = 3.5f;
		Item.UseSound = SoundID.Item17;
		Item.shoot = ProjectileID.Seed;
		Item.shootSpeed = 20f;
		Item.value = Item.sellPrice(0, 0, 40, 0);
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
		val.AddIngredient(ItemID.Blowpipe, 1);
		val.AddIngredient(Mod, "DamascusBar", 10);
		val.AddIngredient(Mod, "SwordMatter", 40);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
