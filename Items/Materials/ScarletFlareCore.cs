using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Items.Materials;

public class ScarletFlareCore : ModItem
{
	public override void SetStaticDefaults()
	{
        Item.ResearchUnlockCount = 3;
        ItemID.Sets.ItemNoGravity[Type] = false;
    }

	public override void SetDefaults()
	{
		Item.width = 28;
		Item.height = 50;
		Item.maxStack = 99;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.rare = ItemRarityID.Red;        
		Item.ResearchUnlockCount = 3;        
    }

    public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
    {
        float globalTimeWrapped = Main.GlobalTimeWrappedHourly;
        float itemTime = Item.timeSinceItemSpawned / 240f + globalTimeWrapped * 0.04f;
        Texture2D texture = TextureAssets.Item[Type].Value;

        var frame = texture.Frame();

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Red with { A = 0 };

        Vector2 origin = frame.Size() / 2f;
        Vector2 vector2 = new(Item.width / 2 - origin.X, Item.height - frame.Height);
        Vector2 vectorPosition = Item.position - Main.screenPosition + origin + vector2;

        spriteBatch.Draw(glowSphere, vectorPosition, null, drawColorGlow, Item.velocity.X, glowSphere.Size() / 2, Item.scale, SpriteEffects.None, 0);

        globalTimeWrapped %= 4f;
        globalTimeWrapped /= 2f;

        if (globalTimeWrapped >= 1f)
        {
            globalTimeWrapped = 2f - globalTimeWrapped;
        }
        globalTimeWrapped = globalTimeWrapped / 2f + 0.5f;
        for (float i = 0f; i < 1f; i += 0.25f)
        {
            spriteBatch.Draw(texture, vectorPosition + new Vector2(0.5f, 8f).RotatedBy((i + itemTime) * MathHelper.TwoPi) * globalTimeWrapped, frame, new Color(255, 145, 70, 50), Item.velocity.X * 0.2f, origin, Item.scale, SpriteEffects.None, 0f);
        }
        for (float i = 0f; i < 1f; i += 0.35f)
        {
            spriteBatch.Draw(texture, vectorPosition + new Vector2(0.5f, 4f).RotatedBy((i + itemTime) * MathHelper.TwoPi) * globalTimeWrapped, frame, new Color(255, 119, 119, 80), Item.velocity.X * 0.25f, origin, Item.scale, SpriteEffects.None, 0f);
        }

        spriteBatch.Draw(texture, vectorPosition, frame, Color.White, rotation, origin, scale, SpriteEffects.None, 0f);

        return false;
    }
}
