using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class ShroomiteBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 70;
        Item.knockBack = 7.2f;
        Item.UseSound = SoundID.Item1;
        Item.value = 280000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.scale = 1.1f;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 1.05f;
        }
        return;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.ShroomiteBar, 15)
            .AddTile(TileID.MythrilAnvil)
            .Register();
    }
}
