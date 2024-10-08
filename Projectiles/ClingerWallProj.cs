using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Dusts;
using Microsoft.Xna.Framework;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class ClingerWallProj : ModProjectile
    {
        public override string Texture => ModContent.GetInstance<ClingerSword>().Texture;
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 64;
            Projectile.aiStyle = -1;
            Projectile.alpha = 255;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 90;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {            
            for (int i = 0; i < 8; i++)
            {
                Dust fireDust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(150, 255, 0, 0), 0.75f);
                fireDust.position += Projectile.velocity / 20f * i;
                fireDust.velocity.Y *= 0.5f;
                //fireDust.position.X += 6f;
                //fireDust.position.Y -= 2f;
            }
        }
    }
}
