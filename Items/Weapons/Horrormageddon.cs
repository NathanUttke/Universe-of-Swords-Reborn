using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Horrormageddon : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Where you see an army, I see a graveyard'");
	}

	public override void SetDefaults()
	{
		Item.width = 82;
		Item.height = 82;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 15;
		Item.damage = 105;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ModContent.ProjectileType<DemonScytheClone>();
		Item.shootSpeed = 13f;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.TheHorsemansBlade, 1)
		.AddIngredient(ModContent.ItemType<DeathSword>(), 1)
        .AddIngredient(ModContent.ItemType<ElBastardo>(), 1)
        .AddIngredient(ModContent.ItemType<InnosWrath>(), 1)
        .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 6)
        .AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		float angleSpread = 0.5f;
		float baseSpeed = MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
		double startingAngle = MathF.Atan2(velocity.X, velocity.Y) - (double)(angleSpread / 2f);
		double deltaAngle = angleSpread / 2f;
		for (int numOfProjectiles = 0; numOfProjectiles < 3; numOfProjectiles++)
		{
            double offsetAngle = startingAngle + deltaAngle * numOfProjectiles;
			Projectile.NewProjectileDirect(source, position, new Vector2(baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle)), type, (int)(damage * 1.15f), knockback / 2f, player.whoAmI);
        }
        return false;
    }
}
