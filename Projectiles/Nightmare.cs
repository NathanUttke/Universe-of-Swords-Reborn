using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles;

internal class Nightmare : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
    }
    public override void SetDefaults()
    {
        Projectile.width = 54;
        Projectile.height = 58;
        Projectile.scale = 1f;
        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.tileCollide = false;
        Projectile.ignoreWater = true;
        Projectile.timeLeft = 50;        
        Projectile.light = 0.25f;
    }

    public override void AI()
    {
        base.AI();
        float maxDetectRadius = 300f; 
        float projSpeed = 7.5f; 

        Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Purple with { A = 0 }, 2f);        

        Projectile.rotation = Projectile.velocity.ToRotation();
        Projectile.spriteDirection = Projectile.direction;     
        
        NPC closestNPC = UniverseUtils.FindClosestNPC(maxDetectRadius, Projectile.Center);
        if (closestNPC == null) 
        {
            return;
        }        
        Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.1f);
    }
    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        Player owner = Main.player[Projectile.owner];

        if (!target.HasBuff(BuffID.ShadowFlame))
        {
            target.AddBuff(BuffID.ShadowFlame, 800);
        }

        if (Main.rand.NextBool(3) && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type])
        {            
            owner.statLife += 2;   
            owner.HealEffect(2, true);
        }
    }

    public override Color? GetAlpha(Color lightColor) => new Color(195, 82, 255, 127);

    public override bool PreDraw(ref Color lightColor)
    {
        SpriteEffects spriteEffects = SpriteEffects.None;
        SpriteBatch spriteBatch = Main.spriteBatch;
        Texture2D voidTextureExtra = TextureAssets.Extra[131].Value;
        Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(Texture);
        Vector2 drawOrigin = texture.Size() / 2f;

        Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseofSwordsMod/Assets/GlowSphere");
        Color drawColorGlow = Color.Purple with { A = 0 };

        if (Projectile.spriteDirection == -1)
        {
            spriteEffects = SpriteEffects.FlipVertically;
        }

        spriteBatch.Draw(glowSphere, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColorGlow, Projectile.rotation, new Vector2(glowSphere.Width / 2, glowSphere.Height / 2), 1f, SpriteEffects.None, 0);

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = drawColorGlow * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(glowSphere, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, glowSphere.Size() / 2f, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
        }

        for (int i = 0; i < Projectile.oldPos.Length; i++)
        {
            float num = 10 - i;
            Color drawColor = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length);
            drawColor *= num / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);
            spriteBatch.Draw(voidTextureExtra, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation + Main.GlobalTimeWrappedHourly * 2f, drawOrigin, (Projectile.scale * 1.5f) - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
            spriteBatch.Draw(texture, (Projectile.oldPos[i] - Main.screenPosition) + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation, drawOrigin, (Projectile.scale) - i / (float)Projectile.oldPos.Length, spriteEffects, 0);
        }

        spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, null, Color.White, Projectile.rotation, drawOrigin, Projectile.scale, spriteEffects, 0);

        return false;
    }

    public override void Kill(int timeLeft)
    {

        int numOfProjectiles = 4;
        for (int i = 0; i < 15; i++)
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, Color.Purple with { A = 0 }, 2f);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.oldVelocity.X * 0.25f, Projectile.oldVelocity.Y * 0.25f, 0, Color.Purple with { A = 0 }, 2f);
        }
        
        SoundEngine.PlaySound(SoundID.DD2_SkeletonDeath, Projectile.position);
    }
}
