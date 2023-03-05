using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CaesarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Et tu, Brute?'");
	}

	public override void SetDefaults()
	{
		Item.width = 35;
		Item.height = 35;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 24;
		Item.knockBack = 5.4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 45900;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
