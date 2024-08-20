using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles.Base;

namespace UniverseOfSwordsMod.Projectiles
{
    public class RedFlareEnergy : SwingEnergySwordProj
    {
        public override Color DustColor1 => Color.DarkRed;
        public override Color DustColor2 => Color.OrangeRed;

        public override Color BackDarkColor => new(192, 64, 64);
        public override Color MiddleMediumColor => Color.Red;

        public override Color FrontLightColor => Color.LightSalmon;

        public override float ScaleAdder => 0.8f;

        public override float ScaleMulti => base.ScaleMulti;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.owner == Main.myPlayer && !(NPCID.Sets.CountsAsCritter[target.type] && target.SpawnedFromStatue))
            {
                Projectile.NewProjectile(target.GetSource_OnHit(target), target.Center, Vector2.Zero, ModContent.ProjectileType<RedFlareInferno>(), Projectile.damage, Projectile.knockBack, Projectile.owner);
            }
        }
    }
}
