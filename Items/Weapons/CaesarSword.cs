using Microsoft.Xna.Framework;
using System;
using System.IO;
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
		Item.Size = new(62);
		Item.rare = ItemRarityID.Green;

        Item.useStyle = ItemUseStyleID.Thrust;
        Item.UseSound = SoundID.Item1;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.damage = 32;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.knockBack = 3f;
        Item.crit = 8;

        Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.autoReuse = true;
        Item.useTurnOnAnimationStart = true;
		Item.ResearchUnlockCount = 1;
	} 
}
