using Terraria;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Items;

public class BossBags : GlobalItem
{
	public override void OpenVanillaBag(string context, Player player, int arg)
	{
		var entitySource = player.GetSource_OpenItem(arg);

		if (context == "bossBag" && arg == 3319)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<CthulhuJudge>(), 1);
		}
		if (context == "bossBag" && arg == 3318)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<StickyGlowstickSword>(), 1);
		}
		if (context == "bossBag" && arg == 3320)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<TheEater>(), 1);
		}
		if (context == "bossBag" && arg == 3321)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<TheBrain>(), 1);
		}
		if (context == "bossBag" && arg == 3323)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<SwordOfPower>(), 1);
		}
		if (context == "bossBag" && arg == 3327)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<PrimeSword>(), 1);
		}
		if (context == "bossBag" && arg == 3326)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<TwinsSword>(), 1);
		}
		if (context == "bossBag" && arg == 3325)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<DestroyerSword>(), 1);
		}
		if (context == "bossBag" && arg == 3328)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<Executioner>(), 1);
		}
		if (context == "bossBag" && arg == 3329)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<Golem>(), 1);
		}
		if (context == "bossBag" && arg == 3331)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<Doomsday>(), 1);
		}
		if (context == "bossBag" && arg == 3330)
		{
			player.QuickSpawnItem(entitySource, ModContent.ItemType<Sharkron>(), 1);
		}
	}
}
