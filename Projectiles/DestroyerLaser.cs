﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles
{    
    internal class DestroyerLaser : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Projectile_{ProjectileID.DeathLaser}";

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 10;
            Projectile.extraUpdates = 2;
            AIType = ProjectileID.Bullet;
            Projectile.friendly = true;
        }

        public override void OnSpawn(IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item33, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;            
            SpriteEffects spriteEffects = SpriteEffects.None;

            Color projColor = Projectile.GetAlpha(lightColor);
            projColor.A = 0;

            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), null, projColor, Projectile.rotation, new Vector2(0f, Projectile.gfxOffY), Projectile.scale, spriteEffects, 0);
            return false;
        }
    }
}