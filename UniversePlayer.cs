using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using Terraria.ID;
using UniverseOfSwordsMod.Buffs;
using System;

namespace UniverseOfSwordsMod;

public class UniversePlayer : ModPlayer
{
	public bool eBlaze;
	public int swordTimer;

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

    public override void PostUpdate()
    {
        if (swordTimer > 0)
		{
			swordTimer--;
		}
    }

    public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
	{
		if (eBlaze)
		{
			if (Main.rand.NextBool(8) && drawInfo.shadow == 0f)
			{
				Dust dust = Dust.NewDustDirect(drawInfo.Position - Vector2.One * 2f, Player.width + 4, Player.height + 4, ModContent.DustType<Dusts.EmperorBlaze>(), 0f, Player.velocity.Y * 0.4f, 0, new Color(255, 255, 255, 0), 3f);
				dust.noGravity = true;
				Dust obj = dust;
				obj.velocity.X = 0;
				obj.velocity.Y *= 0.8f;
				dust.velocity.Y -= 0.5f;				
				dust.noGravity = false;	
			}
			r *= 1f;
			g *= 0.5f;
			b *= 0f;
			fullBright = true;
		}
	}

    public void GetPointOnSwungItemPath(float spriteWidth, float spriteHeight, float normalizedPointOnPath, float itemScale, out Vector2 location, out Vector2 outwardDirection)
    {
        float sqrtItemSize = MathF.Sqrt(spriteWidth * spriteWidth + spriteHeight * spriteHeight);
        float num2 = (Player.direction == 1).ToInt() * MathHelper.PiOver2;
        if (Player.gravDir == -1f)
        {
            num2 += MathHelper.PiOver2 * Player.direction;
        }
        outwardDirection = Player.itemRotation.ToRotationVector2().RotatedBy(MathHelper.Pi + MathHelper.PiOver4 + num2);
        location = Player.RotatedRelativePoint(Player.itemLocation + outwardDirection * sqrtItemSize * normalizedPointOnPath * itemScale);
    }

    public virtual bool ConsumeAmmo(Item weapon, Item ammo) => true;
}
