﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{    
   
    public class PurpleRuneProjectile : ModProjectile
    {
        public override string Texture => $"UniverseofSwordsMod/Projectiles/InvisibleProj";

        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
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
            if (Projectile.ai[0] > 200f) 
            { 
                Projectile.Kill();
            }
            if (Projectile.ai[0] % 30f == 0)
            {                
                for (int i = 0; i < 20; i++)
                {
                    Dust.NewDust(Projectile.oldPosition, Projectile.width, Projectile.height, DustID.ShadowbeamStaff, Projectile.velocity.X, Projectile.velocity.Y);
                }
            }   
        }

    }
}
