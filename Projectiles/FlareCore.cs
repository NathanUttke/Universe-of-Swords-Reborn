using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Projectiles;

public class FlareCore : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 25;
        Projectile.height = 50;
        Projectile.scale = 1f;
        Projectile.aiStyle = 1;
        Projectile.friendly = true;
        Projectile.hostile = false;
        Projectile.DamageType = DamageClass.Ranged;
        Projectile.penetrate = -1;
        Projectile.ignoreWater = true;
        Projectile.tileCollide = false;
        base.AIType = 14;
    }

    public override void PostAI()
    {
        if (Main.rand.NextBool(1))
        {
            Dust obj = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1f);
            obj.noGravity = true;
            obj.scale = 1f;
        }
    }

    public override void OnHitNPC(NPC n, int damage, float knockback, bool crit)
    {
        Player owner = Main.player[Projectile.owner];
        switch (Main.rand.Next(2))
        {
            case 0:
                n.AddBuff(24, 700, false);
                break;
            case 1:
                owner.statLife += 10;
                owner.HealEffect(10, true);
                break;
        }
    }
}
