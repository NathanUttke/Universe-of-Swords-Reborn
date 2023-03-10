using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UselessWeapon : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 56;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 14;
		Item.useAnimation = 14;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 50999;
		Item.autoReuse = false;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
