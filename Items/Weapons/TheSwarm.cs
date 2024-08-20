using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheSwarm : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Orange;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 40;
		Item.useAnimation = 20;
		Item.damage = 20;
		Item.knockBack = 5f;
		Item.shoot = ProjectileID.Bee;
		Item.shootSpeed = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = 38500;
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
		Item.scale = 1.1f;
	}

	public override void AddRecipes()
	{
        Mod BombusApisBee = UniverseOfSwordsMod.Instance.BombusApisBee;
		Recipe swordRecipe = CreateRecipe();
		swordRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 10);
		swordRecipe.AddIngredient(ModContent.ItemType<TheStinger>(), 1);
		if (BombusApisBee is not null)
		{
			swordRecipe.AddIngredient(BombusApisBee.Find<ModItem>("Pollen"), 15);
		}
		swordRecipe.AddIngredient(ItemID.BeeKeeper, 1);
		swordRecipe.AddTile(TileID.Anvils);
        swordRecipe.Register();
	}

	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
	{
		int newDamage = player.strongBees ? (int)(damage * 0.90f) : (int)(damage * 0.75f);
		int beeAmount = Main.rand.Next(2, 4);

        for (int i = 0; i < beeAmount; i++)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(45));
            Projectile.NewProjectileDirect(source, position, newVelocity, type, newDamage, knockback, player.whoAmI, 0f, 0f);
        }

        return false;
	}
}
