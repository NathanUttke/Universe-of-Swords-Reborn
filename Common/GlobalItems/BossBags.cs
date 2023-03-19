using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Items;

public class BossBags : GlobalItem
{
	public override void OpenVanillaBag(string context, Player player, int arg)
	{
		var entitySource = player.GetSource_OpenItem(arg);

		if (context == "bossBag")
		{
			switch (arg)
			{
				case 3319:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<CthulhuJudge>(), 1);
					break;
				case 3320:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<TheEater>(), 1);
                    break;
                case 3321:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<TheBrain>(), 1);
                    break;
				case 3323:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<SwordOfPower>(), 1);
                    break;
                case 3324:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<BiggoronSword>(), 1);
                    break;
				case 3326:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<TwinsSword>(), 1);
                    break;
				case 3327:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<PrimeSword>(), 1);
                    break;
				case 3328:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<Executioner>(), 1);
                    break;
				case 3330:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<Sharkron>(), 1);
                    break;
                case 3331:
                    player.QuickSpawnItem(entitySource, ModContent.ItemType<Doomsday>(), 1);
                    break;
                case ItemID.MoonLordBossBag:
                    if (Main.rand.NextBool(100))
                    {
                        player.QuickSpawnItem(entitySource, ModContent.ItemType<StarMaelstorm>(), 1);
                    }
                    break;

            }
		}
	}
}
