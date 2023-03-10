using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GoblinKnife : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Fast and small knife of Goblins");
	}

	public override void SetDefaults()
	{
		Item.width = 40;
		Item.height = 40;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 9;
		Item.useAnimation = 9;
		Item.damage = 15;
		Item.knockBack = 2.5f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 10, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
