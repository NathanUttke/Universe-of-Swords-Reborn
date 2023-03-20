using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PianoSword2 : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Gershwin Gasher");
        Tooltip.SetDefault("'Rhapsody in Blue - Gershwin'");
    }

    public override void SetDefaults()
    {
        Item.width = 128;
        Item.height = 128;
        Item.rare = ItemRarityID.Cyan;
        Item.crit = 6;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 44;
        Item.knockBack = 8f;
        Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/PianoBlue");
        Item.shoot = ProjectileID.Mushroom;
        Item.shootSpeed = 15f;
        Item.value = 80000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.X -= 1f * (float)player.direction;
        player.itemLocation.Y -= 1f * (float)player.direction;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.MushroomPiano, 1);
        val.AddIngredient(ItemID.GranitePiano, 1);
        val.AddIngredient(ItemID.MarblePiano, 1);
        val.AddIngredient(ItemID.PumpkinPiano, 1);
        val.AddIngredient(ItemID.DynastyPiano, 1);
        val.AddIngredient(ItemID.FrozenPiano, 1);
        val.AddIngredient(ItemID.GlassPiano, 1);
        val.AddIngredient(ItemID.HoneyPiano, 1);
        val.AddTile(TileID.Sawmill);
        val.Register();
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.JavelinFriendly, damage, knockback, player.whoAmI, 0f, 0f);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ProjectileID.JackOLantern, damage, knockback, player.whoAmI, 0f, 0f);
        return true;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(153, 360, false);
        target.AddBuff(44, 360, false);
        target.AddBuff(70, 360, false);
    }
}
