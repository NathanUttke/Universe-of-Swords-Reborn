using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics.Shaders;
using System;
using Microsoft.Xna.Framework;

namespace UniverseOfSwordsMod.Dusts;


public class EmperorBlaze : ModDust
{
    public override string Texture => "UniverseOfSwordsMod/Dusts/EmperorBlaze";
    public override void OnSpawn(Dust dust)
	{
		dust.velocity.Y *= 0.75f;
		dust.noGravity = true;
		dust.scale = 0.5f;
		dust.noLight = true;	
		//dust.shader = new ArmorShaderData(new Ref<Effect>(Mod.Assets.Request<Effect>("Assets/Effects/GlowEffect", AssetRequestMode.ImmediateLoad).Value), "GlowEffectPass");
	}
	public override bool Update(Dust dust)
	{
		dust.position.Y += dust.velocity.Y;
		dust.rotation += 0.015f;	
		if (dust.scale < 1.15f)
		{
            dust.scale += 0.0030f;
        }
		else
		{
            dust.alpha += 48;
            if (dust.alpha >= 255)
            {
                dust.active = false;
            }
        }
		return false;
	}
}
