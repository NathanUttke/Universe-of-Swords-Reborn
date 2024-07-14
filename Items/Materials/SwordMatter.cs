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
        Item.ResearchUnlockCount = 25;
        ItemID.Sets.ItemIconPulse[Type] = true;
		ItemID.Sets.ItemNoGravity[Type] = true;
	}

	public override void SetDefaults()
	{
		Item.width = 20;
		Item.height = 20;
		Item.maxStack = Item.CommonMaxStack;
		Item.value = 0;
		Item.rare = ItemRarityID.Orange;
	}

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        float globalTimeWrapped = Main.GlobalTimeWrappedHourly;
        Texture2D texture = TextureAssets.Item[Type].Value;
		Texture2D pinkExtra = (Texture2D)ModContent.Request<Texture2D>($"{nameof(UniverseOfSwordsMod)}/Assets/GlowThing"); 

        var frame = texture.Frame();
		var pinkExtraFrame = pinkExtra.Frame();

        Vector2 origin = frame.Size() / 2f;
		Vector2 pinkOrigin = pinkExtraFrame.Size() / 2f;

        Vector2 vector2 = new(Item.width / 2 - origin.X, Item.height - frame.Height);
        Vector2 vectorPosition = Item.position - Main.screenPosition + origin + vector2;

		Color glowColor = Color.HotPink;
		glowColor.A = 50;

        spriteBatch.Draw(pinkExtra, vectorPosition, pinkExtraFrame, glowColor, rotation + globalTimeWrapped * 0.75f, pinkOrigin, scale + MathF.Sin(scale / 4f), SpriteEffects.None, 0f);
        spriteBatch.Draw(texture, vectorPosition, frame, Color.White, rotation, origin, scale + MathF.Sin(scale / 4f), SpriteEffects.None, 0f);
        spriteBatch.Draw(texture, vectorPosition, frame, Color.White with { A = 0 } * 0.25f, rotation, origin, scale * 1.5f + MathF.Sin(scale / 4f), SpriteEffects.None, 0f);
        return false;
    }
}
