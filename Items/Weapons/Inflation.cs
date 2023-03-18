using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Inflation : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Congratulations, you made an overpriced sword!");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 8f;
        Item.useTime = 32;
        Item.useAnimation = 62;
        Item.damage = 30;
        Item.crit = 8;
        Item.UseSound = SoundID.Item1;
        Item.value = 0;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
           .AddIngredient(ItemID.PlatinumCoin, 20)
           .AddIngredient(ItemID.GoldenCrate, 5)
           .AddIngredient(ItemID.GoldBar, 400)
           .AddIngredient(ModContent.ItemType<SwordMatter>(), 400)
           .AddTile(TileID.Anvils)
           .Register();
        CreateRecipe()
            .AddIngredient(ItemID.PlatinumCoin, 20)
            .AddIngredient(ItemID.GoldenCrateHard, 5)
            .AddIngredient(ItemID.PlatinumBar, 400)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 400)
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
