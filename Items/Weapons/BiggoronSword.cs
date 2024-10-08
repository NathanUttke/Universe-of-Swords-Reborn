using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons
{
    public class BiggoronSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 90;
            Item.height = 90;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.autoReuse = true;
            Item.damage = 45;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 8f;
            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(0, 0, 60, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.scale = 1.25f;
            Item.shoot = ModContent.ProjectileType<SwordLegendHoldoutProj>();            
            Item.shootSpeed = 5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
        }
        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[ModContent.ProjectileType<SwordLegendHoldoutProj>()] <= 0;
    }
}


