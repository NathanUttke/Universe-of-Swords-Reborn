using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TwinsSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Whoosh, whoosh!");
	}

	public override void SetDefaults()
	{
		Item.width = 32;
		Item.height = 32;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 62;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 160000;
		Item.shoot = ProjectileID.CursedFlameFriendly;
		Item.shootSpeed = 10f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
