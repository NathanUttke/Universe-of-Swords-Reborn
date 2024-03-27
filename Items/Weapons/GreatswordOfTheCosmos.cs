using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GreatswordOfTheCosmos : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 100;
		Item.height = 100;
		Item.rare = ItemRarityID.Red;
		Item.crit = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 10;
		Item.useAnimation = 20;
		Item.damage = 145;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item169;
		Item.shoot = ModContent.ProjectileType<CosmoStarProjectile>();
		Item.shootSpeed = 12f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(3))
		{
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Utils.SelectRandom(Main.rand, Color.MediumVioletRed, Color.Cyan, Color.HotPink), 1f);
        }
    }
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int numberProjectiles = 3;		
		for (int index = 0; index < numberProjectiles; index++)
		{
            Vector2 offsetPosition = new(position.X, player.Top.Y - Main.rand.Next(200, 400));
			Vector2 newVelocity = new(velocity.X, Item.shootSpeed);

            Projectile.NewProjectileDirect(player.GetSource_ItemUse(Item), offsetPosition, newVelocity, type, damage, 5f, player.whoAmI, 0f, 0f);
        }
		return false;
	}

    public override void AddRecipes()
	{
		CreateRecipe()
            .AddIngredient(ModContent.ItemType<PowerOfTheGalactic>(), 1)
			.AddIngredient(ItemID.StarWrath, 1)
			.AddIngredient(ModContent.ItemType<LunarOrb>(), 2)
			.AddIngredient(ItemID.MeteoriteBar, 30)
			.AddIngredient(ModContent.ItemType<Orichalcon>(), 15)
			.AddIngredient(ItemID.LunarBar, 25)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 50)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
    }
}
