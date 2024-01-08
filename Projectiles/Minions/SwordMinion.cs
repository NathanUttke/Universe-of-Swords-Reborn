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

        Player Owner => Main.player[Projectile.owner];
        public override void AI()
        {            
            if (!CheckActive(Owner))
            {
                return;
            }

            for (int i = 0; i < Main.maxProjectiles; i++)
            {
                Projectile other = Main.projectile[i];
                if (i != Projectile.whoAmI && other.active && other.owner == Projectile.owner && Math.Abs(Projectile.position.X - other.position.X) + Math.Abs(Projectile.position.Y - other.position.Y) < Projectile.width)
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
            Vector2 projectilePos = Projectile.position;
            float maxTargetDistance = 1000f;
            bool foundTarget = false;
            int maxDistance = 500;

            if (Projectile.ai[1] != 0f)
            {
                maxDistance = 1400;
            }

            if (Vector2.Distance(Projectile.Center, Owner.Center) > maxDistance)
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
                    float projectileTargetDistance = MathF.Abs(Projectile.Center.X - minionTargetPosX) + Math.Abs(Projectile.Center.Y - minionTargetPosY);
                    if (projectileTargetDistance < maxTargetDistance)
                    {
                        maxTargetDistance = projectileTargetDistance;
                        projectilePos.X = minionTargetPosX;
                        projectilePos.Y = minionTargetPosY;
                        foundTarget = true;
                    }
                }
                if (!foundTarget)
                {
                    for (int j = 0; j < Main.maxNPCs; j++)
                    {
                        if (Main.npc[j].CanBeChasedBy(this))
                        {
                            float npcPosX = Main.npc[j].Center.X;
                            float npcPosY = Main.npc[j].Center.Y;
                            float npcTargetDistance = MathF.Abs(Projectile.Center.X - npcPosX) + MathF.Abs(Projectile.Center.Y - npcPosY);
                            if (npcTargetDistance < maxTargetDistance)
                            {
                                maxTargetDistance = npcTargetDistance;
                                projectilePos.X = npcPosX;
                                projectilePos.Y = npcPosY;
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
                Vector2 projPosition = Owner.Top + new Vector2(0f, -Owner.height * 2f) - Projectile.Center;
                Projectile.velocity = projPosition;
                Projectile.rotation = Projectile.velocity.X * 0.1f;

                if (Projectile.ai[0] == 1f)
                {
                    Projectile.ai[0] = 0f;
                }
                if (Projectile.velocity.Length() >= 2000f)
                {
                    Projectile.Center = projPosition;
                }                
                if (Projectile.velocity.Length() > num476)
                {
                    Projectile.velocity *= num476 / Projectile.velocity.Length();
                }
                
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
                Vector2 vector39 = Projectile.Center;
                float num482 = projectilePos.X - vector39.X;
                float num483 = projectilePos.Y - vector39.Y;
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
