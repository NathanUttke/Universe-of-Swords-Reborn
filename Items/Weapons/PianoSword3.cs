using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class PianoSword3 : ModItem
{
	public override void SetStaticDefaults()
	{
		// DisplayName.SetDefault("Mozart Mauler");
		// Tooltip.SetDefault("'Piano Concerto No.20 - Mozart'");
	}

	public override void SetDefaults()
	{
		Item.width = 128;
		Item.height = 128;
		Item.rare = ItemRarityID.Red;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 30;
		Item.useAnimation = 30;
		Item.damage = 30;
		Item.knockBack = 3f;
		Item.UseSound = new SoundStyle($"{nameof(UniverseOfSwordsMod)}/Sounds/Item/PianoRed");

		Item.shoot = ProjectileID.FallingStar;
		Item.shootSpeed = 15f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
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
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.SkywarePiano, 1);
		val.AddIngredient(ItemID.SlimePiano, 1);
		val.AddIngredient(ItemID.BlueDungeonPiano, 1);
		val.AddIngredient(ItemID.GreenDungeonPiano, 1);
		val.AddIngredient(ItemID.PinkDungeonPiano, 1);
		val.AddIngredient(ItemID.ObsidianPiano, 1);
		val.AddIngredient(ItemID.MeteoritePiano, 1);
		val.AddIngredient(ItemID.BonePiano, 1);
		val.AddTile(TileID.Sawmill);
		val.Register();
	}
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int projToShoot = Main.rand.Next(ProjectileID.QuarterNote, ProjectileID.TiedEighthNote);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, projToShoot, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(137, 360, false);
	}
}
