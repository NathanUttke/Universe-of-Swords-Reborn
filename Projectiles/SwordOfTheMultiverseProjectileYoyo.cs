using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Shaders;
using Terraria.Graphics;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Items.Weapons;

namespace UniverseOfSwordsMod.Projectiles
{    
    public class SwordOfTheMultiverseProjectileYoyo : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<SwordOfTheMultiverse>().Texture;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 4;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(94);
            Projectile.scale = 2f;
            Projectile.alpha = 0;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.extraUpdates = 2;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 12;            
        }

        Player Player => Main.player[Projectile.owner];

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, 1.5f, 1f, 1.5f);            

            if (Projectile.owner == Main.myPlayer && (!Player.controlUseItem))
            {
                Projectile.Kill();
                return;
            }

            if (Player.dead || !Player.active)
            {
                Projectile.Kill();
                return;
            }

            Player.heldProj = Projectile.whoAmI;
            Player.itemTime = Player.itemAnimation = 2;

            Projectile.velocity = Vector2.Zero;
            Projectile.Center = Main.MouseWorld;
            Projectile.rotation += Projectile.direction * 0.13f;            
        }      
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
            {
                target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 800, true);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;

            Texture2D glowSphere = (Texture2D)ModContent.Request<Texture2D>("UniverseOfSwordsMod/Assets/GlowSphere");
            Color drawColorGlow = Color.Purple with { A = 0 };
            Color drawColorTrail = Color.Magenta with { A = 0 };
            Vector2 drawPos = Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 trailPos = Projectile.oldPos[j] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);

                drawColorTrail *= 0.75f;

                Main.EntitySpriteDraw(texture, drawPos, null, drawColorTrail, Projectile.oldRot[j] - MathHelper.PiOver4, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, drawPos, null, Color.White, Projectile.rotation - MathHelper.PiOver4, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            Main.EntitySpriteDraw(glowSphere, drawPos, null, drawColorGlow, Projectile.rotation, glowSphere.Size() / 2f, 2f + Projectile.scale, SpriteEffects.None, 0);
            
            return false;
        }
    }
}
