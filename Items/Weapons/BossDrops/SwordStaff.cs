using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Buffs;
using UniverseOfSwordsMod.Projectiles.Minions;

namespace UniverseOfSwordsMod.Items.Weapons.BossDrops
{
    public class SwordStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Type] = true;
            ItemID.Sets.StaffMinionSlotsRequired[Type] = 1;
			Item.ResearchUnlockCount = 1;
        }
        public override void SetDefaults()
        {
            Item.mana = 10;
            Item.damage = 32;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 32;
            Item.height = 32;
            Item.shoot = ModContent.ProjectileType<SwordMinion>();
            Item.knockBack = 4f;
            Item.shootSpeed = 10f;
            Item.UseSound = SoundID.Item169;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.reuseDelay = 2;
            Item.autoReuse = true;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Summon;
            Item.buffType = ModContent.BuffType<SwordMinionBuff>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            Projectile minion = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            minion.originalDamage = Item.damage;

            return false;
        }
    }
}
