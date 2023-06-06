using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles;

public class VugarMutaterProjectile : ModProjectile
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Vugar Mutater");
		ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
		ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
	}

	public override void SetDefaults()
	{
		Projectile.width = 20;
		Projectile.height = 25;
		Projectile.aiStyle = 1;
		Projectile.friendly = true;
		Projectile.DamageType = DamageClass.Melee;
		Projectile.penetrate = -1;
		Projectile.alpha = 255;
		Projectile.light = 0.5f;
		Projectile.ignoreWater = true;
		Projectile.tileCollide = false;
		Projectile.extraUpdates = 1;

        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 16;

        AIType = 14;        
	}
    public override void AI()
    {
        base.AI();
        if (Main.rand.NextBool(2))
        {
            Dust newDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.IceTorch, 0f, 0f, 127, default, 1.15f);
            newDust.noGravity = true;
        }
    }
    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
        Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/VugarMutaterGlow");
        Vector2 glowOrigin = new(glowSphere.Width / 2, Projectile.height / 2);
        Color drawColorGlow = Color.Cyan;

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, SamplerState.LinearWrap, null, null, null, Main.GameViewMatrix.TransformationMatrix);

        Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, glowOrigin, 1.1f, SpriteEffects.None, 0);

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

        for (int j = 0; j < Projectile.oldPos.Length; j++)
        {
            Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

            Color color = Lighting.GetColor((int)(Projectile.position.X + (double)Projectile.width / 2) / 16, (int)((Projectile.position.Y + Projectile.height * 0.5) / 16.0));
            color = Projectile.GetAlpha(color);
            float multValue = 8 - j;
            color *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

            Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, MathHelper.Lerp(Projectile.scale, 1f, j / 15f), SpriteEffects.None, 0);

        }
        return true;
    }
}
