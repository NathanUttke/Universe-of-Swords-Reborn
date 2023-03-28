using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;

namespace UniverseOfSwordsMod
{
    public static class UniverseUtils
    {
        public static void SummonSuperStarSlash(Vector2 target, IEntitySource source, int damage, int owner, int type)
        {
            Vector2 v = Main.rand.NextVector2CircularEdge(200f, 200f);
            if (v.Y < 0f)
            {
                v.Y *= -1f;
            }
            v.Y += 100f;
            Vector2 vector = v.SafeNormalize(Vector2.UnitY) * 6f;
            Projectile.NewProjectile(source, target - vector * 20f, vector, type, (int)((double)damage * 0.75), 0f, owner, 0f, target.Y);
        }
    }
}
