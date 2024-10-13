using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Items.Weapons;

public class DestroyerSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 62;
		Item.rare = ItemRarityID.Pink;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 66;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 160000;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 2; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, ModContent.DustType<GlowDust>(), velocity, 0, Color.Red);
            dust.noGravity = true;
        }
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (target.active && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type] && !target.SpawnedFromStatue)
        {
			UniverseUtils.SummonSuperStarSlash(target.Center, target.GetSource_OnHit(target), damageDone, player.whoAmI, ModContent.ProjectileType<DestroyerLaser>());
        }
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.Y -= 1f * player.gravDir;
	}
}
