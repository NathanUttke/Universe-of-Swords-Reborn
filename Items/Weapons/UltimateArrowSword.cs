using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Projectiles;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using UniverseOfSwordsMod.Items.Materials;
using static UniverseOfSwordsMod.UniverseUtils;
using static Humanizer.In;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UltimateArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Ultimate Arrow Sword");
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(55, 13, false));
		ItemID.Sets.AnimatesAsSoul[Type] = true;
	}

	private int[] shootList = { 
		ProjectileID.WoodenArrowFriendly,
        ProjectileID.UnholyArrow,
        ProjectileID.JestersArrow,
        ProjectileID.HellfireArrow, 
		ProjectileID.FireArrow, 
		ProjectileID.HolyArrow, 
		ProjectileID.CursedArrow, 
		ProjectileID.BoneArrow, 
		ProjectileID.FrostburnArrow, 
		ProjectileID.ChlorophyteArrow,		
		ProjectileID.IchorArrow,	
		ProjectileID.VenomArrow
	};

	public override void SetDefaults()
	{
		Item.damage = 120;
		Item.DamageType = DamageClass.MeleeNoSpeed; 

		Item.ResearchUnlockCount = 1;

		Item.width = 64;
		Item.height = 64;

		Item.useTime = 8;
		Item.useAnimation = 30;

        Item.autoReuse = true;
        Item.noUseGraphic = true;
        Item.noMelee = true;

		Item.UseSound = SoundID.Item15;

		Item.useStyle = ItemUseStyleID.Shoot;
		Item.knockBack = 8f;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Lime;
		Item.shoot = ProjectileID.WoodenArrowFriendly;

        Item.noUseGraphic = true;
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		//Vector2 newVelocity = Main.rand.NextVector2CircularEdge(1f, 1f) * (12f + Main.rand.NextFloat() * 2f);
		//Vector2 newPosition = (Main.MouseWorld - Item.Center) + -Vector2.Zero;
		//newPosition += Main.rand.NextVector2Circular(24f, 24f);
		int i = 0;
		while (i < 2)
		{
			i++;
            Vector2 v = Main.rand.NextVector2CircularEdge(200f, 200f);
            if (v.Y < 0f)
            {
                v.Y *= -1f;
            }
            v.Y += 100f;
            Vector2 newVelocity = v.SafeNormalize(Vector2.UnitY) * (12f + Main.rand.NextFloat() * 2f);
            Projectile.NewProjectile(source, Main.MouseWorld + -Vector2.Zero - newVelocity * 20f, newVelocity, shootList[Main.rand.Next(0, shootList.Length)], (int)(damage * 0.75), 0f, player.whoAmI, 0f, Main.MouseWorld.Y - 0f);			
        }
        return false;
    }

    public override void AddRecipes()
    {
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<WoodenArrowSword>())
			.AddIngredient(ModContent.ItemType<FrostburnArrowSword>())
			.AddIngredient(ModContent.ItemType<FlamingArrowSword>())
			.AddIngredient(ModContent.ItemType<CursedArrowSword>())
			.AddIngredient(ModContent.ItemType<VenomArrowSword>())
			.AddIngredient(ModContent.ItemType<HolyArrowSword>())
			.AddIngredient(ModContent.ItemType<UnholyArrowSword>())
			.AddIngredient(ModContent.ItemType<JesterArrowSword>())
			.AddIngredient(ModContent.ItemType<IchorArrowSword>())
			.AddIngredient(ModContent.ItemType<HellfireArrowSword>())
			.AddIngredient(ModContent.ItemType<BoneArrowSword>())
			.AddIngredient(ModContent.ItemType<ChlorophyteArrowSword>())
			.AddIngredient(ModContent.ItemType<LuminiteArrowSword>())
			.AddTile(TileID.MythrilAnvil)
			.Register();
    }
}
