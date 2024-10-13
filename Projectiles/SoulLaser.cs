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
    public class SoulLaser : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.WoodenArrowFriendly}";

        public override void SetDefaults()
        {
            Projectile.Size = new(4);
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.extraUpdates = 100;
            Projectile.timeLeft = 600;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
        }

        public override void AI()
        {
            int dustType = (int)Projectile.ai[0];
            Color dustColor = Color.White;

            switch (dustType)
            {
                case 0:
                    dustColor = Color.Red;
                    break;
                case 1:
                    dustColor = Color.Green;
                    break;
                case 2:
                    dustColor = Color.Blue;
                    break;
            }

            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(Projectile.Center, 1, 1, ModContent.DustType<GlowDust>(), newColor:dustColor, Scale:0.75f);
                dust.velocity *= 0f;
                dust.position = Projectile.Center - Projectile.velocity * (i * 0.25f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.position.X += Projectile.velocity.X;
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.position.Y += Projectile.velocity.Y;
                Projectile.velocity.Y = -oldVelocity.Y;
            }

            return false;
        }
    }
}
