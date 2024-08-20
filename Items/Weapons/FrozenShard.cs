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
            Item.ResearchUnlockCount = 1;
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
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.autoReuse = true;            
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

            for (int i = 0; i < 2; i++)
            {
                modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
                Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
                Dust dust = Dust.NewDustPerfect(location, ModContent.DustType<GlowDust>(), velocity, 0, Color.SkyBlue, 0.5f);
                dust.noGravity = true;
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
            target.AddBuff(BuffID.Frostburn, 500);
        }
    }
}