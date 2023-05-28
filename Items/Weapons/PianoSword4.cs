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
		DisplayName.SetDefault("Liszt Lasher");
		Tooltip.SetDefault("'Piano sonata in B minor - Liszt'");
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
		SacrificeTotal = 1;
	}

	public override void UseStyle(Player player, Rectangle heldItemFrame)
	{
		player.itemLocation.X -= 1f * (float)player.direction;
		player.itemLocation.Y -= 1f * (float)player.direction;
	}

	public override void AddRecipes()
	{
		Recipe val = CreateRecipe(1);
		val.AddIngredient(ItemID.PearlwoodPiano, 1);
		val.AddIngredient(ItemID.MartianPiano, 1);
		val.AddIngredient(ItemID.CrystalPiano, 1);
		val.AddIngredient(ItemID.SpookyPiano, 1);
		val.AddIngredient(ItemID.FleshPiano, 1);
		val.AddIngredient(ItemID.LihzahrdPiano, 1);
		val.AddIngredient(ItemID.SteampunkPiano, 1);
		val.AddIngredient(ItemID.GoldenPiano, 1);
		val.AddTile(TileID.Sawmill);
		val.Register();
	}

    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int projToShoot = Main.rand.Next(ProjectileID.QuarterNote, ProjectileID.TiedEighthNote);
        Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, projToShoot, damage, knockback, player.whoAmI, 0f, 0f);
        return false;
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
	{
		target.AddBuff(144, 360, false);
		target.AddBuff(30, 360, false);
		target.AddBuff(72, 360, false);
	}
}
