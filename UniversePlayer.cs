using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod;

public class UniversePlayer : ModPlayer
{
	public bool eBlaze;

	public override void ResetEffects()
	{
		eBlaze = false;
	}

	public override void UpdateBadLifeRegen()
	{
		if (eBlaze)
		{			
			Player.lifeRegen -= 75;
		}
	}
	
	public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
	{
		if (eBlaze)
		{
			if (Main.rand.NextBool(8) && drawInfo.shadow == 0f)
			{
				int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), Player.width + 4, Player.height + 4, ModContent.DustType<EmperorBlaze>(), Player.velocity.X * 0.4f, Player.velocity.Y * 0.4f, 100, default(Color), 3f);
				Main.dust[dust].noGravity = true;
				Dust obj = Main.dust[dust];
				obj.velocity *= 0.8f;
				Main.dust[dust].velocity.Y -= 0.5f;				
				Main.dust[dust].noGravity = false;	
			}
			r *= 1f;
			g *= 0.5f;
			b *= 0f;
			fullBright = true;
		}
	}

	public virtual bool ConsumeAmmo(Item weapon, Item ammo)
	{
		return true;
	}
}
