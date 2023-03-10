using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SnowSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Let it snow, let it snow...'");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Blue;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 10;
        Item.knockBack = 1f;
        Item.UseSound = SoundID.Item1;
        Item.value = 100;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.SnowBlock, 25);
        val.AddTile(TileID.WorkBenches);
        val.Register();
    }
}
