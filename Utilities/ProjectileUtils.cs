using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace UniverseOfSwordsMod.Utilities
{
    public partial class UniverseUtils
    {
        public static void SummonSuperStarSlash(Vector2 targetPosition, IEntitySource source, int damage, int owner, int type)
        {
            Vector2 v = Main.rand.NextVector2CircularEdge(200f, 200f);
            if (v.Y < 0f)
            {
                v.Y *= -1f;
            }
            v.Y += 100f;
            Vector2 vector = v.SafeNormalize(Vector2.UnitY) * 6f;
            Projectile.NewProjectile(source, targetPosition - vector * 20f, vector, type, (int)(damage * 0.75), 0f, owner, 0f, targetPosition.Y);
        }
        public static void EmitHammushProjectiles(Player player, int i, Item item, Rectangle hitbox, int damage, int projectileId)
        {            
            int playerMaxAnimation = player.itemAnimationMax;
            if (player.itemAnimation != (int)(playerMaxAnimation * 0.1) && player.itemAnimation != (int)(playerMaxAnimation * 0.3) && player.itemAnimation != (int)(playerMaxAnimation * 0.5) && player.itemAnimation != (int)(playerMaxAnimation * 0.7) && player.itemAnimation != (int)(playerMaxAnimation * 0.9))
            {
                return;
            }
            float num2 = 0f;
            float num3 = 0f;
            float num4 = 0f;
            float num5 = 0f;
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.9))
            {
                num2 = -7f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.7))
            {
                num2 = -6f;
                num3 = 2f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.5))
            {
                num2 = -4f;
                num3 = 4f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.3))
            {
                num2 = -2f;
                num3 = 6f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.1))
            {
                num3 = 7f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.7))
            {
                num5 = 26f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.3))
            {
                num5 -= 4f;
                num4 -= 20f;
            }
            if (player.itemAnimation == (int)(playerMaxAnimation * 0.1))
            {
                num4 += 6f;
            }
            if (player.direction == -1)
            {
                if (player.itemAnimation == (int)(playerMaxAnimation * 0.9))
                {
                    num5 -= 8f;
                }
                if (player.itemAnimation == (int)(playerMaxAnimation * 0.7))
                {
                    num5 -= 6f;
                }
            }
            num2 *= 1.5f;
            num3 *= 1.5f;
            num5 *= player.direction;
            num4 *= player.gravDir;
            Projectile.NewProjectile(player.GetSource_ItemUse(item), (hitbox.X + hitbox.Width / 2) + num5, (hitbox.Y + hitbox.Height / 2) + num4, player.direction * num3, num2 * player.gravDir, projectileId, damage / 2, 0f, i);
        }

        public static NPC FindClosestNPC(float maxDetectDistance, Vector2 position)
        {
            NPC closestNPC = null;
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC target = Main.npc[i];
                if (target.CanBeChasedBy())
                {
                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, position);
                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }
            return closestNPC;
        }
    }
}
