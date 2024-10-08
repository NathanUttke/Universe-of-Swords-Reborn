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
    public class MultiverseProjectileSmall : ModProjectile
    {
        public override void SetStaticDefaults()
        {            
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.Size = new(16);
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

        Player Player => Main.player[Projectile.owner];
        public override void AI()
        {
            Lighting.AddLight(Projectile.position, Color.Magenta.ToVector3());
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.tileCollide = Projectile.Center.Y >= Player.Center.Y;

            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.Purple, Scale: 0.5f);
            dust.velocity *= 0.5f;
            dust.position = Projectile.Center - Projectile.velocity / 20f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Buffs.EmperorBlaze>(), 800, true);
        }

        public override void OnKill(int timeLeft)
        {
            Projectile.Resize(144, 144);
            for (int i = 0; i < 20; i++)
            {
                Vector2 newVelocity = Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 20f) * 10f;
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.Purple, Scale:1.5f);
                dust.position = Projectile.Center - Projectile.velocity / 10f * i;
                dust.velocity = newVelocity;
            }
            Projectile.Damage();
        }

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Main.instance.LoadProjectile(ProjectileID.StardustTowerMark);

            Vector2 drawOrigin = Vector2.UnitX * texture.Width / 2;           
            
            Color drawColorGlow = Color.Magenta with { A = 0 } * Projectile.Opacity;
            Color startColor = Color.HotPink with { A = 0 } * Projectile.Opacity;
            Color endColor = Color.Magenta with { A = 0 } * Projectile.Opacity;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] + Projectile.Size / 2 - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY);

                Color drawColor = Color.Lerp(startColor, endColor, j * 0.125f) * (1f - j * 0.125f);
                drawColorGlow *= 0.75f;

                Main.EntitySpriteDraw(texture, drawPos, null, drawColor, Projectile.rotation, drawOrigin, MathHelper.Lerp(Projectile.scale, 1.75f, j * 0.35f), SpriteEffects.None, 0);
            }
            return false;
        }   
    }
}
