using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GlacialCracker : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'How did you manage to already break it?'");
    }

    public override void SetDefaults()
    {
        Item.width = 162;
        Item.height = 162;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 60;
        Item.useAnimation = 30;
        Item.damage = 100;
        Item.knockBack = 8f;
        Item.UseSound = SoundID.Item28;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.IceBlade, 1);
        val.AddIngredient(ItemID.Frostbrand, 1);
        val.AddIngredient(ItemID.NorthPole, 1);
        val.AddIngredient(ItemID.FrostCore, 1);
        val.AddIngredient(ItemID.IceFeather, 1);
        val.AddIngredient(ItemID.BrokenHeroSword, 1);
        val.AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    /*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float numberProjectiles = 3 + Main.rand.Next(4);
        float rotation = MathHelper.ToRadians(10f);
        position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 5f;
        for (int i = 0; (float)i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, (float)i / (numberProjectiles - 1f)), default(Vector2)) * 0.2f;
            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI, 0f, 0f);
        }
        return false;
    }*/

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(44, 360, false);
    }
}
