using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ElBastardo : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'The legendary El Bastardo'");
	}

	public override void SetDefaults()
	{
		Item.width = 86;
		Item.height = 86;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 18;
		Item.useAnimation = 18;
		Item.damage = 50;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
}
