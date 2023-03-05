using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Sting : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Sword forged by Elves");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 22;
		Item.knockBack = 2.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = 90900;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
