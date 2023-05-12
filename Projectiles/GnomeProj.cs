using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace UniverseOfSwordsMod.Projectiles
{
    internal class GnomeProj : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.GardenGnome}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 13;
            ProjectileID.Sets.TrailingMode[Type] = 2;
        }
        public override void SetDefaults()
        {
            Projectile.aiStyle = ProjAIStyleID.Arrow;
            Projectile.friendly = true;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.width = 32;
            Projectile.height = 30;
            Projectile.alpha = 64;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.125f;
            Projectile.light = 0.25f;
            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            base.AI();
        }

        public override Color? GetAlpha(Color lightColor) => Color.White;

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            SpriteEffects spriteEffects = Projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);            

            for (int j = 0; j < Projectile.oldPos.Length - 1; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = new(11 + j * 5, 127, 255 - j * 5, 40);
                spriteBatch.Draw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - j / (float) Projectile.oldPos.Length, spriteEffects, 0);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
            Projectile.NewProjectile(Projectile.GetSource_Death(), Projectile.position, Vector2.Zero, ProjectileID.DaybreakExplosion, (int)(Projectile.damage * 0.95f), 3f, Projectile.owner);
        }
    }
}
