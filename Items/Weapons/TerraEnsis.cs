using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;
[LegacyName (["TrueTerrablade"])]
public class TerraEnsis : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
    {
        Item.damage = 120;
        Item.DamageType = DamageClass.Melee; 
        Item.width = 62;
        Item.height = 68;
        Item.useTime = 20;
        Item.useAnimation = 16;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.knockBack = 10f;
        Item.value = Item.sellPrice(0, 5, 0, 0);
        Item.shoot = ModContent.ProjectileType<TrueTerrabladeProjectile>();
        Item.shootSpeed = 15f;
        Item.shootsEveryUse = true;
        Item.noMelee = true;
        Item.rare = ItemRarityID.Purple;
        Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
        Item.autoReuse = true;
        Item.ResearchUnlockCount = 1;
    }

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
        Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), ProjectileID.TerraBlade2, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale + 0.2f);
        NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

        return true;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {            
        int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.TerraBlade, 0f, 0f, 100, default, 2f);
        Main.dust[dust].noGravity = true;    
    }

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.TerraBlade, 1)
        .AddIngredient(ItemID.SpectreBar, 20)
        .AddIngredient(ItemID.BrokenHeroSword, 1)
        .AddIngredient(ModContent.ItemType<SwordMatter>(), 40)
        .AddTile(TileID.LunarCraftingStation)
        .Register();
    }
}
