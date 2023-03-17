using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
        Item.damage = 110;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ModContent.ProjectileType<VugarMutaterProjectile>();
        Item.shootSpeed = 40f;
        Item.value = 750000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(12f, 0f);
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.TrueNightsEdge, 1);
        val.AddIngredient(Mod, "UpgradeMatter", 3);
        val.AddIngredient(ItemID.TerraBlade, 1);
        val.AddIngredient(ItemID.IceTorch, 50);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(44, 360, false);
    }
}
