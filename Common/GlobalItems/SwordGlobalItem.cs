using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class SwordGlobalItem : GlobalItem
    {

        /*public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.type == ItemID.OrichalcumSword)
            {
                item.noMelee = true;                
                float adjustedItemScale = player.GetAdjustedItemScale(item); // Get the melee scale of the player and item.
                Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), ProjectileID.TrueExcalibur, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale + 0.2f);
                NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.
                return true;
            }

            return false;
        }*/

    }
}
