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
	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Green;

        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.damage = 32;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.knockBack = 3f;
        Item.crit = 8;

        Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.autoReuse = true;	
		Item.ResearchUnlockCount = 1;

	}

    private int swingCount = 0;

    public override bool? UseItem(Player player)
    {
        swingCount++;
        if (swingCount < 3)
        {
            Item.useStyle = ItemUseStyleID.Swing;
        }
        else if (swingCount == 3) 
        {
            Item.useStyle = ItemUseStyleID.Thrust;
            swingCount = 0;
        }
        return true;
    }
}
