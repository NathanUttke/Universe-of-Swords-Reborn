using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection.Metadata.Ecma335;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Materials;

public class SwordMatter : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Sword Matter");
		Tooltip.SetDefault("'Matter of all swords'");
		ItemID.Sets.ItemIconPulse[Item.type] = true;
		ItemID.Sets.ItemNoGravity[Item.type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = 9999;
		Item.value = 0;
		Item.rare = ItemRarityID.Orange;
		SacrificeTotal = 25;
	}

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        float globalTimeWrapped = Main.GlobalTimeWrappedHourly;
        Texture2D texture = TextureAssets.Item[Type].Value;
		Texture2D pinkExtra = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowThing"); 

        var frame = texture.Frame();
		var pinkExtraFrame = pinkExtra.Frame();

        Vector2 origin = frame.Size() / 2f;
		Vector2 pinkOrigin = pinkExtraFrame.Size() / 2f;

        Vector2 vector2 = new(Item.width / 2 - origin.X, Item.height - frame.Height);
        Vector2 vectorPosition = Item.position - Main.screenPosition + origin + vector2;

		Color whiteColor = Color.HotPink;
		whiteColor.A = 30;

        spriteBatch.Draw(pinkExtra, vectorPosition, pinkExtraFrame, whiteColor, rotation + globalTimeWrapped * 0.75f, pinkOrigin, scale + MathF.Sin(scale / 4f), SpriteEffects.None, 0f);
        spriteBatch.Draw(texture, vectorPosition, frame, Color.White, rotation, origin, scale + MathF.Sin(scale / 4f), SpriteEffects.None, 0f);
        return false;
    }
}
