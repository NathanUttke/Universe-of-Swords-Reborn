using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Mono.Cecil;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace UniverseOfSwordsMod.NPCs.Bosses
{
    public class SwordBossNPC : ModNPC
    {
        //public override string Texture => $"Terraria/Images/NPC_{NPCID.EnchantedSword}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Sword");
            Main.npcFrameCount[Type] = 1;

            NPCID.Sets.MPAllowedEnemies[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[]
                {
                    BuffID.Poisoned,
                    BuffID.OnFire,
                    BuffID.Confused
                }
            };
            NPCID.Sets.DebuffImmunitySets.Add(Type, debuffData);
        }
        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 80;
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.damage = 45;
            NPC.defense = 14;
            NPC.lifeMax = 7500;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            //NPC.SpawnWithHigherTime(30);
            NPC.npcSlots = 10f;
            NPC.aiStyle = -1;
            NPC.value = Item.buyPrice(0, 5, 0, 0);
            NPC.scale = 1.5f;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return NPC.dontTakeDamage;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                return;
            }
            if (NPC.life <= 0)
            {
                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
        }

        private float dashSpeed = 18f;
        private Player player => Main.player[NPC.target];
        public override void AI()
        { 
            base.AI();
            if (NPC.target < 0 || NPC.target == 255 || player.dead || !player.active)
            {
                NPC.TargetClosest();
            }

            if (player.dead)
            {
                NPC.EncourageDespawn(10);
                return;
            }

            if (NPC.ai[0] == 0f)
            {
                Vector2 npcPosition = new(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                Vector2 playerPosNpc = new(player.position.X + player.width / 2 - npcPosition.X, player.position.Y + player.height / 2 - npcPosition.Y);
                float playerPosNpcSqrt = dashSpeed / playerPosNpc.Length();
                playerPosNpc *= playerPosNpcSqrt;               

                NPC.velocity = playerPosNpc;
                NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2;

                NPC.ai[0] = 1f;
                NPC.ai[1] = 0f;
                NPC.netUpdate = true;
            }
            else if (NPC.ai[0] == 1f)
            {      
                NPC.velocity *= 0.99f;

                NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2;

                if (NPC.justHit && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Vector2 npcPosition = new(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                    Vector2 playerPosNpc = new(player.position.X + player.width / 2 - npcPosition.X, player.position.Y + player.height / 2 - npcPosition.Y);
                    float playerPosNpcSqrt = 5f / playerPosNpc.Length();
                    playerPosNpc *= playerPosNpcSqrt;
                    npcPosition += playerPosNpc;
                    if (Main.rand.NextBool(2))
                    {
                        int enchantSword = NPC.NewNPC(NPC.GetSource_FromAI(), (int)npcPosition.X, (int)npcPosition.Y, NPCID.EnchantedSword);
                        if (Main.netMode == NetmodeID.Server && enchantSword < 20)
                        {
                            NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, enchantSword);
                        }
                    }
                }

                NPC.ai[1] += 1f;
                if (NPC.ai[1] >= 50f)
                {
                    NPC.netUpdate = true;
                    NPC.ai[0] = 2f;
                    NPC.ai[1] = 0f;
                    NPC.velocity *= 0.80f;
                }
            }
            else if (NPC.ai[0] == 2f)
            {
                Vector2 npcPosition = new(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                Vector2 playerPosNpc = new(player.position.X + player.width / 2 - npcPosition.X, player.position.Y + player.height / 2 - npcPosition.Y);
                float playerPosNpcSqrt = 5f / playerPosNpc.Length();
                playerPosNpc *= playerPosNpcSqrt;
                npcPosition += playerPosNpc;

                NPC.velocity *= 0.99f;
                NPC.ai[1] += 1f;

                /*if (Math.Sign(NPC.velocity.X) != 0)
                {
                    NPC.spriteDirection = -Math.Sign(NPC.velocity.X);
                }*/

                if (NPC.ai[1] >= 15f)
                {

                    if (NPC.life <= NPC.lifeMax * 0.75)
                    {
                        int i = 0;
                        while (i < 3)
                        {
                            Vector2 spinPoint = Vector2.Normalize(playerPosNpc * 4f) * 14f;
                            int rotationRadius = i == 2 ? -15 : 15 * i;
                            spinPoint = spinPoint.RotatedBy(MathHelper.ToRadians(rotationRadius));
                            if (spinPoint.HasNaNs())
                            {
                                spinPoint -= Vector2.UnitY;
                            }
                            Projectile swordProj = Projectile.NewProjectileDirect(NPC.GetSource_FromAI(), npcPosition, spinPoint, ProjectileID.LightBeam, 15, 0f, player.whoAmI);
                            swordProj.friendly = false;
                            swordProj.hostile = true;
                            i++;
                        }
                    }

                    NPC.netUpdate = true;
                    NPC.ai[0] = 0f;
                    NPC.ai[1] = 0f;
                }
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            return base.PreDraw(spriteBatch, screenPos, drawColor);
        }
    }
}
