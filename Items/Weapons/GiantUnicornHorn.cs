using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GiantUnicornHorn : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Fabolous!");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 57;
		Item.scale = 1.25f;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.value = 153000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
}
