using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CthulhuJudge : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("I have an eye on you...");
	}

	public override void SetDefaults()
	{
		Item.width = 58;
		Item.height = 60;
		Item.scale = 1.25f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 24;
		Item.knockBack = 6.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 40, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
}
