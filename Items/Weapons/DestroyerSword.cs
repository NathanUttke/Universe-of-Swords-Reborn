using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
