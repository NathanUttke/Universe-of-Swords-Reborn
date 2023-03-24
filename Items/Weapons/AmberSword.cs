using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class AmberSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.scale = 1.5f;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 16;
        Item.knockBack = 3.8f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 3, 40, 0);
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    } 
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.Amber, 10)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
        .AddTile(TileID.Anvils)
        .Register();
    }
}
