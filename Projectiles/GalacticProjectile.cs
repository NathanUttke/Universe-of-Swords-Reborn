using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GalacticProjectile : ModProjectile
    {
        public override string Texture => "UniverseofSwordsMod/Projectiles/InvisibleProj";
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 0;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 54;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.light = 0.75f;
            Projectile.scale = 1f;
            Projectile.penetrate = 1; 
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 90;
            Projectile.noEnchantmentVisuals = true;
        }

        public override void AI()
        {
            float projSpeed = 8f;

            Projectile.velocity *= 0.97f;

            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(58, 211, 197, 0), 2f);
            }

            NPC closestNPC = UniverseUtils.FindClosestNPC(400f, Projectile.position);
            if (closestNPC == null) 
            {
                return;
            }
            Projectile.velocity = Vector2.Lerp(Projectile.velocity, (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed, 0.15f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.Weak))
            {
                target.AddBuff(BuffID.Weak, 400);
            }
            if (!target.HasBuff(BuffID.Frostburn))
            {
                target.AddBuff(BuffID.Frostburn, 400);
            }
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.position);
            for (int i = 0; i < 14; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(58, 211, 197, 0), 1f);
                dust.velocity *= 4f;
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(255 - Projectile.alpha, 255 - Projectile.alpha, 255 - Projectile.alpha, 0);    
        
        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Texture2D galacTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowThing_Cyan");
            Texture2D glowTexture = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");

            Vector2 drawOriginGlow = glowTexture.Size() / 2f;
            Vector2 drawOriginThing = galacTexture.Size() / 2f;

            Color drawColorExtra = new(58, 211, 197, 0);
            Color drawColor = Projectile.GetAlpha(lightColor);
            Color drawColorGalac = drawColor;

            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + (Projectile.Size / 2f);

                drawColorExtra *= 0.75f;
                drawColorGalac *= 0.75f;

                spriteBatch.Draw(galacTexture, drawPos, null, drawColorGalac, Projectile.rotation + Main.GlobalTimeWrappedHourly * 3f, drawOriginThing, Projectile.scale - j / (float) Projectile.oldPos.Length, spriteEffects, 0);
                spriteBatch.Draw(glowTexture, drawPos, null, drawColorExtra, Projectile.rotation, drawOriginGlow, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            spriteBatch.Draw(galacTexture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, drawColor, Projectile.rotation + Main.GlobalTimeWrappedHourly * 3f, drawOriginThing, 1.25f, spriteEffects, 1);
            return false;
        }
    }
}
