using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;

namespace UniverseOfSwordsMod.Items.Weapons;

public class MozartMauler : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
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
		Item.shootSpeed = 10f;
		Item.value = Item.sellPrice(0, 10, 0, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation = player.Center;
    }

    public override void AddRecipes()
	{
		CreateRecipe()
            .AddIngredient(ItemID.SkywarePiano, 1)
            .AddIngredient(ItemID.SlimePiano, 1)
            .AddIngredient(ItemID.BlueDungeonPiano, 1)
            .AddIngredient(ItemID.GreenDungeonPiano, 1)
            .AddIngredient(ItemID.PinkDungeonPiano, 1)
            .AddIngredient(ItemID.ObsidianPiano, 1)
            .AddIngredient(ItemID.MeteoritePiano, 1)
            .AddIngredient(ItemID.BonePiano, 1)
            .AddTile(TileID.Sawmill)
            .Register();
    }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int projToShoot = Main.rand.Next(ProjectileID.QuarterNote, ProjectileID.TiedEighthNote);
        Projectile noteProj = Projectile.NewProjectileDirect(source, position, velocity, projToShoot, damage, knockback, player.whoAmI);
        noteProj.timeLeft = 100;
        noteProj.penetrate = 3;
        noteProj.DamageType = DamageClass.MeleeNoSpeed;
        return false;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
		target.AddBuff(BuffID.Slimed, 360, false);
	}
}
