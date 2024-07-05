using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class CorruptCrystallus : ModItem
{
	public override void SetDefaults()
	{
        Item.width = 44;
        Item.height = 52;
        Item.rare = ItemRarityID.Green;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 50;
        Item.useAnimation = 25;
        Item.UseSound = SoundID.Item1;
        Item.damage = 18;
        Item.knockBack = 5f;
        Item.shoot = ModContent.ProjectileType<CorruptCrystallusProj>();
        Item.shootSpeed = 4f;
        Item.value = Item.sellPrice(0, 1, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee;
        Item.ResearchUnlockCount = 1;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{	
		if (Main.rand.NextBool(2))
		{
			Dust.NewDust(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 100, Color.MediumOrchid, 1.25f);
		}
	}
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i < 3; i++)
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
			.AddIngredient(ItemID.DemoniteBar, 12)
			.AddIngredient(ItemID.ShadowScale, 8)
			.AddTile(TileID.Anvils)
			.Register();
        CreateRecipe()
			.AddIngredient(ModContent.ItemType<CrimsonCrystallus>(), 1)
			.AddTile(TileID.DemonAltar)
			.Register();
    }
}
