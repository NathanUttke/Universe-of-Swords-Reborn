using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.RGB;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheNightmareAmalgamation : ModItem
{
	public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'The source of your nightmares'");
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
    public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(2))
		{
			int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<SkullDust>(), 0f, 0f, 100, default, 2f);
			Main.dust[dust].noGravity = true;
			Dust dust2 = Main.dust[dust];
			dust2.noGravity = true;
		}
	}

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
