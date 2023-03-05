using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class WitchKingsDaughter : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("The Witch King's Daughter");
		Tooltip.SetDefault("Inflicts enemies with Cursed Flames");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.scale = 1.2f;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 54;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}

	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(39, 600, false);
	}
}
