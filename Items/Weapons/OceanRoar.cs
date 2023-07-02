using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OceanRoar : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 9;
		Item.shoot = ProjectileID.Typhoon;
		Item.shootSpeed = 1f;
		Item.UseSound = SoundID.Item84;
		Item.value = 5000;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
}
