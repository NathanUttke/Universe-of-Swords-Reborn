using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;


namespace UniverseOfSwordsMod.Projectiles
{
    public class ClingerSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;

            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.ownerHitCheck = true;
            Projectile.tileCollide = false;
            Projectile.width = Projectile.height = 64;

            Projectile.aiStyle = -1;
        }

        private float acceleration = 0.4f * MathHelper.PiOver4;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            player.heldProj = Projectile.whoAmI;
            player.itemRotation = Projectile.rotation;

            Projectile.ai[0]++;
            if (Projectile.ai[0] == 15f) 
            {
                Projectile.ai[0] = 0;
                acceleration *= -1f;
            }

            if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem || player.noItems || player.CCed || player.ownedProjectileCounts[Type] > 1))
            {
                Projectile.Kill();
            }

            Projectile.rotation += acceleration;
            Projectile.Center = player.MountedCenter;
            Projectile.spriteDirection = player.direction;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (Projectile.spriteDirection == -1)
            {
                spriteEffects = SpriteEffects.None;
            }

            spriteBatch.Draw(texture, new Vector2(Projectile.position.X - Main.screenPosition.X, Projectile.position.Y - Main.screenPosition.Y), null, Color.White, Projectile.rotation, new Vector2(0f, TextureAssets.Projectile[Type].Height()), Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}