using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;

namespace UniverseOfSwordsMod.Projectiles.Minions
{
    internal class SwordMinion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.MinionTargettingFeature[Type] = true;
            Main.projPet[Type] = true;

            ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true; 
        }

        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.width = 16;
            Projectile.height = 48;
            Projectile.minion = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Summon;
            Projectile.minionSlots = 1f;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 14;
        }
        public override bool? CanCutTiles() => true;
        public override bool MinionContactDamage() => true;

        private bool CheckActive(Player owner)
        {
            if (owner.dead || !owner.active)
            {
                owner.ClearBuff(ModContent.BuffType<SwordMinionBuff>());

                return false;
            }

            if (owner.HasBuff(ModContent.BuffType<SwordMinionBuff>()))
            {
                Projectile.timeLeft = 2;
            }

            return true;
        }
        public override void AI()
        {
            Player owner = Main.player[Projectile.owner];
            if (!CheckActive(owner))
            {
                return;
            }

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];
                if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < (float)Projectile.width)
                {
                    if (Projectile.position.X < Main.projectile[i].position.X)
                    {
                        Projectile.velocity.X -= 0.05f;
                    }
                    else
                    {
                        Projectile.velocity.X += 0.05f;
                    }
                    if (Projectile.position.Y < Main.projectile[i].position.Y)
                    {
                        Projectile.velocity.Y -= 0.05f;
                    }
                    else
                    {
                        Projectile.velocity.Y += 0.05f;
                    }
                }
            }
            float projectilePosX = Projectile.position.X;
            float projectilePosY = Projectile.position.Y;
            float maxTargetDistance = 800f;
            bool foundTarget = false;
            int maxDistance = 500;

            if (Projectile.ai[1] != 0f)
            {
                maxDistance = 1400;
            }

            if (Vector2.Distance(Projectile.Center, Main.player[Projectile.owner].Center) > maxDistance)
            {
                Projectile.ai[0] = 1f;
            }
            if (Projectile.ai[0] == 0f)
            {
                NPC ownerMinionAttackTargetNPC = Projectile.OwnerMinionAttackTargetNPC;
                if (ownerMinionAttackTargetNPC != null && ownerMinionAttackTargetNPC.CanBeChasedBy(this))
                {
                    float minionTargetPosX = ownerMinionAttackTargetNPC.position.X + ownerMinionAttackTargetNPC.width / 2;
                    float minionTargetPosY = ownerMinionAttackTargetNPC.position.Y + ownerMinionAttackTargetNPC.height / 2;
                    float projectileTargetDistance = MathF.Abs(Projectile.position.X + Projectile.width / 2 - minionTargetPosX) + Math.Abs(Projectile.position.Y + Projectile.height / 2 - minionTargetPosY);
                    if (projectileTargetDistance < maxTargetDistance)
                    {
                        maxTargetDistance = projectileTargetDistance;
                        projectilePosX = minionTargetPosX;
                        projectilePosY = minionTargetPosY;
                        foundTarget = true;
                    }
                }
                if (!foundTarget)
                {
                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].CanBeChasedBy(this))
                        {
                            float npcPosX = Main.npc[j].position.X + Main.npc[j].width / 2;
                            float npcPosY = Main.npc[j].position.Y + Main.npc[j].height / 2;
                            float npcTargetDistance = MathF.Abs(Projectile.position.X + Projectile.width / 2 - npcPosX) + MathF.Abs(Projectile.position.Y + Projectile.height / 2 - npcPosY);
                            if (npcTargetDistance < maxTargetDistance)
                            {
                                maxTargetDistance = npcTargetDistance;
                                projectilePosX = npcPosX;
                                projectilePosY = npcPosY;
                                foundTarget = true;
                            }
                        }
                    }
                }
            }
            if (!foundTarget)
            {                
                float num476 = 8f;
                if (Projectile.ai[0] == 1f)
                {
                    num476 = 12f;
                }
                Vector2 vector38 = new(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                float num477 = Main.player[Projectile.owner].Center.X - vector38.X;
                float num478 = Main.player[Projectile.owner].Center.Y - vector38.Y - 60f;
                float num479 = MathF.Sqrt(num477 * num477 + num478 * num478);
                if (num479 < 100f && Projectile.ai[0] == 1f)
                {
                    Projectile.ai[0] = 0f;
                }
                if (num479 > 2000f)
                {
                    Projectile.position.X = Main.player[Projectile.owner].Center.X - Projectile.width / 2;
                    Projectile.position.Y = Main.player[Projectile.owner].Center.Y - Projectile.width / 2;
                }
                if (num479 > 100f)
                {
                    num476 = 12f;
                    if (Projectile.ai[0] == 1f)
                    {
                        num476 = 15f;
                    }
                }
                if (num479 > 70f)
                {
                    num479 = num476 / num479;
                    num477 *= num479;
                    num478 *= num479;
                    Projectile.velocity.X = (Projectile.velocity.X * 20f + num477) / 21f;
                    Projectile.velocity.Y = (Projectile.velocity.Y * 20f + num478) / 21f;
                }
                else
                {
                    if (Projectile.velocity.X == 0f && Projectile.velocity.Y == 0f)
                    {
                        Projectile.velocity.X = -0.15f;
                        Projectile.velocity.Y = -0.05f;
                    }
                    Projectile.velocity *= 1.015f;
                } 
                Projectile.rotation = Projectile.velocity.X * 0.05f;
                if (MathF.Abs(Projectile.velocity.X) > 0.2)
                {
                    Projectile.spriteDirection = -Projectile.direction;
                }
                return;
            }
            if (Projectile.ai[1] == -1f)
            {
                Projectile.ai[1] = 17f;
            }
            if (Projectile.ai[1] > 0f)
            {
                Projectile.ai[1] -= 1f;
            }
            if (Projectile.ai[1] == 0f)
            {
                float num481 = 16f;
                Vector2 vector39 = new(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
                float num482 = projectilePosX - vector39.X;
                float num483 = projectilePosY - vector39.Y;
                float num484 = MathF.Sqrt(num482 * num482 + num483 * num483);
                if (num484 < 100f)
                {
                    num481 = 10f;
                }
                num484 = num481 / num484;
                num482 *= num484;
                num483 *= num484;
                Projectile.velocity.X = (Projectile.velocity.X * 14f + num482) / 15f;
                Projectile.velocity.Y = (Projectile.velocity.Y * 14f + num483) / 15f;
                Projectile.rotation += 0.4f * MathHelper.PiOver2;
            }
            else
            {                
                if (MathF.Abs(Projectile.velocity.X) + MathF.Abs(Projectile.velocity.Y) < 10f)
                {
                    Projectile.velocity *= 1.025f;
                }
            }
            if ((double)MathF.Abs(Projectile.velocity.X) > 0.2)
            {
                Projectile.spriteDirection = -Projectile.direction;
            }
        }
    }
}
