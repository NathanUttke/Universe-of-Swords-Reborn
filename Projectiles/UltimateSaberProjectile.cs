using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class UltimateSaberProjectile : ModProjectile
    {
        public override string Texture => $"Terraria/Images/Item_{ItemID.RedPhasesaber}";
        public int count = 0;

        public string[] textureArray =
        {
            $"Terraria/Images/Item_{ItemID.RedPhasesaber}",
            $"Terraria/Images/Item_{ItemID.YellowPhasesaber}",
            $"Terraria/Images/Item_{ItemID.GreenPhasesaber}",
            $"Terraria/Images/Item_{ItemID.BluePhasesaber}",
            $"Terraria/Images/Item_{ItemID.PurplePhasesaber}",
            $"Terraria/Images/Item_{ItemID.WhitePhasesaber}",
            $"Terraria/Images/Item_{ItemID.RedPhasesaber}"
        };
        public override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 56;
            Projectile.height = 56;
            Projectile.aiStyle = -1;
            Projectile.alpha = 0;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
        }
        public override void OnSpawn(IEntitySource source)
        {
            count++;
        }
        public override void AI()
        {
            base.AI();

            Player player = Main.player[Projectile.owner];            

            double rad = Projectile.ai[0] * 5.0 * (Math.PI / 180.0);
            double distance = 90;
            Projectile.ai[0] += 1f;
            //Projectile.Center = player.Center + Vector2.One.RotatedBy(Projectile.ai[0]) * (int)rad;
            Projectile.rotation = Projectile.AngleTo(player.MountedCenter);
            float posX = player.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = player.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;
            Projectile.position = new Vector2(posX, posY);

            if (Main.myPlayer == Projectile.owner && (!player.channel || !player.controlUseItem || player.noItems || player.CCed))
            {
                Projectile.Kill();
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);
            Player player = Main.player[Projectile.owner];
            int projectileCount = player.ownedProjectileCounts[ModContent.ProjectileType<UltimateSaberProjectile>()];
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(textureArray[count]);
              
            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, defaultColor, Projectile.rotation, new Vector2(texture.Width / 2, texture.Height / 2), Projectile.scale, SpriteEffects.None, 0);
            return false;
        }
    }
}
