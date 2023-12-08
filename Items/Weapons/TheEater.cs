using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheEater : ModItem
{
    public override void SetStaticDefaults()
    {
        // Tooltip.SetDefault("'Sword of Corruption'");
    }

    public override void SetDefaults()
    {
        Item.width = 54;
        Item.height = 58;
        Item.rare = ItemRarityID.Orange;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 40;
        Item.useAnimation = 20;
        Item.damage = 17;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 0, 75, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        Vector2 hitPosition = Main.rand.NextVector2Circular(50f, 50f);
        hitPosition.SafeNormalize(hitPosition);

        if (Main.rand.NextBool(3) && target.active && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type] && !target.SpawnedFromStatue)
        {
            Projectile proj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center - hitPosition * 20f, hitPosition / 4f, ProjectileID.TinyEater, damageDone / 3, 4f, player.whoAmI, 0f, 0f);
            proj.DamageType = DamageClass.Melee;
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CorruptPlants, 0f, 0f, 127, default, 1.25f);
            Main.dust[dust].noGravity = true;
        }
    }
}
