using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PrimeSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pew, pew!");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 65;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item33;
		Item.value = 160000;
		Item.shoot = ProjectileID.LaserMachinegunLaser;
		Item.shootSpeed = 20f;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
