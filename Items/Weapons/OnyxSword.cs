using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OnyxSword : ModItem
{
    private int swingCounter;
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.25f;
        Item.rare = ItemRarityID.LightPurple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 40;
        Item.knockBack = 6f;
        Item.shoot = ProjectileID.BlackBolt;
        Item.shootSpeed = 15f;
        Item.UseSound = SoundID.Item1;
        Item.value = 70500;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
        .AddIngredient(ItemID.SoulofNight, 12)
        .AddIngredient(ItemID.OnyxBlaster, 1)
        .AddTile(TileID.MythrilAnvil)
        .Register();
    }


    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        swingCounter++;
        if (swingCounter == 3)
        {
            swingCounter = 0;
            Projectile blackBolt = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            blackBolt.DamageType = DamageClass.MeleeNoSpeed;
        }
        return false;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }
}
