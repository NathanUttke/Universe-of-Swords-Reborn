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
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 100;
		Item.height = 100;
		Item.rare = ItemRarityID.Red;
		Item.crit = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 145;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item169;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.shoot = ModContent.ProjectileType<GreatswordOfTheCosmosProj>();
		Item.shootSpeed = 1f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override bool MeleePrefix() => true;

    public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;

    int swingDir = 0;
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        if (swingDir > 1)
        {
            swingDir = 0;
        }
        Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, swingDir);
        swingDir++;
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
