using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheStinger : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("20% chance of shooting a stinger");
	}

	public override void SetDefaults()
	{
		Item.width = 62;
		Item.height = 62;
		Item.scale = 1f;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 17;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.HornetStinger;
        Item.shootSpeed = 10f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 0, 50, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		if (Main.rand.NextBool(5))
		{
            Projectile.NewProjectile(source, position, velocity.RotatedByRandom(5f), ProjectileID.HornetStinger, 9, knockback / 2f, player.whoAmI);
        }
		return false;
    }

    public override void AddRecipes()
	{		
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ModContent.ItemType<SwordMatter>(), 70);
		val.AddIngredient(ItemID.Vine, 2);
		val.AddIngredient(ItemID.Stinger, 15);
		val.AddTile(TileID.Anvils);
		val.Register();
	}

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
		if (Main.rand.NextBool(4))
		{
			Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.JungleGrass, 0.5f, 0f, 100, default, 1.5f)];
			dust.noGravity = true;
		}
	}
}
