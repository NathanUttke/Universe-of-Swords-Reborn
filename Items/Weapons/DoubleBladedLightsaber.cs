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
		Item.damage = 65;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
		Item.width = 280;
		Item.height = 280;
		Item.useTime = 10;
		Item.useAnimation = 10;
		Item.channel = true;
		Item.useStyle = 100;
		Item.knockBack = 8f;
		Item.value = Item.sellPrice(0, 4, 0, 0);
		Item.rare = ItemRarityID.Lime;
		Item.shoot = Mod.Find<ModProjectile>("DoubleBladedLightsaberProjectile").Type;
		Item.noUseGraphic = true;
	}
	//public override bool UseItemFrame(Player player)
	//{
	//	player.bodyFrame.Y = 3 * player.bodyFrame.Height;
	//	return true;
	//}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.YellowPhasesaber, 1);
		val.AddIngredient(ItemID.WhitePhasesaber, 1);
		val.AddIngredient(ItemID.PurplePhasesaber, 1);
		val.AddIngredient(ItemID.GreenPhasesaber, 1);
		val.AddIngredient(ItemID.BluePhasesaber, 1);
		val.AddIngredient(ItemID.RedPhasesaber, 1);
		val.AddIngredient(ItemID.SoulofFright, 12);
		val.AddIngredient(ItemID.SoulofSight, 12);
		val.AddIngredient(ItemID.SoulofMight, 12);
		val.AddIngredient(Mod, "UpgradeMatter", 1);
		val.AddIngredient(ItemID.CrystalShard, 50);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
