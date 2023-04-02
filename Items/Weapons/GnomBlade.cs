using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GnomBlade : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 37;
		Item.useAnimation = 18;
		Item.damage = 125;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		CreateRecipe()	
			.AddIngredient(ItemID.LunarBar, 15)
			.AddIngredient(ItemID.GardenGnome, 1)
			.AddIngredient(Mod, "Doomsday", 1)
			.AddIngredient(ItemID.TerraBlade, 1)
			.AddIngredient(Mod, "LunarOrb", 1)
			.AddIngredient(Mod, "Orichalcon", 5)
			.AddIngredient(ModContent.ItemType<TrueTerrablade>(), 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
			.AddTile(TileID.LunarCraftingStation)
			.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
		return false;
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
