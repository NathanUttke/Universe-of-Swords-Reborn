using Microsoft.Extensions.Options;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CrimsonCrystallus : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 44;
		Item.height = 52;
		Item.rare = ItemRarityID.Green;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 50;
		Item.useAnimation = 25;
		Item.damage = 18;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<Tier2CProjectile>();
		Item.shootSpeed = 3f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 1, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 2; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, ModContent.DustType<GlowDust>(), velocity, 0, Color.Red);
            dust.noGravity = true;
        }
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		for (int i = 0 ; i < 3; i++)
		{
			Vector2 newVelocity = velocity.RotatedByRandom(0.5f);
			Projectile.NewProjectile(source, position, newVelocity, type, damage / 2, knockback, player.whoAmI);
		}
		return false;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<Crystallus>(), 1)
		.AddIngredient(ItemID.CrimtaneBar, 12)
		.AddIngredient(ItemID.TissueSample, 8)
		.AddTile(TileID.Anvils)
		.Register();
        CreateRecipe()
		.AddIngredient(ModContent.ItemType<CorruptCrystallus>(), 1)
		.AddTile(TileID.DemonAltar)
		.Register();
    }
}
