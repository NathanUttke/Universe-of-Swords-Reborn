using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PhantomScimitar : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Phantom Scimitar");
		Tooltip.SetDefault("Inflicts Shadowflame on hit");
	}

	public override void SetDefaults()
	{
		Item.width = 48;
		Item.height = 56;
		Item.scale = 1.1f;
		Item.rare = ItemRarityID.LightPurple;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 40;
		Item.knockBack = 7f;
		Item.UseSound = SoundID.Item104;
		Item.value = Item.sellPrice(0, 3, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(153, 400, false);
	}
}
