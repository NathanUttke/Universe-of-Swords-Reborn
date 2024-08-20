using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheEater : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
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
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        Vector2 hitPosition = Main.rand.NextVector2Circular(50f, 50f).SafeNormalize(Vector2.UnitY) * 6f;

        if (target.active && !target.immortal && !NPCID.Sets.CountsAsCritter[target.type] && !target.SpawnedFromStatue)
        {
            Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center - hitPosition * 5f, hitPosition, ProjectileID.TinyEater, damageDone, 0f, player.whoAmI);
        }
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CorruptPlants, Alpha: 127, Scale:1.25f);
            Main.dust[dust].noGravity = true;
        }
    }
}
