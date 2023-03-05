using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class BeliarClaw : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Claw of Beliar");
		Tooltip.SetDefault("Pulses with dark energy of Beliar");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.scale = 1.5f;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 100;
		Item.knockBack = 12f;
		Item.UseSound = SoundID.Item1;
		Item.value = 611500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
	}
}
