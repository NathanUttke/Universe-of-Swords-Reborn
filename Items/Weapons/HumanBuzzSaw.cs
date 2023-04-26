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
        SacrificeTotal = 1;

        Item.damage = 24;
		Item.DamageType = DamageClass.MeleeNoSpeed; 

		Item.width = 102;
		Item.height = 102;
		Item.crit = 8;
		Item.scale = 2f;

		Item.useStyle = ItemUseStyleID.Shoot;

		Item.useTime = 4;
		Item.useAnimation = 4;		
		Item.UseSound = SoundID.Item1;

		Item.knockBack = 3.5f;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.rare = ItemRarityID.LightRed;
		Item.shoot = Mod.Find<ModProjectile>("HumanBuzzSaw").Type;

        Item.channel = true;
        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;
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
