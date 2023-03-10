using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OldMansBlade : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots Golden Shower");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.damage = 87;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item8;
		Item.shoot = ProjectileID.GoldenShowerFriendly;
		Item.shootSpeed = 10f;
		Item.value = 180500;
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
		val.AddIngredient(Mod, "AllWoodSword", 1);
		val.AddIngredient(ItemID.SpookyWood, 99);
		val.AddIngredient(ItemID.Pearlwood, 81);
		val.AddIngredient(Mod, "Orichalcon", 1);
		val.AddIngredient(Mod, "SwordMatter", 100);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(69, 360, false);
	}
}
