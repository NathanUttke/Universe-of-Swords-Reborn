using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DartSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 2f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 58;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item99;
		Item.shoot = ProjectileID.PoisonDartBlowgun;
		Item.shootSpeed = 20f;
		Item.value = 304200;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
