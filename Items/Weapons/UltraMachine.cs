using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UltraMachine : ModItem
{
	public override void SetStaticDefaults()
	{
		DisplayName.SetDefault("Ultra Machine");
		Tooltip.SetDefault("'Insert Hollywood computer generated special effects here'");
	}

	public override void SetDefaults()
	{
		Item.width = 132;
		Item.height = 132;
		Item.rare = ItemRarityID.Red;
		Item.crit = 10;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 25;
		Item.useAnimation = 15;
		Item.damage = 139;
		Item.knockBack = 8f;
		Item.UseSound = SoundID.Item1;
		Item.shoot = ProjectileID.DeathLaser;
		Item.shootSpeed = 28f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}


	public override void AddRecipes()
	{		
		CreateRecipe()
			.AddIngredient(Mod, "Machine", 1)
			.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 5)
			.AddIngredient(Mod, "DamascusBar", 20)
			.AddIngredient(ItemID.SoulofFright, 15)
			.AddIngredient(ItemID.SoulofMight, 15)
			.AddIngredient(ItemID.SoulofSight, 15)
			.AddIngredient(ItemID.SpectreBar, 20)
			.AddIngredient(Mod, "PrimeSword", 1)
			.AddIngredient(Mod, "DestroyerSword", 1)
			.AddIngredient(Mod, "TwinsSword", 1)
			.AddIngredient(Mod, "MartianSaucerCore", 1)
			.AddIngredient(ItemID.ShroomiteBar, 10)
			.AddIngredient(ItemID.LihzahrdPowerCell, 5)
			.AddTile(TileID.MythrilAnvil)
			.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(10f);
        position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 4f;
        for (int i = 0; (float)i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.25f;
            Projectile proj = Projectile.NewProjectileDirect(source, position, perturbedSpeed, Item.shoot, damage, knockback, player.whoAmI);
            proj.DamageType = DamageClass.Melee;
			proj.hostile = false;
			proj.friendly = true;
        }
        return false;
	}
}
