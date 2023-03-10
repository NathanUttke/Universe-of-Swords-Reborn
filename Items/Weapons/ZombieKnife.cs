using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ZombieKnife : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Great for impersonating Zombie hunters'");
	}

	public override void SetDefaults()
	{
		Item.width = 46;
		Item.height = 46;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 7;
		Item.knockBack = 4f;
		Item.UseSound = SoundID.Item1;
		Item.value = 7800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
