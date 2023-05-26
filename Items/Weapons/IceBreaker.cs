using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class IceBreaker : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Freezing to the touch'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 60;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ModContent.ProjectileType<IceBreakerProjectile>();
		Item.shootSpeed = 40f;
		Item.value = 300200;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ItemID.Frostbrand, 1)
		.AddIngredient(ItemID.SnowBlock, 200)
		.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		float numberProjectiles = Main.rand.Next(1, 3);
		float rotation = MathHelper.ToRadians(10f);
		position += Vector2.Normalize(velocity) * 5f;
		for (int i = 0; i < numberProjectiles; i++)
		{
			Vector2 perturbedSpeed = Utils.RotatedBy(velocity, (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, Item.shoot, damage, knockback, player.whoAmI, 0f, 0f);
		}
		return false;
	}
}
