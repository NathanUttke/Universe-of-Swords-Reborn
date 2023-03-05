using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SweetCornSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Shoots Candy Corn");
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.8f;
        Item.rare = ItemRarityID.Yellow;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 9;
        Item.useAnimation = 9;
        Item.damage = 44;
        Item.knockBack = 5f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.CandyCorn;
        Item.shootSpeed = 20f;
        Item.value = 390500;
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
        val.AddIngredient(ItemID.CandyCornRifle, 1);
        val.AddIngredient(Mod, "Orichalcon", 1);
        val.AddIngredient(Mod, "SwordMatter", 150);
        val.AddTile(TileID.MythrilAnvil);
        val.Register();
    }
}
