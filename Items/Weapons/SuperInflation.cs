using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SuperInflation : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Throw money at ALL your problems'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 2f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.knockBack = 10f;
		Item.useTime = 12;
		Item.useAnimation = 12;
		Item.damage = 240;
		Item.shoot = ProjectileID.GoldCoin;
		Item.shootSpeed = 40f;
		Item.UseSound = SoundID.Item1;
		Item.value = 999999;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 3f * (float)player.direction;
		player.itemLocation.Y -= 3f * (float)player.direction;
		player.itemLocation.Y -= -3f * player.gravDir;
	}

	public override void AddRecipes()
	{
		
																		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "Inflation", 1);
		val.AddIngredient(Mod, "CopperCoinSword", 1);
		val.AddIngredient(Mod, "SilverCoinSword", 1);
		val.AddIngredient(Mod, "GoldCoinSword", 1);
		val.AddIngredient(Mod, "UpgradeMatter", 2);
		val.AddIngredient(ItemID.LunarOre, 1);
		val.AddTile(TileID.LunarCraftingStation);
		val.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
																														float numberProjectiles = 10 + Main.rand.Next(10);
		float rotation = MathHelper.ToRadians(10f);
		position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 10f;
		for (int i = 0; (float)i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f)), default(Vector2)) * 0.2f;
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(72, 360, false);
	}
}
