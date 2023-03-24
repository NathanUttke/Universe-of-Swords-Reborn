using Microsoft.Xna.Framework;
using System;
using System.Text.RegularExpressions;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace UniverseOfSwordsMod.Items.Misc
{
    public class BlackOreTest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Black Ore Scroll");
            Tooltip.SetDefault("Generates Black Ore in the world on use");
        }

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 14;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Red;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral("The world has been cursed with Black Ore"), new Color(41, 55, 41));
            }

            //in single player
            if (Main.netMode == NetmodeID.SinglePlayer)
            {
                Main.NewText("The world has been cursed with Black Ore", new Color(41, 55, 41));
            }
            //gen ore
            for (int i = 0; i < Main.maxTilesX / 4200 * 50; i++)
            {
                int num = WorldGen.genRand.Next(0, Main.maxTilesX);
                int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY - 300);
                Tile tile = Framing.GetTileSafely(num, Y);
                WorldGen.OreRunner(num, Y, (double)WorldGen.genRand.Next(8, 10), WorldGen.genRand.Next(3, 4), Mod.Find<ModTile>("BlackOreTile").Type);
            }
            return true;
        }
    }
}