using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Items.Weapons;

public class TrueGemSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
        Item.Size = new(58);
        Item.scale = 1.1f;
		Item.rare = ItemRarityID.Lime;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 20;
		Item.shoot = ProjectileID.EmeraldBolt;
		Item.shootSpeed = 10f;
		Item.damage = 20;
		Item.knockBack = 6f;
		Item.UseSound = SoundID.Item1;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 		
	}
	
	public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
		int projToShoot = Utils.SelectRandom(Main.rand, ProjectileID.EmeraldBolt, ProjectileID.DiamondBolt, ProjectileID.AmethystBolt, ProjectileID.TopazBolt, ProjectileID.SapphireBolt, ProjectileID.RubyBolt, ProjectileID.AmberBolt);
        Projectile gemProj = Projectile.NewProjectileDirect(source, position, velocity, projToShoot, damage, knockback, player.whoAmI);
		gemProj.extraUpdates = 1;
		gemProj.DamageType = DamageClass.MeleeNoSpeed;
		gemProj.timeLeft = 30;
        return false;
    }

	public override void MeleeEffects(Player player, Rectangle hitbox)
	{
        UniversePlayer modPlayer = player.GetModPlayer<UniversePlayer>();

        for (int i = 0; i < 2; i++)
        {
            modPlayer.GetPointOnSwungItemPath(Item.width, Item.height, 1f * Main.rand.NextFloat(), player.GetAdjustedItemScale(Item), out var location, out var outwardDirection);
            Vector2 velocity = outwardDirection.RotatedBy(MathHelper.PiOver2 * player.direction * player.gravDir);
            Dust dust = Dust.NewDustPerfect(location, DustID.RainbowRod, velocity, 0);
            dust.noGravity = true;
        }
	}

    public override void AddRecipes()
    {
        CreateRecipe()
        .AddIngredient(ItemID.Topaz, 5)
        .AddIngredient(ItemID.Sapphire, 5)
        .AddIngredient(ItemID.Emerald, 5)
        .AddIngredient(ItemID.Amethyst, 10)
        .AddIngredient(ItemID.Amber, 10)
        .AddIngredient(ItemID.Diamond, 10)
        .AddIngredient(ItemID.Ruby, 10)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 10)
        .AddIngredient(ItemID.ShadowScale, 10)
        .AddTile(TileID.TinkerersWorkbench)
        .Register();
    }
}
