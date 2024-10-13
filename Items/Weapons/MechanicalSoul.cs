using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class MechanicalSoul : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 64;
            Item.scale = 1.125f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.shoot = ModContent.ProjectileType<MechanicalSoulProj>();
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 6;
            Item.knockBack = 6.5f;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.shootsEveryUse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
            Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
            NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.	
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<FrozenShard>(), 1)
                .AddIngredient(ModContent.ItemType<SwordMatter>(), 30)
                .AddIngredient(ItemID.HallowedBar, 25)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}