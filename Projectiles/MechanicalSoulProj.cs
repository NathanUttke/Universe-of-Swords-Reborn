using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Drawing;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class MechanicalSoulProj : SwingEnergySwordProj
    {
        public override float ScaleAdder => 1.3f;
        public override float ScaleMulti => base.ScaleMulti;

        public override Color DustColor1 => Color.OrangeRed;
        public override Color DustColor2 => Color.SkyBlue;

        public override Color BackDarkColor => new(200, 64, 64);
        public override Color MiddleMediumColor => Color.Orange;
        public override Color FrontLightColor => Color.LightSalmon;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ParticleOrchestrator.RequestParticleSpawn(clientOnly: true, ParticleOrchestraType.Excalibur, new ParticleOrchestraSettings
            {
                PositionInWorld = target.Center
            });

            target.AddBuff(BuffID.Frostburn, 500);
            target.AddBuff(BuffID.OnFire, 500);
            target.AddBuff(BuffID.Oiled, 500);

            if (Projectile.owner == Main.myPlayer)
            {
                for (int i = 0; i < 3; i++)
                {
                    Vector2 targetOffset = target.position + new Vector2(Main.rand.Next(-200, 400), -Main.rand.Next(100, 300));
                    Vector2 targetVelocity = Vector2.Normalize(target.Center - targetOffset);
                    Projectile.NewProjectile(target.GetSource_OnHit(target), targetOffset, targetVelocity, ModContent.ProjectileType<SoulLaser>(), Projectile.damage / 2, 0f, Projectile.owner, Main.rand.Next(0, 3));
                }
            }
        }
    }
}
