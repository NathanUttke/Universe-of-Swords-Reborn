using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.NPCs;

namespace UniverseOfSwordsMod.Buffs;

public class EmperorBlaze : ModBuff
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Emperor Blaze");
		Description.SetDefault("Losing life");
		Main.debuff[Type] = true;
		Main.pvpBuff[Type] = true;
		Main.buffNoSave[Type] = true;
		BuffID.Sets.LongerExpertDebuff[Type] = true;/* tModPorter Note: Removed. Use BuffID.Sets.LongerExpertDebuff instead */
	}

	public override void Update(Player player, ref int buffIndex)
	{
		player.GetModPlayer<UniversePlayer>().eBlaze = true;
	}

	public override void Update(NPC npc, ref int buffIndex)
	{
		npc.GetGlobalNPC<UniverseOfSwordsModGlobalNPC>().eBlaze = true;
	}
}
