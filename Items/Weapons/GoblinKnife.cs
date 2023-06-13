using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GoblinKnife : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Fast and small knife of Goblins");
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
        Item.knockBack = 2.5f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 0, 25, 0);
        Item.crit = 10;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
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
