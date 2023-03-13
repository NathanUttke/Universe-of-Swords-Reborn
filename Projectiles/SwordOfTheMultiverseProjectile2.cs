using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UniverseOfSwordsMod.Projectiles
{

    public class SwordOfTheMultiverseProjectile2 : ModProjectile
    {
        public override string Texture => $"Terraria/Images/NPC_{NPCID.EnchantedSword}";

        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.aiStyle = -1;
            Projectile.width = 40;
            Projectile.height = 40;            
            Projectile.ownerHitCheck = true;
            Projectile.friendly = true;
            Projectile.alpha = 0;
            Projectile.damage = 100;
            AIType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            base.AI();           
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.Y = -Projectile.velocity.Y;
            return false;
        }
    }
}
