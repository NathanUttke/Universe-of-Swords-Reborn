using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Inflation : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Your greed knows no bounds, does it?'");
    }

    public override void SetDefaults()
    {
        Item.width = 128;
        Item.height = 128;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 10f;
        Item.useTime = 32;
        Item.useAnimation = 62;
        Item.damage = 240;
        Item.UseSound = SoundID.Item1;
        Item.value = 999999;
        Item.autoReuse = true;
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.GoldCoin, 2000);
        val.AddIngredient(ItemID.GoldenCrate, 10);
        val.AddIngredient(ItemID.GoldBrick, 999);
        val.AddIngredient(ItemID.GoldBroadsword, 10);
        val.AddIngredient(ItemID.GoldBar, 500);
        val.AddTile(TileID.Anvils);
        val.Register();
        Recipe val2 = CreateRecipe(1);
        val2.AddIngredient(ItemID.GoldCoin, 2000);
        val2.AddIngredient(ItemID.GoldenCrate, 10);
        val2.AddIngredient(ItemID.PlatinumBrick, 999);
        val2.AddIngredient(ItemID.PlatinumBroadsword, 10);
        val2.AddIngredient(ItemID.PlatinumBar, 500);
        val2.AddTile(TileID.Anvils);
        val2.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(72, 360, false);
    }
}
