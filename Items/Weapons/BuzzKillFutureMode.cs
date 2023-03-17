using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BuzzKillFutureMode : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Buzz Kill Future Mode");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.crit = 4;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 50;
		Item.knockBack = 1f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.Bee;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        float spread = 0.174f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 2f;
        double offsetAngle = startAngle + deltaAngle;

        if (Main.rand.NextBool(7))
		{
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), ProjectileID.GiantBee, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);         
        }
        for (int i = 0; i < 2; i++)
        {
			offsetAngle *= i;
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), Item.shoot, damage, knockback, Item.playerIndexTheItemIsReservedFor, 0f, 0f);
        }
        return false;
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (player.strongBees)
		{
			damage *= 1.15f;
		}
    }
	
    public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<LunarOrb>(), 1)
			.AddIngredient(ModContent.ItemType<BuzzKill>(), 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}
}
