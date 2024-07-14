using Humanizer;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheMultiverseProjectileSmall : ModProjectile
    {
        public override void SetStaticDefaults()
        {            
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 20;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.scale = 1.25f;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;           
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 300;
            //AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.5f, 0.25f, 0.5f);
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Main.rand.NextBool(2))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Purple, 1.5f);
                dust.velocity *= 0.5f;
                dust.velocity -= Projectile.velocity * 0.2f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<Buffs.EmperorBlaze>()))
            {
                target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 800, true);
            }
        }

        public override void OnKill(int timeLeft)
        {
            //SoundEngine.PlaySound(SoundID.DD2_GoblinBomberThrow with { Pitch = 0f, Volume = 0.5f }, Projectile.position);
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Purple, 2f);
                dust.velocity *= 8f;
            }
            Projectile.Damage();
        }

        public override Color? GetAlpha(Color lightColor) => new Color(205, 143, 255, 0);

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, 0f);           
            
            Texture2D glowStar = TextureAssets.Extra[ExtrasID.SharpTears].Value;
            Color drawColorGlow = Color.Magenta with { A = 0 };
            Color color = Projectile.GetAlpha(lightColor);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + Projectile.Size / 2 + new Vector2(0f, Projectile.gfxOffY);                
                
                color *= 0.75f;
                drawColorGlow *= 0.75f;

                Main.EntitySpriteDraw(glowStar, drawPos, null, drawColorGlow, Projectile.rotation, glowStar.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);               
                Main.EntitySpriteDraw(texture, drawPos, null, color * 0.25f, Projectile.rotation, drawOrigin, (Projectile.scale * 1.5f) - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);               
            }
            return false;
        }   
    }
}
