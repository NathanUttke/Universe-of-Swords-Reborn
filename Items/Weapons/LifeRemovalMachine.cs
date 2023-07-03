using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;
[LegacyName (new string[] { "UltraMachine" })]
public class LifeRemovalMachine : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Life Removal Machine");
		Tooltip.SetDefault("'Insert Hollywood computer generated special effects here'");
	}

	public override void SetDefaults()
	{
		Item.width = 116;
		Item.height = 116;
		Item.rare = ItemRarityID.Red;
		Item.crit = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 140;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ModContent.ProjectileType<LifeRemovalMachineProjectile>();
		Item.shootSpeed = 1f;
		Item.noMelee = true;
		Item.noUseGraphic = true;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void AddRecipes()
	{		
		CreateRecipe()
            .AddIngredient(ItemID.BrokenHeroSword, 1)
			.AddIngredient(ModContent.ItemType<SwordMatter>(), 45)
			.AddIngredient(ModContent.ItemType<DamascusBar>(), 20)
			.AddIngredient(ItemID.SoulofFright, 15)
			.AddIngredient(ItemID.SoulofMight, 15)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ItemID.SpectreBar, 20)
			.AddIngredient(ModContent.ItemType<PrimeSword>(), 1)
			.AddIngredient(ModContent.ItemType<DestroyerSword>(), 1)
			.AddIngredient(ModContent.ItemType<TwinsSword>(), 1)
			.AddIngredient(ModContent.ItemType<MartianSaucerCore>(), 1)
			.AddIngredient(ItemID.ShroomiteBar, 10)
			.AddIngredient(ItemID.LihzahrdPowerCell, 5)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
