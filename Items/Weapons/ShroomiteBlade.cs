using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ShroomiteBlade : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 35;
        Item.height = 35;
        Item.scale = 1.9f;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.damage = 70;
        Item.knockBack = 7.2f;
        Item.UseSound = SoundID.Item1;
        Item.value = 280000;
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
        val.AddIngredient(ItemID.ShroomiteBar, 10);
        val.AddTile(TileID.MythrilAnvil);
        val.Register();
    }
}
