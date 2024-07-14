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
        Item.ResearchUnlockCount = 1;
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
        Item.shootSpeed = 12f;
        Item.value = Item.sellPrice(0, 3, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = 0; i <= 6; i++)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(45));
            Projectile proj = Projectile.NewProjectileDirect(source, position, newVelocity, type, damage / 3, knockback, player.whoAmI, 1f, 1f);
			proj.DamageType = DamageClass.MeleeNoSpeed;
            proj.timeLeft = 25;
        }
        return false;
    }
}
