using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PianoSword4 : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Liszt Lasher");
		// Tooltip.SetDefault("'Piano sonata in B minor - Liszt'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Yellow;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 30;
		Item.knockBack = 3f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/PianoYellow");
		Item.shoot = ProjectileID.HolyArrow;
		Item.shootSpeed = 17f;
		Item.value = Item.sellPrice(0, 12, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
		Item.ResearchUnlockCount = 1;
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
		.AddIngredient(ItemID.PearlwoodPiano, 1)
		.AddIngredient(ItemID.MartianPiano, 1)
		.AddIngredient(ItemID.CrystalPiano, 1)
		.AddIngredient(ItemID.SpookyPiano, 1)
		.AddIngredient(ItemID.FleshPiano, 1)
		.AddIngredient(ItemID.LihzahrdPiano, 1)
		.AddIngredient(ItemID.SteampunkPiano, 1)
		.AddIngredient(ItemID.GoldenPiano, 1)
		.AddTile(TileID.Sawmill)
		.Register();
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int projToShoot = Main.rand.Next(ProjectileID.QuarterNote, ProjectileID.TiedEighthNote);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, projToShoot, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(144, 360, false);
		target.AddBuff(30, 360, false);
		target.AddBuff(72, 360, false);
	}
}
