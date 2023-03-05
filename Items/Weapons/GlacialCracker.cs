using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GlacialCracker : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'How did you manage to already break it?'");
    }

    public override void SetDefaults()
    {
        Item.width = 81;
        Item.height = 81;
        Item.scale = 2f;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 23;
        Item.useAnimation = 23;
        Item.damage = 180;
        Item.knockBack = 10f;
        Item.UseSound = SoundID.Item28;
        Item.shoot = ProjectileID.NorthPoleSpear;
        Item.shootSpeed = 70f;
        Item.value = Item.sellPrice(0, 50, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.X -= 3f * (float)player.direction;
        player.itemLocation.Y -= 3f * (float)player.direction;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.IceBlade, 1);
        val.AddIngredient(ItemID.Amarok, 1);
        val.AddIngredient(ItemID.Frostbrand, 2);
        val.AddIngredient(ItemID.NorthPole, 1);
        val.AddIngredient(ItemID.FrostCore, 10);
        val.AddIngredient(ItemID.IceFeather, 2);
        val.AddIngredient(ItemID.BrokenHeroSword, 1);
        val.AddIngredient(ItemID.IceBlock, 999);
        val.AddTile(TileID.LunarCraftingStation);
        val.Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
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
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(44, 360, false);
    }
}
