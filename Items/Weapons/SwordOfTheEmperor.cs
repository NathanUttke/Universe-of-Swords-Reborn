using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheEmperor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sword of The Emperor");
        Tooltip.SetDefault("'Grant them the Emperor's mercy. Let the heretics burn!'");
    }

    public override void SetDefaults()
    {
        Item.width = 100;
        Item.height = 100;        
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 90;
        Item.knockBack = 3f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 20, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }
    public override void AddRecipes()
    {

        CreateRecipe()
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 18)
            .AddIngredient(ItemID.HallowedBar, 2000)
            .AddIngredient(ItemID.BrokenHeroSword, 16)
            .AddIngredient(ItemID.EnchantedSword, 4)
            .AddIngredient(ItemID.Terragrim, 1)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
        {
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 200, true);
        }
    }
    public override void OnHitPvp(Player player, Player target, int damage, bool crit)
    {
        if (!target.HasBuff(ModContent.BuffType<EmperorBlaze>()))
        {
            target.AddBuff(ModContent.BuffType<EmperorBlaze>(), 200, true);
        }
    }
}
