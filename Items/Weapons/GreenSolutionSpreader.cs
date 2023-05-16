using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GreenSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
        Tooltip.SetDefault("Infinite biome spreading? Awesome!\nRight click to choose between solutions");
    }

	public override void SetDefaults()
	{
        Item.CloneDefaults(ModContent.ItemType<HallowSolutionSpreader>());
        Item.shoot = ProjectileID.PureSpray;
        Item.shootSpeed = 20f;
        SacrificeTotal = 1;
    }

    public override bool CanRightClick()
    {
        return true;
    }
    public override void ModifyItemLoot(ItemLoot itemLoot)
    {
        itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<BlueSolutionSpreader>(), 1));
        Item.TurnToAir();
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
		CreateRecipe()
			.AddIngredient(Mod, "SwordMatter", 200)
			.AddIngredient(ItemID.GreenSolution, 300)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}
}
