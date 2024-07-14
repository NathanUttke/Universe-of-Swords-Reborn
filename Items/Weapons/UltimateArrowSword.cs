using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Mono.Cecil;

namespace UniverseOfSwordsMod.Items.Weapons;

public class UltimateArrowSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Item.ResearchUnlockCount = 1;
		Main.RegisterItemAnimation(Type, new DrawAnimationVertical(55, 13, false));
		ItemID.Sets.AnimatesAsSoul[Type] = true;
	}

    private readonly int[] shootList = [
        ProjectileID.WoodenArrowFriendly,
        ProjectileID.UnholyArrow,
        ProjectileID.JestersArrow,
        ProjectileID.HellfireArrow, 
		ProjectileID.FireArrow, 
		ProjectileID.HolyArrow, 
		ProjectileID.CursedArrow, 
		ProjectileID.BoneArrow, 
		ProjectileID.FrostburnArrow, 
		ProjectileID.ChlorophyteArrow,		
		ProjectileID.IchorArrow,	
		ProjectileID.VenomArrow
	];

	public override void SetDefaults()
	{
		Item.damage = 120;
		Item.DamageType = DamageClass.Melee; 
		Item.width = 64;
		Item.height = 64;
		Item.useTime = 8;
		Item.useAnimation = 20;
        Item.autoReuse = true;
        Item.noUseGraphic = false;
        Item.noMelee = false;
		Item.UseSound = SoundID.Item15;
		Item.useStyle = ItemUseStyleID.Swing;
        Item.shoot = ProjectileID.None;
        Item.knockBack = 8f;
		Item.value = Item.sellPrice(0, 2, 0, 0);
		Item.rare = ItemRarityID.Lime;
		Item.scale = 1.3f;
	}

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        for (int i = 0; i < 8; i++)
        {
            Vector2 v = Main.rand.NextVector2CircularEdge(200f, 200f);
            if (v.Y < 0f)
            {
                v.Y *= -1f;
            }
            v.Y += 100f;
            Vector2 newVelocity = v.SafeNormalize(Vector2.UnitY) * (12f + Main.rand.NextFloat() * 2f);
            Projectile arrowProj = Projectile.NewProjectileDirect(target.GetSource_OnHit(target), target.Center + -Vector2.Zero - newVelocity * 20f, newVelocity, shootList[Main.rand.Next(0, shootList.Length)], (int)(Item.damage * 0.75), 0f, player.whoAmI, 0f);
            arrowProj.penetrate = 1;
            arrowProj.extraUpdates = 3;
			arrowProj.timeLeft = 40;
        }
    }

    public override void AddRecipes()
    {
		CreateRecipe()
			.AddIngredient(ModContent.ItemType<WoodenArrowSword>())
			.AddIngredient(ModContent.ItemType<FrostburnArrowSword>())
			.AddIngredient(ModContent.ItemType<FlamingArrowSword>())
			.AddIngredient(ModContent.ItemType<CursedArrowSword>())
			.AddIngredient(ModContent.ItemType<VenomArrowSword>())
			.AddIngredient(ModContent.ItemType<HolyArrowSword>())
			.AddIngredient(ModContent.ItemType<UnholyArrowSword>())
			.AddIngredient(ModContent.ItemType<JesterArrowSword>())
			.AddIngredient(ModContent.ItemType<IchorArrowSword>())
			.AddIngredient(ModContent.ItemType<HellfireArrowSword>())
			.AddIngredient(ModContent.ItemType<BoneArrowSword>())
			.AddIngredient(ModContent.ItemType<ChlorophyteArrowSword>())
			.AddIngredient(ModContent.ItemType<LuminiteArrowSword>())
			.AddTile(TileID.MythrilAnvil)
			.Register();
    }
}
