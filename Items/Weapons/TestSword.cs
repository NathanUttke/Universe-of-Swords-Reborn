using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TestSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 32;
        Item.height = 32;
        Item.scale = 1f;
        Item.rare = ItemRarityID.Blue;
        Item.expert = true;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 20;
        Item.useAnimation = 20;
        Item.shoot = ModContent.ProjectileType<TestShaderProjectile>();
        Item.shootSpeed = 12f;
        Item.damage = 8;
        Item.knockBack = 2f;
        Item.UseSound = SoundID.Item1;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee;
        Item.ResearchUnlockCount = 1;
    }
}
