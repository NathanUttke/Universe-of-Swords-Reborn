using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SilverCoinSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Shoots silver coins");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 58;
		Item.scale = 0.9f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 5;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item11;
		Item.shoot = ProjectileID.SilverCoin;
		Item.shootSpeed = 10f;
		Item.value = 1500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.SilverCoin, 99);
		val.AddIngredient(Mod, "SwordMatter", 20);
		val.AddTile(TileID.Anvils);
		val.Register();
	}
}
