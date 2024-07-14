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
            Item.height = 60;
            Item.scale = 1.1f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 26;
            Item.useAnimation = 21;
            Item.shoot = ModContent.ProjectileType<MechanicalProj>();
            Item.shootSpeed = 14f;
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.crit = 6;
            Item.knockBack = 6.5f;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.DD2_SonicBoomBladeSlash;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.autoReuse = true;           
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Blue, 1f);
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, new Color(230, 100, 50), 1f);
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Green, 1f);
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position.Y -= 48f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
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