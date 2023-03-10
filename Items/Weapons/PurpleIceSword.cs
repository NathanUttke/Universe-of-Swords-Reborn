using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PurpleIceSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.White;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 14;
        Item.knockBack = 4.5f;
        Item.UseSound = SoundID.Item1;
        Item.value = 4500;
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
        val.AddIngredient(ItemID.PurpleIceBlock, 25);
        val.AddTile(TileID.WorkBenches);
        val.Register();
    }
}
