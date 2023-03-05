using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Executioner : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Executioner");
    }

    public override void SetDefaults()
    {
        Item.width = 78;
        Item.height = 78;
        Item.scale = 1.2f;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 70;
        Item.knockBack = 7f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.CrystalLeafShot;
        Item.shootSpeed = 70f;
        Item.value = Item.sellPrice(0, 15, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
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

    public override void HoldStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.X -= 5f * (float)player.direction;
        player.itemLocation.Y -= 5f * player.gravDir;
    }
}
