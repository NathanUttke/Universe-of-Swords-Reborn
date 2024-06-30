using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Utilities;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Apocalypse : ModItem
{

    public override void SetDefaults()
    {
        Item.Size = new(60);
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 45;
        Item.useAnimation = 15;
        Item.damage = 110;
        Item.knockBack = 12f;
        Item.UseSound = SoundID.Item116;
        Item.shoot = ProjectileID.ApprenticeStaffT3Shot;
        Item.shootSpeed = 10f;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust.NewDustDirect(new(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.OrangeTorch, 0f, 0f, 0, Color.Orange, 1f);
        }
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        for (int i = -1; i <= 1; i++)
        {
            Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15 * i));
            Projectile.NewProjectileDirect(source, position, newVelocity, type, damage, knockback, player.whoAmI);
        }
        return false;
    }
}
