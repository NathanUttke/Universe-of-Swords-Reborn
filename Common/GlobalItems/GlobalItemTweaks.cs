using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class GlobalItemTweaks : GlobalItem
    {
        public override bool InstancePerEntity => true; 
        float mouseRotation = 0f;

        public override void SetStaticDefaults()
        {
            //Terraria.On_Player.ItemCheck_GetMeleeHitbox += On_Player_ItemCheck_GetMeleeHitbox;
        }

        public override void UseItemHitbox(Item item, Player player, ref Rectangle hitbox, ref bool noHitbox)
        {
            // Disabled for now. Needs more testing and tweaks
            /*if (item.useStyle == ItemUseStyleID.Swing)
            {
                float adjustedItemScale = player.GetAdjustedItemScale(item);
                hitbox = new Rectangle((int)player.itemLocation.X, (int)player.itemLocation.Y, 32, 32);
                hitbox.Width = (int)(hitbox.Width * adjustedItemScale);
                hitbox.Height = (int)(hitbox.Height * adjustedItemScale);

                if (player.direction == -1)
                {
                    hitbox.X -= hitbox.Width;
                }
                if (player.gravDir == 1f)
                {
                    hitbox.Y -= hitbox.Height;
                }

                float itemRotation = player.itemRotation - MathHelper.PiOver4;
                if (player.direction == -1)
                {
                    itemRotation -= MathHelper.Pi - MathHelper.PiOver2;
                }
                Vector2 rotationVector = itemRotation.ToRotationVector2() * (item.Size);
                Vector2 hitBoxPosition = new(hitbox.X, hitbox.Y);
                hitbox.X = (int)(player.position.X + rotationVector.X);
                if (player.direction == -1)
                {
                    //hitbox.X -= player.width / 2;
                }
                hitbox.Y = (int)(player.position.Y + rotationVector.Y);
                Dust.QuickBox(new Vector2(hitbox.X, hitbox.Y), new Vector2(hitbox.X, hitbox.Y) + hitbox.Size(), 10, Color.Red, null);
            }*/
        }

        public override void UseStyle(Item item, Player player, Rectangle heldItemFrame)
        {
            // Disabled for now. Needs more testing and tweaks
            
            /*if (item.useStyle == ItemUseStyleID.Swing && !item.noMelee) 
            {
                float swingTimer = (player.itemAnimation / (float)player.itemAnimationMax - 0.5f) * -player.direction * 3.5f - player.direction * 0.3f;
                player.itemLocation = player.RotatedRelativePoint(player.MountedCenter) + Vector2.Zero * player.Directions;
                if (player.ItemAnimationJustStarted)
                {
                    player.ChangeDir((Main.MouseWorld.X > player.Center.X).ToDirectionInt());
                    mouseRotation = Vector2.Normalize(Main.MouseWorld - player.Center).ToRotation();
                }
                if (item.shoot > ProjectileID.None)
                {
                    mouseRotation = Vector2.Normalize(Main.MouseWorld - player.Center).ToRotation();
                }
                player.itemRotation = mouseRotation + swingTimer + MathHelper.PiOver2 - MathHelper.PiOver4 / 2;

                if (player.direction == -1)
                {
                    player.itemRotation += MathHelper.PiOver4;
                    if (item.shoot > ProjectileID.None)
                    {
                        player.itemRotation -= MathHelper.TwoPi;
                    }
                }

                float rotation = player.itemRotation - MathHelper.PiOver2 - MathHelper.PiOver4;
                if (player.direction == -1)
                {
                    rotation -= MathHelper.TwoPi + MathHelper.PiOver2;
                }
                player.SetCompositeArmFront(true, Player.CompositeArmStretchAmount.Full, rotation);
            }*/
        }
    }
}
