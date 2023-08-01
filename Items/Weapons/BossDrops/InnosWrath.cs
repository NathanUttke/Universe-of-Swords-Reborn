using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons.BossDrops;

public class InnosWrath : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Innos' Wrath");
		// Tooltip.SetDefault("Pulses with light energy of Innos");
	}

	public override void SetDefaults()
	{
		Item.width = 124;
		Item.height = 124;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 19;
		Item.useAnimation = 19;
		Item.damage = 80;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item169;
		Item.value = 611500;
		Item.crit = 13;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		if (!target.HasBuff(BuffID.Bleeding))
		{
			target.AddBuff(BuffID.Bleeding, 400, false);
		}
	}
}
