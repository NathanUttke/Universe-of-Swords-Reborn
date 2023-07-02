using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.NPCs.Bosses;

namespace UniverseOfSwordsMod.Items.Consumables
{
    public class SwordBossSummon : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityBossSpawns[Type] = 12;
            DisplayName.SetDefault("Suspicious Looking Sword");
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 28;
            Item.maxStack = 20;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(ModContent.NPCType<SwordBossNPC>());
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                SoundEngine.PlaySound(SoundID.Roar, player.position);
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    //NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SwordBossNPC>());
                    Vector2 spawnPosition = player.Center + new Vector2(500f * player.direction, 0f) + Main.rand.NextVector2Circular(100f, 100f);
                    NPC.SpawnBoss((int)spawnPosition.X, (int)spawnPosition.Y, ModContent.NPCType<SwordBossNPC>(), player.whoAmI);
                }
                else
                {
                    NetMessage.SendData(MessageID.SpawnBoss, player.whoAmI, ModContent.NPCType<SwordBossNPC>());
                }
            }
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
