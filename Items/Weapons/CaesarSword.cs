using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Drawing;
using Terraria.Graphics.Renderers;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;
public class CaesarSword : ModItem
{

    public override void SetStaticDefaults()
	{
		// Tooltip.SetDefault("'Et tu, Brute?'\nHold right click for a stabbing attack");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Green;

        Item.useStyle = ItemUseStyleID.Thrust;
        Item.UseSound = SoundID.Item1;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.damage = 32;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.knockBack = 3f;
        Item.crit = 8;

        Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.autoReuse = true;	
		Item.ResearchUnlockCount = 1;

	}


    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemHeight += (int)MathF.Sin(player.itemTime * player.direction);
    }
}
