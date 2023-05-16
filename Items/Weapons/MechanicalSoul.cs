using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class MechanicalSoul : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 60;
            Item.scale = 1.1f;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 20;

            Item.shoot = ModContent.ProjectileType<MechanicalProj>();
            Item.shootSpeed = 10f;

            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;

            Item.crit = 6;
            Item.knockBack = 6.5f;
            Item.rare = ItemRarityID.Pink;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.autoReuse = true;

        }	
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(2))
            {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueTorch, 0f, 0f, 100, default, 2f);
                Main.dust[dust].noGravity = true;
				dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.RedTorch, 0f, 0f, 100, default, 2f);
                Main.dust[dust].noGravity = true;
				dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GreenTorch, 0f, 0f, 100, default, 2f);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<FrozenShard>(), 1)
                .AddIngredient(ModContent.ItemType<UpgradeMatter>(), 4)
                .AddIngredient(ItemID.HallowedBar, 25)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}