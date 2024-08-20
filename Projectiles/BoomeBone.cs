using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class BoomeBone : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.BoneGloveProj}";

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Type] = 20;
            ProjectileID.Sets.TrailingMode[Type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.Size = new(14);
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.scale = 2f;
            Projectile.aiStyle = -1;
        }

        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {
            Dust dust = Dust.NewDustDirect(Projectile.position, 22, 22, DustID.Bone);
            dust.noGravity = true;

            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 15f)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.ai[1] = 0f;
                    Projectile.tileCollide = false;
                    Projectile.netUpdate = true;
                }
            }
            else
            {
                float acceleration = 2f;
                if (Vector2.Distance(Owner.Center, Projectile.Center) > 3000f)
                {
                    Projectile.Kill();
                }

                Vector2 vecTowardsPlayer = Projectile.DirectionTo(Owner.MountedCenter).SafeNormalize(Vector2.Zero);
                Projectile.velocity = Projectile.velocity.MoveTowards(vecTowardsPlayer * Owner.inventory[Owner.selectedItem].shootSpeed, acceleration);

                if (Main.myPlayer == Projectile.owner)
                {
                    if (Projectile.Hitbox.Intersects(Owner.Hitbox))
                    {
                        Projectile.Kill();
                    }
                }
            }

            Projectile.rotation += 0.5f * Projectile.direction;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            Projectile.ai[0] = 1f;
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Type].Value;
            Vector2 drawOrigin = texture.Size() / 2f;
            Color drawColor = Projectile.GetAlpha(lightColor);
            Color trailColor = drawColor;

            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = Projectile.oldPos[j] - Main.screenPosition + Projectile.Size / 2f + new Vector2(0f, Projectile.gfxOffY);
                trailColor *= 0.75f;
                Main.EntitySpriteDraw(texture, drawPos, null, trailColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, drawColor, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
