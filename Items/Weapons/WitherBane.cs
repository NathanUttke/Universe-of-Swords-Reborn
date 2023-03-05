using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WitherBane : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Wither Bane");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 42;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 19;
		Item.knockBack = 3f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void HoldStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X += 5f * (float)player.direction;
		player.itemLocation.Y += 5f * player.gravDir;
	}
}
