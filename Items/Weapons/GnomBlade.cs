using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GnomBlade : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 9;
		Item.useAnimation = 9;
		Item.damage = 375;
		Item.knockBack = 15f;
		Item.shoot = ProjectileID.DD2PhoenixBowShot;
		Item.shootSpeed = 40f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(1, 0, 0, 0);
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
		val.AddIngredient(ItemID.FragmentSolar, 10);
		val.AddIngredient(ItemID.FragmentVortex, 10);
		val.AddIngredient(ItemID.FragmentNebula, 10);
		val.AddIngredient(ItemID.FragmentStardust, 10);
		val.AddIngredient(ItemID.LunarBar, 14);
		val.AddIngredient(Mod, "Dragrael", 1);
		val.AddIngredient(Mod, "Doomsday", 1);
		val.AddIngredient(ItemID.TerraBlade, 1);
		val.AddIngredient(Mod, "LunarOrb", 1);
		val.AddIngredient(Mod, "Orichalcon", 3);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.TerraBeam, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.NightBeam, damage, knockback, player.whoAmI, 0f, 0f);
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.InfernoFriendlyBlast, damage, knockback, player.whoAmI, 0f, 0f);
		return true;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
		target.AddBuff(69, 360, false);
		target.AddBuff(44, 360, false);
		target.AddBuff(24, 360, false);
		target.AddBuff(20, 360, false);
		target.AddBuff(70, 360, false);
		target.AddBuff(31, 360, false);
		target.AddBuff(39, 360, false);
		target.AddBuff(137, 360, false);
	}
}
