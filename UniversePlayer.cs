using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

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
			Player player = ((ModPlayer)this).Player;
			player.lifeRegen -= 40000;
		}
	}
	public override void PostUpdateMiscEffects()
	{
		//if (QuiGin == true)
		{

		}
	}

	public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
	{
		if (eBlaze)
		{
			if (Main.rand.Next(8) == 0 && drawInfo.shadow == 0f)
			{
				int dust = Dust.NewDust(drawInfo.Position - new Vector2(2f, 2f), ((Entity)((ModPlayer)this).Player).width + 4, ((Entity)((ModPlayer)this).Player).height + 4, ((ModPlayer)this).Mod.Find<ModDust>("EmperorBlaze").Type, ((Entity)((ModPlayer)this).Player).velocity.X * 0.4f, ((Entity)((ModPlayer)this).Player).velocity.Y * 0.4f, 100, default(Color), 3f);
				Main.dust[dust].noGravity = true;
				Dust obj = Main.dust[dust];
				obj.velocity *= 0.8f;
				Main.dust[dust].velocity.Y -= 0.5f;
				//Main.playerDrawDust.Add(dust);
				Main.dust[(int)dust].noGravity = false;	
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
