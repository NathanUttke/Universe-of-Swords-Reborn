using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace UniverseOfSwordsMod.Projectiles;

public class FlareCore : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 25;
        Projectile.height = 50;
        Projectile.scale = 1.1f;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        Projectile.usesLocalNPCImmunity = true;
        Projectile.localNPCHitCooldown = 15;
        base.AIType = 14;
    }

    public override void PostAI()
    {      
        Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LifeDrain, 0f, 0f, 0, default, 1f);
        obj.noGravity = true;
        obj.scale = 1f;        
    }
    public override bool PreDraw(ref Color lightColor)
    {
        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Red;

        Main.EntitySpriteDraw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 1.125f, SpriteEffects.None, 0);

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

        Texture2D texture = TextureAssets.Projectile[Type].Value;
        Rectangle sourceRectangle = new(0, 0, texture.Width, texture.Height);
        Vector2 origin = sourceRectangle.Size() / 2;


        Main.spriteBatch.Draw(texture, new Vector2(Projectile.position.X - Main.screenPosition.X + Projectile.width / 2, Projectile.position.Y - Main.screenPosition.Y + Projectile.height / 2), sourceRectangle, Color.White, Projectile.rotation, origin, Projectile.scale, SpriteEffects.None, 0);

        Main.spriteBatch.End();
        Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, null, null, null, Main.GameViewMatrix.TransformationMatrix);

        return false;
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {       
        if (Main.rand.NextBool(2) && !target.HasBuff(BuffID.OnFire))
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}
