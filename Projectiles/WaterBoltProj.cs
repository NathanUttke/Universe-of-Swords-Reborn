using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;

namespace UniverseOfSwordsMod.Projectiles
{
    public class WaterBoltProj : ModProjectile
    {
        public override string Texture => "UniverseOfSwordsMod/Projectiles/InvisibleProj";
        public override void SetDefaults()
        {
            Projectile.Size = new(16);
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 70;
        }

        public override void AI()
        {
            if (Projectile.ai[0] >= 3f)
            {
                Projectile.Kill();
            }
            Lighting.AddLight(Projectile.position, Color.Blue.ToVector3() * 0.5f);
            for (int i = 0; i < 16; i++)
            {
                Vector2 spinPoint = (Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 16f) * new Vector2(0.5f, 1f)).RotatedBy(Projectile.velocity.ToRotation());
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Blue, Alpha:100);
                dust.position = Projectile.Center + spinPoint;
                dust.velocity = spinPoint;
                dust.noGravity = true;
                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Blue, Alpha: 200, Scale:1.125f);
                dust2.noGravity = true;
                dust2.velocity *= 0.1f;
                dust2.position = Projectile.Center;
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.ai[0]++;
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            for (int i = 0; i < 16; i++)
            {
                Vector2 spinPoint = Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 16f) * 4f;
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Blue, Alpha: 100, Scale:2f);
                dust.position = Projectile.Center;
                dust.velocity = spinPoint;
                dust.noGravity = true;
            }
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            return false;
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 16; i++)
            {
                Vector2 spinPoint = Vector2.UnitY.RotatedBy(i * MathHelper.TwoPi / 16f) * 4f;
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Blue, Alpha: 100, Scale: 1.5f);
                dust.position = Projectile.Center;
                dust.velocity = spinPoint;
                dust.noGravity = true;
            }
        }
    }
}
