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
            Projectile.Size = new(40);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 4;
            Projectile.alpha = 255;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25;
            Projectile.timeLeft = 180;
        }

        public override void AI()
        {
            Projectile.velocity *= 0.95f;

            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0, 0, 0, Color.MediumOrchid, 1.25f);
                dust.velocity *= 0.5f;
                dust.velocity += Projectile.velocity * 0.2f;
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
