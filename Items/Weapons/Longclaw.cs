using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Longclaw : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'You know nothing, Jon Snow'");
    }

    public override void SetDefaults()
    {
        Item.width = 58;
        Item.height = 58;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 4f;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 20;
        Item.UseSound = SoundID.Item1;
        Item.value = 99999;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.IronBar, 20);
        val.AddIngredient(Mod, "KokiriSword", 1);
        val.AddIngredient(Mod, "SwordMatter", 100);
        val.AddIngredient(ItemID.CopperShortsword, 1);
        val.AddIngredient(ItemID.SilverCoin, 100);
        val.AddTile(TileID.Anvils);
        val.Register();
        Recipe val2 = CreateRecipe(1);
        val2.AddIngredient(ItemID.LeadBar, 20);
        val2.AddIngredient(Mod, "KokiriSword", 1);
        val2.AddIngredient(Mod, "SwordMatter", 100);
        val2.AddIngredient(ItemID.CopperShortsword, 1);
        val2.AddIngredient(ItemID.SilverCoin, 100);
        val2.AddTile(TileID.Anvils);
        val2.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(44, 260, false);
    }
}
