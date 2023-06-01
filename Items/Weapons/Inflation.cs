using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Inflation : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Congratulations, you made an overpriced sword!");
    }

    public override void SetDefaults()
    {
        Item.width = 128;
        Item.height = 128;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 7.5f;
        Item.useTime = 50;
        Item.useAnimation = 50;
        Item.damage = 28;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 0.75f;
        Item.crit = 8;
        Item.UseSound = SoundID.Item1;
        Item.value = 0;
        Item.autoReuse = true;
    }
    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ItemID.PlatinumCoin, 21)
           .AddIngredient(ItemID.GoldenCrate, 5)
           .AddIngredient(ItemID.GoldBar, 400)
           .AddIngredient(ItemID.GoldBroadsword, 1)
           .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 3)
           .AddTile(TileID.Anvils)
           .Register();
        CreateRecipe()
            .AddIngredient(ItemID.PlatinumCoin, 21)
            .AddIngredient(ItemID.GoldenCrateHard, 5)
            .AddIngredient(ItemID.PlatinumBar, 400)
            .AddIngredient(ItemID.PlatinumBroadsword, 1)
            .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 3)
            .AddTile(TileID.Anvils)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 300);
        }
    }
}
