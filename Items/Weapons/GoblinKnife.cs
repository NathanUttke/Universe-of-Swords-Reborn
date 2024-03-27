using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GoblinKnife : ModItem
{
    public override void SetStaticDefaults()
    {
        // Tooltip.SetDefault("Fast and small knife of Goblins");
    }

    public override void SetDefaults()
    {
        Item.width = 20;
        Item.height = 20;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.Thrust;
        Item.useTime = 9;
        Item.useAnimation = 9;
        Item.damage = 22;
        Item.knockBack = 0f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 0, 25, 0);
        Item.crit = 25;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.HasBuff(BuffID.Bleeding))
        {
            target.AddBuff(BuffID.Bleeding, 400);
        }
        if (!target.HasBuff(BuffID.Weak))
        {
            target.AddBuff(BuffID.Weak, 400);
        }
    }
}
