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
    public class DoomsdayProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.InfernoFriendlyBolt}";
        public override void SetDefaults()
        {
            Projectile.Size = new(16);
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 50;
            Projectile.extraUpdates = 1;
            Projectile.alpha = 255;
            Projectile.penetrate = 1;
            Projectile.aiStyle = -1;
        }

        public override void AI()
        {
            for (int i = 0; i < 30; i++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.Center, Projectile.width, Projectile.height, DustID.InfernoFork, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 100, default, 0.8f);
                fireDust.velocity *= 0.6f;
                fireDust.noGravity = true;
            }

            //Projectile.velocity.Y += 0.25f;
            Projectile.ai[0]++;
            if (Projectile.ai[0] % 5f == 0f)
            {
                Projectile smallFire = Projectile.NewProjectileDirect(Projectile.GetSource_FromAI(), Projectile.position, Vector2.UnitY * 5f, ProjectileID.WandOfSparkingSpark, Projectile.damage * 2, 0f, Projectile.owner);
                smallFire.timeLeft = 300;
                smallFire.usesLocalNPCImmunity = true;
                smallFire.localNPCHitCooldown = 17;
            }

            if (Projectile.ai[1] == 0f)
            {
                Projectile.ai[1] = 1f;
                for (int i = 0; i < 40; i++)
                {
                    Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.InfernoFork, 0f, 0f, 100, default, 0.8f);
                    fireDust.velocity *= 3f;
                    fireDust.velocity += Projectile.velocity * 0.75f;
                    fireDust.scale *= 1.2f;
                    fireDust.noGravity = true;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile geyserFire = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center, -Vector2.UnitY * 4f, ProjectileID.GeyserTrap, Projectile.damage * 2, 0f, Projectile.owner);
            geyserFire.hostile = false;
            geyserFire.usesLocalNPCImmunity = true;
            geyserFire.localNPCHitCooldown = 17;

            target.AddBuff(BuffID.OnFire, 300);
            target.AddBuff(BuffID.Weak, 300);
        }

        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 40; i++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.InfernoFork, 0f, 0f, 100, default, 0.8f);
                fireDust.velocity *= 3f;
                fireDust.velocity += Projectile.velocity * 0.75f;
                fireDust.scale *= 1.5f;
                fireDust.noGravity = true;
            }
        }
    }
}
