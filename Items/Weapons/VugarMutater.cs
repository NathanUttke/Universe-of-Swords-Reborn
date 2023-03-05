using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class VugarMutater : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Gleams with an otherwordly light'");
    }

    public override void SetDefaults()
    {
        Item.width = 35;
        Item.height = 35;
        Item.scale = 1.2f;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 13;
        Item.useAnimation = 13;
        Item.damage = 214;
        Item.knockBack = 6f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = Mod.Find<ModProjectile>("VugarMutater").Type;
        Item.shootSpeed = 40f;
        Item.value = 750000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override Vector2? HoldoutOffset()
    {
        return new Vector2(12f, 0f);
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.TrueNightsEdge, 1);
        val.AddIngredient(Mod, "SwordMatter", 150);
        val.AddIngredient(Mod, "UpgradeMatter", 2);
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
