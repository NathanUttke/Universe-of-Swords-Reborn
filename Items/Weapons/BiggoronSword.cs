using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BiggoronSword : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword of The Legend");
		Tooltip.SetDefault("Heavy but strong");
	}

	public override void SetDefaults()
	{
		Item.width = 88;
		Item.height = 88;
		Item.scale = 1.9f;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 40;
		Item.damage = 40;
		Item.knockBack = 2f;
		Item.UseSound = SoundID.Item1;
		Item.value = 19000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
