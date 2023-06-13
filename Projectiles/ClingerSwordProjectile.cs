using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
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
            player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, Projectile.rotation - MathHelper.PiOver2);            
            player.ChangeDir(player.direction);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.HasBuff(BuffID.CursedInferno))
            {
                target.AddBuff(BuffID.CursedInferno, 300);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            SpriteBatch spriteBatch = Main.spriteBatch;

            spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, Color.White, Projectile.rotation, new Vector2(0f * Main.player[Projectile.owner].direction, TextureAssets.Projectile[Type].Height()), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}