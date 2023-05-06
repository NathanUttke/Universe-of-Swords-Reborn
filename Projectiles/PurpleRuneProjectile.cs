using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
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
                for (int i = 0; i < 21; i++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.VilePowder, Projectile.velocity.X, Projectile.velocity.Y);
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.ShadowFlame))
            {
                target.AddBuff(BuffID.ShadowFlame, 250);
            }
        }
    }
}
