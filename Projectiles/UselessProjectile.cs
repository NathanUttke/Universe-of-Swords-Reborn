using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class UselessProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.ownerHitCheck = true;
            Projectile.extraUpdates = 1;
            Projectile.aiStyle = ProjAIStyleID.ShortSword;
        }

        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;
            SetVisualOffsets();
        }

        private void SetVisualOffsets()
        {
            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 2;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((62 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((56 / 2) - halfProjHeight);
        }
    }
}
