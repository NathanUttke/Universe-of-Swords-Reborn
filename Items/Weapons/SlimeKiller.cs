using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SlimeKiller : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Sword that killed many slimes");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 14;
		Item.useAnimation = 14;
		Item.damage = 30;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 51800;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
	public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.Slimed))
		{
			target.AddBuff(BuffID.Slimed, 400);
		}
	}
}
