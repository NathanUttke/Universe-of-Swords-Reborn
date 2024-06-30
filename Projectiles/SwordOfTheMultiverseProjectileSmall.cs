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
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 30;
            Projectile.scale = 1.25f;
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;           
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 300;
            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, 0.5f, 0.25f, 0.5f);
            if (Main.rand.NextBool(2))
            {
                Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Purple with { A = 0 }, 2f);
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(ModContent.BuffType<Buffs.EmperorBlaze>()))
            {
                target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 800, true);
            }
        }

        public override Color? GetAlpha(Color lightColor) => new Color(205, 143, 255, 0);

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);           
            
            Texture2D glowStar = TextureAssets.Extra[ExtrasID.SharpTears].Value;
            Color drawColorGlow = Color.HotPink with { A = 127 };
            Color color = Projectile.GetAlpha(lightColor);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);                
                
                color *= 0.75f;

                Main.EntitySpriteDraw(glowStar, drawPos, null, drawColorGlow * 0.75f, Projectile.rotation, glowStar.Size() / 2f, Projectile.scale - j / (float)Projectile.oldPos.Length, SpriteEffects.None, 0);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);               
                Main.EntitySpriteDraw(texture, drawPos, null, color * 0.5f, Projectile.rotation, drawOrigin, (Projectile.scale * 1.25f) - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);               
            }
            return true;
        }   
    }
}
