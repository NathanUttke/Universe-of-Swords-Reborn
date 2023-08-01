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
        // Tooltip.SetDefault("Congratulations, you made an overpriced sword!");
    }

    public override void SetDefaults()
    {
        Item.width = 128;
        Item.height = 128;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4f;
        Item.useTime = 50;
        Item.useAnimation = 50;
        Item.damage = 28;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 0.75f;
        Item.crit = 8;
        Item.UseSound = SoundID.Item169;
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
           .AddIngredient(ItemID.PlatinumCoin, 20)
           .AddIngredient(ItemID.GoldenCrate, 5)
           .AddIngredient(ItemID.GoldBar, 200)
           .AddIngredient(ItemID.GoldBroadsword, 1)
           .AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
           .AddTile(TileID.Anvils)
           .Register();
        CreateRecipe()
            .AddIngredient(ItemID.PlatinumCoin, 20)
            .AddIngredient(ItemID.GoldenCrateHard, 5)
            .AddIngredient(ItemID.PlatinumBar, 200)
            .AddIngredient(ItemID.PlatinumBroadsword, 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 25)
            .AddTile(TileID.Anvils)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        if (!target.HasBuff(BuffID.Midas))
        {
            target.AddBuff(BuffID.Midas, 300);
        }
    }
}
