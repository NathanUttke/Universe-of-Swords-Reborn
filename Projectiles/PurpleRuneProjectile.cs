using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{    
   
    public class PurpleRuneProjectile : ModProjectile
    {
        public override string Texture => $"UniverseofSwordsMod/Projectiles/InvisibleProj";

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 4;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25;
        }

        public override void AI()
        {
            base.AI();

            Projectile.velocity *= 0.95f;
            Projectile.ai[0] += 1f;

            if (Projectile.ai[0] == 180f) 
            { 
                Projectile.Kill();
            }

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                for (int i = 0; i < 25; i++)
                {
                    Dust cloudDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), Projectile.velocity.X, Projectile.velocity.Y, 0, Color.MediumOrchid with { A = 0 }, 2f);
                    cloudDust.fadeIn = 3f;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.HasBuff(BuffID.ShadowFlame))
            {
                target.AddBuff(BuffID.ShadowFlame, 300);
            }
        }
    }
}
