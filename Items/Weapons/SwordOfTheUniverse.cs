using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;
using UniverseOfSwordsMod;

namespace UniverseOfSwordsMod.Items.Weapons;

[LegacyName (["SwordOfTheUniverseNew"])]
public class SwordOfTheUniverse : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 140;
		Item.height = 140;
		Item.rare = ItemRarityID.Purple;
		Item.crit = 20;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 190;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item169;
		Item.shoot = ModContent.ProjectileType<SwordOfTheUniverseHoldoutProj>();
		Item.shootSpeed = 7f;
		Item.value = Item.sellPrice(0, 8, 0, 0);
        Item.rare = ItemRarityID.Red;
        Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        //Item.holdStyle = ItemHoldStyleID.HoldGolfClub;
    }

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (UniverseOfSwordsMod.Instance.CalamityMod is not null)
        {
            damage *= 1.25f;
        }
    }

    public override void AddRecipes()
	{
        Mod CalamityMod = UniverseOfSwordsMod.Instance.CalamityMod;
        Recipe newRecipe = CreateRecipe();
		newRecipe.AddIngredient(ModContent.ItemType<CosmoStorm>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SuperInflation>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<EdgeLord>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<ScarletFlareGreatsword>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SolBlade>(), 1);
		newRecipe.AddIngredient(ModContent.ItemType<SwordMatter>(), 250);
        if (CalamityMod is not null)
        {
            newRecipe.AddIngredient(CalamityMod.Find<ModItem>("AuricBar"), 5);
            newRecipe.AddTile(CalamityMod.Find<ModTile>("CosmicAnvil"));
        }
        else
        {
            newRecipe.AddTile(TileID.LunarCraftingStation);
        }
        newRecipe.Register();
    }
    public override bool CanUseItem(Player player) => player.ownedProjectileCounts[Item.shoot] < 1;


    /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Vector2 newVelocity = Vector2.Normalize(velocity) * 40f;
        int projAmount = 4;
        for (int i = 0; i < projAmount; i++)
        {
            float spread = i - (projAmount - 1f) / 2f;
            Vector2 offset = newVelocity.RotatedBy(MathHelper.TwoPi / 7.5f * spread);

            Projectile.NewProjectile(source, position + offset, velocity, type, damage / 2, knockback, player.whoAmI);
        }
        
        return false;
    }*/

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust dust = Main.dust[Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.PortalBoltTrail, 0f, 0f, 100, Utils.SelectRandom(Main.rand, Color.Aqua, Color.Red, Color.Pink, Color.Yellow, Color.Blue), 1.5f)];
            dust.noGravity = true;
        }
    }
}
