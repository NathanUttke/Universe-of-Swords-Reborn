using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PaladinSword : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 54;
		Item.height = 54;
		Item.scale = 1.2f;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 85;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.PaladinsHammerFriendly;
		Item.shootSpeed = 20f;
		Item.value = 540500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
