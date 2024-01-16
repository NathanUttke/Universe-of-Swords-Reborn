using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Steamworks;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Common.Systems;
using UniverseOfSwordsMod.Items.Consumables;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Items.Weapons;
using UniverseOfSwordsMod.Items.Weapons.BossDrops;

namespace UniverseOfSwordsMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class SwordBossNPC : ModNPC
    {
        //public override string Texture => $"Terraria/Images/NPC_{NPCID.EnchantedSword}";

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Evil Flying Blade");
            Main.npcFrameCount[Type] = 1;
            NPCID.Sets.TrailCacheLength[Type] = 15;
            NPCID.Sets.TrailingMode[Type] = 3;


            NPCID.Sets.MPAllowedEnemies[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Poisoned] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.OnFire] = true;
            NPCID.Sets.SpecificDebuffImmunity[Type][BuffID.Confused] = true;
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 80;
            NPC.boss = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.damage = 0;
            NPC.defense = 14;
            NPC.lifeMax = 15000;
            NPC.knockBackResist = 0f;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.npcSlots = 10f;
            NPC.aiStyle = -1;
            NPC.value = Item.buyPrice(0, 5, 0, 0);
            NPC.scale = 1.5f;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return true;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }

        public override void HitEffect(NPC.HitInfo hit)
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

        public override void OnSpawn(IEntitySource source)
        {
            NPC.alpha = 255;
            NPC.ai[0] = -1f;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<SwordBossBag>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SwordMatter>(), 10, 3, 13));

            LeadingConditionRule notExpertRule = new(new Conditions.NotExpert());
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SwordStaff>(), 3, 1, 1));
            notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<InnosWrath>(), 3, 1, 1));
            npcLoot.Add(notExpertRule);

        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }

        private readonly float dashSpeed = 20f;
        private Player Player => Main.player[NPC.target];

        private int dashCounter = 0;        

        private float dashTimer;
        public override void AI()
        {
            Vector2 npcCenter = NPC.Center;

            if (NPC.target < 0 || NPC.target == 255 || Player.dead || !Player.active)
            {
                NPC.TargetClosest();
            }

            if (Player.dead)
            {
                if (NPC.alpha < 255)
                {
                    NPC.alpha += 2;
                }
                if (NPC.alpha > 255)
                {
                    NPC.alpha = 255;
                }
                NPC.EncourageDespawn(12);
                return;
            }

            if (NPC.ai[0] == -1f)
            {
                NPC.damage = 0;
                NPC.dontTakeDamage = true;
                NPC.rotation += 0.25f;
                if (NPC.alpha > 0)
                {
                    NPC.alpha -= 2;
                }
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                    NPC.ai[0] = 0f;
                    SoundEngine.PlaySound(SoundID.Item71, NPC.position);
                }
            }

            if (NPC.ai[0] == 0f)
            {
                NPC.damage = 50;
                NPC.dontTakeDamage = false;
                Vector2 npcPosition = NPC.Center;
                Vector2 playerPosNpc = new(Player.Center.X - npcPosition.X, Player.Center.Y - npcPosition.Y);
                float playerPosNpcSqrt = dashSpeed / playerPosNpc.Length();
                playerPosNpc *= playerPosNpcSqrt;

                NPC.velocity = playerPosNpc;
                NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2;

                dashTimer = NPC.life <= NPC.lifeMax * 0.5 ? 2f : 25f;

                NPC.ai[0] = 1f;
                NPC.ai[1] = 0f;
                NPC.netUpdate = true;
            }
            else if (NPC.ai[0] == 1f)
            {
                NPC.velocity *= 0.99f;
                NPC.rotation = NPC.velocity.ToRotation() + MathHelper.PiOver2;

                NPC.ai[1] += 1f;
                if (NPC.ai[1] >= 50f)
                {
                    if (dashCounter <= 3)
                    {
                        dashCounter++;
                    }

                    NPC.netUpdate = true;
                    NPC.ai[0] = 2f;
                    NPC.ai[1] = 0f;
                    NPC.velocity *= 0.80f;
                }
            }
            else if (NPC.ai[0] == 2f)
            {
                Vector2 npcPosition = NPC.Center;
                Vector2 playerPosNpc = Player.Center;
                float playerPosNpcSqrt = dashSpeed / playerPosNpc.Length();
                playerPosNpc *= playerPosNpcSqrt;
                npcPosition += playerPosNpc;

                NPC.ai[1] += 1f;
                NPC.velocity *= 0.99f;
                NPC.rotation += 0.25f;


                if (NPC.ai[1] > 25f)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (dashCounter < 3)
                        {
                            break;
                        }

                        Vector2 spinPoint = Vector2.Normalize(playerPosNpc * 4f) * 14f;
                        spinPoint = spinPoint.RotatedBy(-i * MathHelper.Pi / 5f, Vector2.Zero);
                        Projectile swordProj = Projectile.NewProjectileDirect(NPC.GetSource_FromAI(), npcPosition, spinPoint, ProjectileID.EnchantedBeam, 25, 0f, Player.whoAmI);
                        swordProj.tileCollide = false;
                        swordProj.friendly = false;
                        swordProj.hostile = true;
                    }

                    if (dashCounter >= 3)
                    {
                        dashCounter = 0;
                    }

                    SoundEngine.PlaySound(SoundID.Item71, NPC.position);
                    NPC.netUpdate = true;


                    NPC.ai[0] = NPC.life <= NPC.lifeMax * 0.5 ? 0f : 3f;
                    NPC.ai[1] = 0f;
                }
            }
            else if (NPC.ai[0] == 3f)
            {
                NPC.damage = 0;
                float num10 = 8f;
                float acceleration = 0.15f;

                NPC.rotation += 0.25f;
                Vector2 npcPlayerDist = new(Player.Center.X - NPC.Center.X, Player.Center.Y - 250f - NPC.Center.Y);               
                float npcPlayerDist2 = num10 / npcPlayerDist.Length();
                npcPlayerDist.X *= npcPlayerDist2;
                npcPlayerDist.Y *= npcPlayerDist2;

                if (NPC.velocity.X < npcPlayerDist.X)
                {
                    NPC.velocity.X += acceleration;
                    if (NPC.velocity.X < 0f && npcPlayerDist.X > 0f)
                    {
                        NPC.velocity.X += acceleration;
                    }
                }

                else if (NPC.velocity.X > npcPlayerDist.X)
                {
                    NPC.velocity.X -= acceleration;
                    if (NPC.velocity.X > 0f && npcPlayerDist.X < 0f)
                    {
                        NPC.velocity.X -= acceleration;
                    }
                }
                if (NPC.velocity.Y < npcPlayerDist.Y)
                {
                    NPC.velocity.Y += acceleration;
                    if (NPC.velocity.Y < 0f && npcPlayerDist.Y > 0f)
                    {
                        NPC.velocity.Y += acceleration;
                    }
                }
                else if (NPC.velocity.Y > npcPlayerDist.Y)
                {
                    NPC.velocity.Y -= acceleration;
                    if (NPC.velocity.Y > 0f && npcPlayerDist.Y < 0f)
                    {
                        NPC.velocity.Y -= acceleration;
                    }
                }

                NPC.ai[1] += 1f;
                float maxTime = 300f;

                if (NPC.ai[1] >= maxTime)
                {
                    SoundEngine.PlaySound(SoundID.Item71, NPC.position);
                    NPC.ai[0] = 0f;
                    NPC.ai[1] = 0f;
                    NPC.ai[2] = 0f;
                    NPC.target = 255;
                    NPC.netUpdate = true;
                }
                else if (NPC.Center.Y < Player.position.Y && Vector2.Distance(NPC.Center, Player.Center) < 500f)
                {
                    if (!Player.dead)
                    {
                        NPC.ai[2] += 1f;
                    }                                     

                    if (NPC.ai[2] % 80f == 0f)
                    {
                        NPC.ai[2] = 0f;                        
                        float num18 = 5f;

                        float num19 = Player.Center.X - NPC.Center.X;
                        float num20 = Player.Center.Y - NPC.Center.Y;
                        float num21 = (float)Math.Sqrt(num19 * num19 + num20 * num20);
                        num21 = num18 / num21;
                        Vector2 vector2 = npcCenter;
                        Vector2 vector3 = default;
                        vector3.X = num19 * num21;
                        vector3.Y = num20 * num21;
                        vector2.X += vector3.X * 20f;
                        vector2.Y += vector3.Y * 20f;

                        if (Main.netMode != NetmodeID.MultiplayerClient)
                        {
                            int swordNPC = NPC.NewNPC(NPC.GetSource_FromAI(), (int)vector2.X, (int)vector2.Y, NPCID.EnchantedSword);                            
                            Main.npc[swordNPC].velocity.X = vector3.X * 1.25f;
                            Main.npc[swordNPC].velocity.Y = vector3.Y * 1.25f;
                            if (Main.netMode == NetmodeID.Server && swordNPC < Main.maxNPCs)
                            {
                                NetMessage.SendData(MessageID.SyncNPC, -1, -1, null, swordNPC);
                            }
                        }                        
                        for (int m = 0; m < 10; m++)
                        {
                            Dust.NewDust(vector2, 20, 20, DustID.WhiteTorch, vector3.X * 0.4f, vector3.Y * 0.4f);
                        }
                    }
                }
            }
        }

        public override void OnKill()
        {
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedSwordBoss, -1);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (NPC.ai[0] != -1f)
            {
                Vector2 texture = new(TextureAssets.Npc[Type].Width() / 2, TextureAssets.Npc[Type].Height() / Main.npcFrameCount[Type] / 2);
                Color npcColor = Lighting.GetColor((int)(NPC.Center.X) / 16, (int)((NPC.Center.Y) / 16.0));
                float afterImageScale = NPC.scale;
                for (int i = 1; i < NPC.oldPos.Length; i++)
                {
                    afterImageScale -= 0.1f;
                    Color newColor = npcColor;
                    newColor.R /= 2;
                    newColor.G /= 2;
                    newColor.B /= 2;
                    newColor.A /= 2;
                    spriteBatch.Draw(TextureAssets.Npc[Type].Value, new Vector2(NPC.oldPos[i].X - Main.screenPosition.X + NPC.width / 2 - TextureAssets.Npc[Type].Width() * NPC.scale / 2f + texture.X * NPC.scale, NPC.oldPos[i].Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[Type].Height() * NPC.scale / Main.npcFrameCount[Type] + 4f + texture.Y * NPC.scale), NPC.frame, newColor, NPC.rotation, texture, afterImageScale, SpriteEffects.None, 0f);
                }
            }

            return true;
        }
    }
}
