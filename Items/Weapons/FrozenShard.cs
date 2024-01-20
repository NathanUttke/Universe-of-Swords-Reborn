using System;
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
    public class FrozenShard : ModItem
    {
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("Frozen Crystallus");
			// Tooltip.SetDefault("Inflicts Frostburn debuff");
		}
		
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 56;
            Item.scale = 1f;

            Item.rare = ItemRarityID.Cyan;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 20;
            Item.UseSound = SoundID.Item1;

            Item.damage = 63;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 8f;

            Item.shoot = ModContent.ProjectileType<FrozenCrystallusProj>();
            Item.shootSpeed = 6f;

            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.autoReuse = true;
            Item.ResearchUnlockCount = 1;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<GlowDust>(), 0f, 0f, 0, Color.Cyan, 1f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            position += position.SafeNormalize(Vector2.Zero).RotatedBy(-MathHelper.PiOver2) * 30f;
            Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CorruptCrystallus>(), 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
            .AddIngredient(ItemID.IceBlock, 400)
            .AddTile(TileID.MythrilAnvil)
			.Register();
            CreateRecipe()
            .AddIngredient(ModContent.ItemType<CrimsonCrystallus>(), 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
            .AddIngredient(ItemID.IceBlock, 400)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
		
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
           if (!target.HasBuff(BuffID.Frostburn))
           {
                target.AddBuff(BuffID.Frostburn, 500);
           }
        }
    }
}