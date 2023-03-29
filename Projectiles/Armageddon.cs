using Terraria.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Projectiles;

public class Armageddon : ModProjectile
{
    public override string Texture => $"Terraria/Images/Projectile_{Main.rand.Next(424, 426)}";

    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Type] = 8;
        ProjectileID.Sets.TrailingMode[Type] = 4;
    }
    public override void SetDefaults()
    {
        Projectile.width = 20;
        Projectile.height = 13;
        Projectile.scale = Main.rand.NextFloat(1f, 1.5f);
        Projectile.aiStyle = 25;
        Projectile.friendly = true;
        //Projectile.hostile = false;
        Projectile.DamageType = DamageClass.MeleeNoSpeed;
        Projectile.penetrate = 1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = true;
        AIType = ProjectileID.Boulder;
    }

    public override void AI()
    {
        Projectile.rotation = Projectile.velocity.ToRotation();
        if (Main.rand.NextBool(2))
        {
            Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.Flare, 0f, 0f, 0, default, 1f);
            obj.noGravity = true;
            obj.scale = 2f;
        }
    }

    public override bool PreDraw(ref Color lightColor)
    {
        default(FlameLashDrawer).Draw(Projectile);
        return true;
    }

    public override void Kill(int timeLeft)
    {
        Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Flare, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f, 0, default, 1f);
        Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Flare, Projectile.oldVelocity.X * 0.1f, Projectile.oldVelocity.Y * 0.1f, 0, default, 1f);
        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position.X, Projectile.position.Y, 0f, 0f, ProjectileID.InfernoFriendlyBlast, Projectile.damage, Projectile.knockBack, Main.myPlayer, 0f, 0f);
        SoundEngine.PlaySound(SoundID.Dig, new Vector2(Projectile.position.X, Projectile.position.Y));             
    }

    public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
    {
        target.AddBuff(189, 500, false);
    }
}
