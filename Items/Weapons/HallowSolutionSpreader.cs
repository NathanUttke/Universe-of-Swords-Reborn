using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class HallowSolutionSpreader : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("Infinite biome spreading? Awesome!\nRight click to choose between solutions");
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
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
        Item.shoot = ProjectileID.HallowSpray;
        Item.shootSpeed = 20f;
    }

    public override bool CanRightClick()
    {
        return true;
    }

    public override void ModifyItemLoot(ItemLoot itemLoot)
    {
        itemLoot.Add(ItemDropRule.NotScalingWithLuck(ModContent.ItemType<PurpleSolutionSpreader>(), 1));
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
		Recipe val = CreateRecipe(1);
		val.AddIngredient(Mod, "SwordMatter", 200);
		val.AddIngredient(ItemID.BlueSolution, 300);
		val.AddTile(TileID.MythrilAnvil);
		val.Register();
	}
}
