using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Common.Systems;


namespace UniverseOfSwordsMod.NPCs.Bosses
{
    [AutoloadBossHead]
    public class SwordBossNPC : ModNPC
    {
        //public override string Texture => $"Terraria/Images/NPC_{NPCID.EnchantedSword}";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Sword");
            Main.npcFrameCount[Type] = 1;
            NPCID.Sets.TrailCacheLength[Type] = 15;
            NPCID.Sets.TrailingMode[Type] = 3;


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

        public override void OnSpawn(IEntitySource source)
        {
            NPC.alpha = 255;
            NPC.ai[0] = -1f;
        }

        private float dashSpeed = 18f;
        private Player player => Main.player[NPC.target];
        private float timeToChange = 15f;
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

            if (NPC.ai[0] == -1)
            {
                NPC.rotation += 0.25f;
                if (NPC.alpha > 0)
                {
                    NPC.alpha -= 2;
                }
                if (NPC.alpha < 0)
                {
                    NPC.alpha = 0;
                    NPC.ai[0] = 0f;
                }
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
                    if (Main.rand.NextBool(5))
                    {
                        int enchantSword = NPC.NewNPC(NPC.GetSource_FromAI(), (int)npcPosition.X, (int)npcPosition.Y, NPCID.EnchantedSword);
                        if (Main.netMode == NetmodeID.Server && enchantSword < 10)
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
                if (NPC.life <= NPC.lifeMax * 0.5)
                {
                    timeToChange = 8f;
                }

                Vector2 npcPosition = new(NPC.position.X + NPC.width * 0.5f, NPC.position.Y + NPC.height * 0.5f);
                Vector2 playerPosNpc = new(player.position.X + player.width / 2 - npcPosition.X, player.position.Y + player.height / 2 - npcPosition.Y);
                float playerPosNpcSqrt = (dashSpeed * 0.75f) / playerPosNpc.Length();
                playerPosNpc *= playerPosNpcSqrt;
                npcPosition += playerPosNpc;

                NPC.velocity *= 0.99f;
                NPC.ai[1] += 1f;
                NPC.rotation += 0.25f;

                if (NPC.ai[1] >= timeToChange)
                {
                    if (NPC.life <= NPC.lifeMax * 0.75 && Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Vector2 spinPoint = Vector2.Normalize(playerPosNpc * 4f) * 14f;
                            spinPoint = spinPoint.RotatedBy(-i * MathHelper.Pi / 5f, Vector2.Zero);
                            Projectile swordProj = Projectile.NewProjectileDirect(NPC.GetSource_FromAI(), npcPosition, spinPoint, ProjectileID.LightBeam, 15, 0f, player.whoAmI);
                            swordProj.friendly = false;
                            swordProj.hostile = true;
                        }
                    }

                    SoundEngine.PlaySound(SoundID.Item71, NPC.position);
                    NPC.netUpdate = true;
                    NPC.ai[0] = 0f;
                    NPC.ai[1] = 0f;
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
                Vector2 vector12 = new(TextureAssets.Npc[Type].Width() / 2, TextureAssets.Npc[Type].Height() / Main.npcFrameCount[Type] / 2);
                Color npcColor = Lighting.GetColor((int)(NPC.position.X + NPC.width * 0.5) / 16, (int)((NPC.position.Y + NPC.height * 0.5) / 16.0));
                float newScale = NPC.scale;
                for (int i = 1; i < NPC.oldPos.Length; i++)
                {
                    newScale -= 0.1f;
                    Color newColor = npcColor;
                    newColor.R /= 2;
                    newColor.G /= 2;
                    newColor.B /= 2;
                    newColor.A /= 2;
                    spriteBatch.Draw(TextureAssets.Npc[Type].Value, new Vector2(NPC.oldPos[i].X - Main.screenPosition.X + NPC.width / 2 - TextureAssets.Npc[Type].Width() * NPC.scale / 2f + vector12.X * NPC.scale, NPC.oldPos[i].Y - Main.screenPosition.Y + NPC.height - TextureAssets.Npc[Type].Height() * NPC.scale / Main.npcFrameCount[Type] + 4f + vector12.Y * NPC.scale), NPC.frame, newColor, NPC.rotation, vector12, newScale, SpriteEffects.None, 0f);
                }
            }

            return true;
        }
    }
}
