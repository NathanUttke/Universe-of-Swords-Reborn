using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WolfDestroyer : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Great for impersonating Werewolf hunters'");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 13;
		Item.useAnimation = 13;
		Item.damage = 61;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.value = 71800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
