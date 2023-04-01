using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class InnosWrath : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Pulses with light energy of Innos");
	}

	public override void SetDefaults()
	{
		Item.width = 124;
		Item.height = 124;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 90;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = 611500;
		Item.crit = 12;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		if (!target.HasBuff(BuffID.Bleeding))
		{
			target.AddBuff(BuffID.Bleeding, 400, false);
		}
	}
}
