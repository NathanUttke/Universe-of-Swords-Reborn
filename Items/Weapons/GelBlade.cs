using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GelBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("Slows down enemies");
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.White;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 10;
        Item.knockBack = 4.5f;
        Item.UseSound = SoundID.Item1;
        Item.value = 1500;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 25)
            .AddTile(TileID.WorkBenches)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(137, 360, false);
    }
}
