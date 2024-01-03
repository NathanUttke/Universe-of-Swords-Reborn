using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using rail;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GnomeProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GardenGnome}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 13;
            ProjectileID.Sets.TrailingMode[Type] = 3;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.width = 32;
            Projectile.height = 30;
            Projectile.alpha = 64;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.125f;
            Projectile.light = 0.25f;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
            Projectile.extraUpdates = 1;
            Projectile.ArmorPenetration = 10;
            Projectile.timeLeft = 70;
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;       
        public override void AI()
        {
            base.AI();
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.ai[1] == 1f || target.immortal || NPCID.Sets.CountsAsCritter[target.type])
            {
                return;
            }
            int direction = Main.rand.Next(-1, 2) * 1;
            float screenPosX = Main.screenPosition.X;
            float screenPosY = Main.screenPosition.Y;
            if (direction < 0)
            {
                screenPosX += Main.screenWidth;
            }
            screenPosY += Main.rand.Next(Main.screenHeight);
            Vector2 screenPosition = new(screenPosX, screenPosY);
            Vector2 targetPos = new (target.Center.X - screenPosition.X, target.Center.Y - screenPosition.Y);
            targetPos.X += Main.rand.Next(-50, 51) * 0.1f;
            targetPos.Y += Main.rand.Next(-50, 51) * 0.1f;
            float targetDist = targetPos.Length();
            targetDist = 24f / targetDist;
            targetPos.X *= targetDist;
            targetPos.Y *= targetDist;
            Projectile.NewProjectile(target.GetSource_OnHit(target), screenPosition, targetPos, Type, (int)(Projectile.damage * 0.75f), Projectile.knockBack, Projectile.owner, 0f, 1f);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;            
            Texture2D texture = TextureAssets.Projectile[Type].Value;

            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color gnomTrailColor = new(11 + j * 16, 127, 255 - j * 16, 40);
                spriteBatch.Draw(texture, drawPos, null, gnomTrailColor, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, SpriteEffects.None, 0);
            }   

            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, Vector2.Zero, ProjectileID.SolarWhipSwordExplosion, (int)(Projectile.damage * 0.95f), 3f, Projectile.owner, 0f, 0f);
        }
    }
}
