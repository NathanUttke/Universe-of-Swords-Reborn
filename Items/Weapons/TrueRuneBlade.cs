using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueRuneBlade : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("True Rune Blade");
        Tooltip.SetDefault("'Pulses with strong energy of all rune elements'");
    }

    public override void SetDefaults()
    {
        Item.width = 68;
        Item.height = 68;
        Item.scale = 1.2f;
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 15;
        Item.useAnimation = 15;
        Item.damage = 60;
        Item.knockBack = 7f;
        Item.UseSound = SoundID.Item60;
        Item.shoot = ProjectileID.GoldenShowerFriendly;
        Item.shootSpeed = 20f;
        Item.value = Item.sellPrice(0, 6, 0, 0);
        Item.expert = true;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
		SacrificeTotal = 1;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(Mod, "OrangeRuneSword", 1);
        val.AddIngredient(Mod, "BlueRuneBlade", 1);
        val.AddIngredient(Mod, "GreenRuneBlade", 1);
        val.AddIngredient(Mod, "YellowRuneBlade", 1);
        val.AddIngredient(Mod, "PurpleRuneBlade", 1);
        val.AddIngredient(Mod, "RedRuneBlade", 1);
        val.AddIngredient(Mod, "Orichalcon", 1);
        val.AddIngredient(ItemID.BrokenHeroSword, 1);
        val.AddTile(TileID.CrystalBall);
        val.Register();
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {

        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2((float)hitbox.X, (float)hitbox.Y), hitbox.Width, hitbox.Height, DustID.TreasureSparkle, 0f, 0f, 100, default(Color), 2f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity.X -= (float)player.direction * 0f;
            Main.dust[dust].velocity.Y -= 0f;
        }
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.IceBolt, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.BallofFire, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.ShadowFlameKnife, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.CursedFlameFriendly, damage, knockback, player.whoAmI, 0f, 0f);
        return true;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(69, 360, false);
        target.AddBuff(44, 360, false);
        target.AddBuff(24, 360, false);
        target.AddBuff(39, 360, false);
        int healingAmt = damage / 15;
        player.statLife += healingAmt;
        player.HealEffect(healingAmt, true);
    }
}
