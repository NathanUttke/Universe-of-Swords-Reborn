using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class VugarMutater : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Gleams with an otherwordly light'");
    }

    public override void SetDefaults()
    {
        Item.width = 80;
        Item.height = 80;
        Item.rare = ItemRarityID.Red;
        Item.crit = 8;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 15;
        Item.damage = 90;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ModContent.ProjectileType<VugarMutaterProjectile>();
        Item.shootSpeed = 8f;
        Item.value = Item.sellPrice(0, 1, 40, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }
    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 2)
        .AddIngredient(ItemID.ChlorophyteBar, 15)
        .AddIngredient(ItemID.Frostbrand, 1)
        .AddTile(TileID.MythrilAnvil)
        .Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        if (!target.HasBuff(BuffID.Frostburn))
        {
            target.AddBuff(BuffID.Frostburn, 400);
        }
        
    }
}
