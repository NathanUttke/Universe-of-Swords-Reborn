using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class FeatherDuster : ModItem
{
	public override void SetDefaults()
	{
		Item.width = 36;
		Item.height = 36;
		Item.scale = 1.2f;
		Item.rare = ItemRarityID.Blue;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 25;
		Item.damage = 18;
		Item.knockBack = 1.5f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = Mod.Find<ModProjectile>("HarpyFeather").Type;
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 0, 14, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y += 1f * player.gravDir;
	}
}
