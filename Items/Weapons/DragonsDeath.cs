using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DragonsDeath : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Dragon's Death");
		Tooltip.SetDefault("'Great for impersonating Dragon hunters'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 190;
		Item.knockBack = 13f;
		Item.UseSound = SoundID.Item1;
		Item.value = 490500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
}
