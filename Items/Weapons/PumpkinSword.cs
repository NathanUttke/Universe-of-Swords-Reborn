using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PumpkinSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Blue;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 14;
        Item.knockBack = 1.4f;
        Item.UseSound = SoundID.Item1;
        Item.value = 1888;
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
        val.AddIngredient(ItemID.Pumpkin, 15);
        val.AddTile(TileID.WorkBenches);
        val.Register();
    }
}
