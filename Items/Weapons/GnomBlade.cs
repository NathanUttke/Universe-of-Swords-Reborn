using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GnomBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.ArmorPenetration = 10;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 15;
		Item.useAnimation = 15;
		Item.damage = 150;
		Item.knockBack = 9f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 5, 0, 0);		
		Item.DamageType = DamageClass.MeleeNoSpeed;
		Item.crit = 8;
        Item.autoReuse = true;
		Item.noUseGraphic = true;
		Item.noMelee = true;
        Item.shoot = ModContent.ProjectileType<GnomBladeHoldoutProj>();
		Item.shootSpeed = 1f;
	}
	
    public override bool MeleePrefix() => true;

    public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;

	int swingDir = 0;
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		if (swingDir > 1)
		{
			swingDir = 0;
		}
		Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI, swingDir);
		swingDir++;
		return false;
    }

    public override void AddRecipes()
	{
        Mod CalamityMod = UniverseOfSwordsMod.Instance.CalamityMod;
		Recipe newRecipe = CreateRecipe();
		newRecipe.AddIngredient(ItemID.LunarBar, 10);
		newRecipe.AddIngredient(ItemID.GardenGnome, 1);
		newRecipe.AddIngredient(ModContent.ItemType<Doomsday>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<LunarOrb>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<Orichalcon>(), 5);
		newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 100);
		newRecipe.AddIngredient(ModContent.ItemType<PumpkinBoom>(), 1);
        if (CalamityMod is not null)
        {
            newRecipe.AddIngredient(CalamityMod.Find<ModItem>("UelibloomBar"), 5);
        }
        newRecipe.AddTile(TileID.LunarCraftingStation);
        newRecipe.Register();
	}

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
        target.AddBuff(BuffID.Weak, 400, true);
        target.AddBuff(BuffID.Ichor, 400, true);
        target.AddBuff(BuffID.Venom, 400, true);
        target.AddBuff(BuffID.Slow, 400, true);
        target.AddBuff(BuffID.CursedInferno, 400, true);
    }
}
