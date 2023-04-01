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
        Item.scale = 1.15f;
        Item.rare = ItemRarityID.Lime;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 20;
        Item.damage = 65;
        Item.knockBack = 6f;
        Item.UseSound = SoundID.Item1;
        Item.shoot = ProjectileID.SeedlerThorn;
        Item.shootSpeed = 25f;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float numberProjectiles = 3;
        float rotation = MathHelper.ToRadians(20f);

        position += Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 5f;
        for (int i = 0; i < numberProjectiles; i++)
        {
            Vector2 perturbedSpeed = Utils.RotatedBy(new Vector2(velocity.X, velocity.Y), (double)MathHelper.Lerp(0f - rotation, rotation, i / (numberProjectiles - 1f)), default) * 0.2f;
			Projectile proj = Projectile.NewProjectileDirect(source, position, perturbedSpeed, Item.shoot, damage, knockback, player.whoAmI);
			proj.DamageType = DamageClass.MeleeNoSpeed;
        }
        return false;
    }
}
