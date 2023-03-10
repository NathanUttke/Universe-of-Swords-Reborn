using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StickyGlowstickSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 46;
		Item.height = 46;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 15;
		Item.knockBack = 3.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 12000;
		Item.shoot = ProjectileID.StickyGlowstick;
		Item.shootSpeed = 20f;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
