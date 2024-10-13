using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class NatureProj : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Projectiles/InvisibleProj";

        public override void SetDefaults()
        {
            Projectile.Size = new(8);
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
        }

        public override void AI()
        {
            for (int i = 0; i < 20; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor:Color.ForestGreen, Scale:0.5f);
                dust.position = Projectile.Center - Projectile.velocity / 10f * i;
                dust.velocity *= 0.125f;
                dust.noGravity = true;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), newColor: Color.ForestGreen, Scale:1.5f);
                dust.velocity *= 4f;
                dust.noGravity = true;
            }
        }
    }
}
