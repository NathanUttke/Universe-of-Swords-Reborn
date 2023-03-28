using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class BiggoronSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sword of The Legend");
            Tooltip.SetDefault("Heavy but strong");
        }

        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            player.itemLocation = player.Center;
        }

        public override void SetDefaults()
        {
            Item.width = 90;
            Item.height = 90;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 40;
            Item.useAnimation = 40;
            Item.autoReuse = true;

            Item.damage = 42;
            Item.DamageType = DamageClass.Melee;

            Item.knockBack = 2f;
            Item.UseSound = SoundID.Item1;

            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.LightRed;

            SacrificeTotal = 1;
        }
    }
}


