using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class OnyxSword : ModItem
{
    private int swingCounter;
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1.25f;
        Item.rare = ItemRarityID.LightPurple;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.damage = 35;
        Item.knockBack = 6f;
        Item.shoot = ProjectileID.BlackBolt;
        Item.shootSpeed = 10f;
        Item.UseSound = SoundID.Item1 with { Pitch = 0.35f };
        Item.value = 70500;
        Item.autoReuse = true;
        Item.noMelee = true;
        Item.DamageType = DamageClass.Melee; 
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
            Projectile blackBolt = Projectile.NewProjectileDirect(source, position, velocity, type, (int)(damage * 1.25f), knockback, player.whoAmI);
            blackBolt.DamageType = DamageClass.MeleeNoSpeed;
            blackBolt.usesLocalNPCImmunity = true;
            blackBolt.extraUpdates = 3;
        }

        float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
        Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), ModContent.ProjectileType<OnyxEnergyProj>(), damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale + 0.2f);
        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

        return false;
    }
}
