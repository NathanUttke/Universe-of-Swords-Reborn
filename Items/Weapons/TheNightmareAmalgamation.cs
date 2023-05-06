using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheNightmareAmalgamation : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'The source of your nightmares'");
	}

	public override void SetDefaults()
	{
		Item.width = 110;
		Item.height = 110;
		Item.rare = ItemRarityID.Purple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 23;
		Item.useAnimation = 23;
		Item.damage = 115;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item71;
		Item.shoot = ModContent.ProjectileType<Nightmare>();
		Item.shootSpeed = 15f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, (int)(damage * 1.20f), knockback, player.whoAmI, 0f, 0f);	
		return false;
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PurpleTorch, 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
			Dust dust2 = Main.dust[dust];
			dust2.noGravity = true;
		}
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(153, 800, false);
	}

	public override void AddRecipes()
	{	
		CreateRecipe()
		.AddIngredient(Mod, "CthulhuJudge", 1)
		.AddIngredient(Mod, "TheEater", 1)
		.AddIngredient(ModContent.ItemType<TheSwarm>(), 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(),1)
		.AddIngredient(ItemID.BreakerBlade, 1)
		.AddIngredient(Mod, "PrimeSword", 1)
		.AddIngredient(Mod, "DestroyerSword", 1)
		.AddIngredient(Mod, "TwinsSword", 1)
		.AddIngredient(Mod, "Executioner", 1)
		.AddIngredient(Mod, "Doomsday", 1)
		.AddIngredient(ModContent.ItemType<DragonsDeath>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
		CreateRecipe()
		.AddIngredient(Mod, "CthulhuJudge", 1)	
		.AddIngredient(Mod, "TheBrain", 1)
		.AddIngredient(ItemID.BeeKeeper, 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(), 1)
		.AddIngredient(ItemID.BreakerBlade, 1)
		.AddIngredient(Mod, "PrimeSword", 1)
		.AddIngredient(Mod, "DestroyerSword", 1)
		.AddIngredient(Mod, "TwinsSword", 1)
		.AddIngredient(Mod, "Executioner", 1)
		.AddIngredient(Mod, "Doomsday", 1)
		.AddIngredient(ModContent.ItemType<DragonsDeath>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
