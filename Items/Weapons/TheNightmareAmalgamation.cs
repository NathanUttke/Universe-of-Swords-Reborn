using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheNightmareAmalgamation : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(90);
		Item.rare = ItemRarityID.Purple;
		Item.ArmorPenetration = 20;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 150;
		Item.knockBack = 8f;
		Item.shoot = ModContent.ProjectileType<NightmareHoldoutProj>();
		Item.shootSpeed = 1f;
		Item.value = Item.sellPrice(0, 7, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		Item.ResearchUnlockCount = 1;
		Item.noMelee = true;
		Item.noUseGraphic = true;
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

	public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<CthulhuJudge>(), 1)
		.AddIngredient(ModContent.ItemType<TheEater>(), 1)
		.AddIngredient(ModContent.ItemType<TheSwarm>(), 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(), 1)
		.AddIngredient(ModContent.ItemType<LifeRemovalMachine>(), 1)
		.AddIngredient(ModContent.ItemType<Doomsday>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<CthulhuJudge>(), 1)
		.AddIngredient(ModContent.ItemType<TheBrain>(), 1)
		.AddIngredient(ModContent.ItemType<TheSwarm>(), 1)
		.AddIngredient(ModContent.ItemType<FixedSwordOfPower>(),1)
		.AddIngredient(ModContent.ItemType<LifeRemovalMachine>(),1)
		.AddIngredient(ModContent.ItemType<Doomsday>(), 1)
		.AddIngredient(ModContent.ItemType<PurpleRuneBlade>(), 1)
		.AddTile(TileID.LunarCraftingStation)
		.Register();
	}
}
