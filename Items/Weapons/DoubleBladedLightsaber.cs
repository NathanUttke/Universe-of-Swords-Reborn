using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DoubleBladedLightsaber : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Double Bladed Lightsaber");
		Tooltip.SetDefault("'Watch out to not cut your body in half'");
	}

	public override void SetDefaults()
	{
		Item.damage = 70;
		Item.DamageType = DamageClass.MeleeNoSpeed; 
		SacrificeTotal = 1;
		Item.width = 138;
		Item.height = 138;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.channel = true;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;
		Item.useStyle = ItemUseStyleID.Shoot;
		Item.knockBack = 8f;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Lime;
		Item.shoot = Mod.Find<ModProjectile>("DoubleBladedLightsaberProjectile").Type;
		Item.noUseGraphic = true;
	}
	public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.YellowPhasesaber, 1)
		.AddIngredient(ItemID.WhitePhasesaber, 1)
		.AddIngredient(ItemID.PurplePhasesaber, 1)
		.AddIngredient(ItemID.GreenPhasesaber, 1)
		.AddIngredient(ItemID.BluePhasesaber, 1)
		.AddIngredient(ItemID.RedPhasesaber, 1)
		.AddIngredient(ItemID.SoulofFright, 12)
		.AddIngredient(ItemID.SoulofSight, 12)
		.AddIngredient(ItemID.SoulofMight, 12)
		.AddIngredient(Mod, "UpgradeMatter", 3)
		.AddIngredient(ItemID.CrystalShard, 50)
		.AddIngredient(ModContent.ItemType<HumanBuzzSaw>(), 1)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
