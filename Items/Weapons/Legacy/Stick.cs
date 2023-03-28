using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons.Legacy
{
    public class Stick : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'You shouldn't have this'\nLegacy Item");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.scale = 10.0F;
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.damage = 999999;
            Item.knockBack = 100.0F;
            Item.UseSound = SoundID.Item1;
            Item.value = 15000;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation.Y -= 1f * player.gravDir;
        }
    }
}
