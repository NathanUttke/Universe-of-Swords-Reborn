using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
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
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.Frost, 0f, 0f, 100, default, 2f);
                Main.dust[dust].noGravity = true;
            }
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