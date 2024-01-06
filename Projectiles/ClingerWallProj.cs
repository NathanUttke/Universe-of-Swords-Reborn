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
            Projectile.timeLeft = 100;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {            
            for (int i = 0; i < 8; i++)
            {
                int fireDust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, new Color(200, 255, 0, 0), 0.75f);
                Dust dust2 = Main.dust[fireDust];
                dust2.velocity *= 0.5f;
                Main.dust[fireDust].velocity.Y -= 0.5f;
                Main.dust[fireDust].position.X += 6f;
                Main.dust[fireDust].position.Y -= 2f;

            }
        }
    }
}
