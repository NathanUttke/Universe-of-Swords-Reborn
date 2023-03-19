using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TheEater : ModItem
{
    public override void SetStaticDefaults()
    {
        Tooltip.SetDefault("'Sword of Corruption'");
    }

    public override void SetDefaults()
    {
        Item.width = 54;
        Item.height = 58;
        Item.rare = ItemRarityID.LightPurple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 40;
        Item.useAnimation = 20;
        Item.damage = 15;
        Item.knockBack = 3f;
        Item.UseSound = SoundID.Item1;
        Item.value = Item.sellPrice(0, 0, 60, 0);
        Item.shoot = ProjectileID.TinyEater;
        Item.shootSpeed = 8f;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, position, new Vector2(velocity.X * Utils.SelectRandom<int>(Main.rand, -1, 1, 1, -1, 1, -1), velocity.Y), Item.shoot, (int)(Item.damage * 0.15f), 4f, player.whoAmI);
        return false;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.CorruptPlants, 0f, 0f, 100, default, 2f);
            Main.dust[dust].noGravity = true;
        }
    }
}
