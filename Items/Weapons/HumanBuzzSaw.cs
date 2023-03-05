using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HumanBuzzSaw : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Human Buzz Saw");
		Tooltip.SetDefault("'Cuts through hordes of Terraria like butter'");
	}

	public override void SetDefaults()
	{
		Item.damage = 24;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
		Item.width = 106;
		Item.height = 106;
		Item.crit = 8;
		Item.scale = 2f;
		Item.useTime = 4;
		Item.useAnimation = 4;
		Item.channel = true;
		Item.UseSound = SoundID.Item1;
		Item.useStyle = 100;
		Item.knockBack = 5f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.shoot = Mod.Find<ModProjectile>("HumanBuzzSaw").Type;
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
		val.AddIngredient(ItemID.Sawmill, 1);
		val.AddIngredient(ItemID.TitaniumBar, 8);
		val.AddIngredient(Mod, "SwordMatter", 60);
		val.AddIngredient(Mod, "DamascusBar", 20);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
		Recipe val2 = CreateRecipe(1);
		val2.AddIngredient(ItemID.Sawmill, 1);
		val2.AddIngredient(ItemID.AdamantiteBar, 8);
		val2.AddIngredient(Mod, "SwordMatter", 60);
		val2.AddIngredient(Mod, "DamascusBar", 20);
		val2.AddTile(TileID.MythrilAnvil);
		val2.Register();
	}
}
