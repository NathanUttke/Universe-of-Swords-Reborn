using Microsoft.Xna.Framework;
using MonoMod.RuntimeDetour;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Misc;

public class BlueSolutionSpreader : ModItem
{
    public override void SetStaticDefaults()
	{
        // Tooltip.SetDefault("Infinite biome spreading? Awesome!\nRight click to choose between solutions");
        Item.ResearchUnlockCount = 1;
        Terraria.GameContent.Creative.On_ItemFilters.Tools.FitsFilter += Tools_FitsFilter;
    }

    private bool Tools_FitsFilter(Terraria.GameContent.Creative.On_ItemFilters.Tools.orig_FitsFilter orig, Terraria.GameContent.Creative.ItemFilters.Tools self, Item entry)
    {
        if (Item.type == Type)
        {
            return true;
        }
        return orig(self, entry);
    }

    public override void SetDefaults()
	{
        Item.width = 58;
        Item.height = 58;
        Item.scale = 1.3f;
        Item.rare = ItemRarityID.Lime;

        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item34;

        Item.value = 830000;
        Item.autoReuse = true;

        Item.shoot = ProjectileID.MushroomSpray;
        Item.shootSpeed = 20f;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float spread = 1.75f;
        float baseSpeed = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
        double startAngle = Math.Atan2(velocity.X, velocity.Y) - (double)(spread / 2f);
        double deltaAngle = spread / 2f;
        for (int i = 0; i < 50; i++)
        {
            double offsetAngle = startAngle + deltaAngle * i;
            Projectile.NewProjectile(source, position.X, position.Y, baseSpeed * (float)Math.Sin(offsetAngle), baseSpeed * (float)Math.Cos(offsetAngle), type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }

    public override void AddRecipes()
	{		
		CreateRecipe(1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
        .AddIngredient(ItemID.DarkBlueSolution, 300)
		.AddTile(TileID.MythrilAnvil)
		.Register();
	}
}
