﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{
    public class SwordOfTheMultiverseProjectileSmall : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 10;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 30;
            Projectile.scale = 1.25f;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.alpha = 0;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 8;
            AIType = ProjectileID.Bullet;
        }

        public override Color? GetAlpha(Color lightColor) => new Color(205, 143, 255, 0) * Projectile.Opacity;

        public override bool PreDraw(ref Color lightColor)
        {            
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);
            for (int j = 0; j < Projectile.oldPos.Length; j++)
            {
                Vector2 drawPos = (Projectile.oldPos[j] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color color = Lighting.GetColor((int)(Projectile.position.X + (double)Projectile.width / 2) / 16, (int)((Projectile.position.Y + Projectile.height * 0.5) / 16.0));
                color = Projectile.GetAlpha(color);
                float multValue = 3 - j;
                color *= multValue / (ProjectileID.Sets.TrailCacheLength[Projectile.type] * 1.5f);

                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, MathHelper.Lerp(Projectile.scale, 1f, j / 15f), SpriteEffects.None, 0);

            }
            return true;
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool(2))
            {
                Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch, 0f, 0f, 0, default, 1f);
                obj.noGravity = true;
                obj.scale = 1f;
            }
        }      
    }
}