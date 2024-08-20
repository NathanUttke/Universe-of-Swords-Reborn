using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles.Base;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Projectiles
{
    public class ClingerSlashProj : SwingEnergySwordProj
    {
        public override float ScaleMulti => 0.6f;
        public override float ScaleAdder => 1f;

        public override Color DustColor1 => Color.Green;
        public override Color DustColor2 => Color.LimeGreen;

        public override Color BackDarkColor => new(127, 206, 64);
        public override Color MiddleMediumColor => new(185, 255, 74);
        public override Color FrontLightColor => new(255, 255, 159);

        public override void AI()
        {
            base.AI();
            Lighting.AddLight(Projectile.Center, 1f, 1f, 0.5f);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.owner == Main.myPlayer)
            {                
                for (int i = -1; i <= 1; i++)
                {
                    Projectile.NewProjectile(target.GetSource_OnHit(target), new(target.Center.X + 348f * i, target.Center.Y), Vector2.UnitX * 16f * -i, ModContent.ProjectileType<ClingerWallProj>(), Projectile.damage, 0f, Projectile.owner);
                }
            }
        }
    }
}
