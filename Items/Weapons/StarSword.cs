using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Dusts;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class StarSword : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.width = 60;
		Item.height = 64;
		Item.rare = ItemRarityID.LightRed;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 55;
		Item.useAnimation = 25;
		Item.damage = 25;
		Item.knockBack = 5f;
		Item.shoot = ModContent.ProjectileType<StarSwordProjectile>();
		Item.shootSpeed = 9f;
		Item.UseSound = SoundID.Item1 with { Pitch = 0.35f };
		Item.value = Item.sellPrice(0, 1, 20, 0);
		Item.autoReuse = true;
		Item.DamageType = DamageClass.Melee; 		
	}

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<StarDust>(), 0f, 0f, 0, Color.SkyBlue, 1f);
        }
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 15)
		.AddIngredient(ItemID.Starfury, 1)
		.AddIngredient(ItemID.FallenStar, 20)
		.AddTile(TileID.Anvils)
		.Register();
	}
}
