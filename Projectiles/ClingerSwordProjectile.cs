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
            //Projectile.width = Projectile.height = 64;

            Projectile.aiStyle = -1;
            Projectile.rotation = -0.8f;
        }

        private float acceleration = 0.2f * MathHelper.PiOver4;
        
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            player.heldProj = Projectile.whoAmI;
            player.itemTime = player.itemAnimation = 2;
            player.itemRotation = Projectile.rotation;

            Projectile.ai[0]++;
            if (Projectile.ai[0] == 20f) 
            {
                Projectile.ai[0] = 0;
                acceleration *= -1f;
            }
            
            if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem || player.noItems || player.CCed))
            {
                Projectile.Kill();
            }


            Projectile.rotation += acceleration * player.direction;
            Projectile.position.X += player.width / 2 * player.direction;
            Projectile.Center = player.Center;
            Projectile.spriteDirection = player.direction;

            Projectile.AngleTo(Main.MouseWorld);
            //player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Quarter, Projectile.rotation);            
            player.ChangeDir(player.direction);
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

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f, TextureAssets.Projectile[Type].Height()), Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}