using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HeisenbergsFlask : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Heisenberg's Flask");
		Tooltip.SetDefault("'Hablan de un tal Heisenberg que ahora controla el mercado'");
	}

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 28;
		Item.scale = 1.2f;
		Item.rare = ItemRarityID.Cyan;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 50;
		Item.knockBack = 5f;
		Item.UseSound = SoundID.Item107;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
