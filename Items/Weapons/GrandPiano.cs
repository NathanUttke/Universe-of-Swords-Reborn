using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using UniverseOfSwordsMod.Items.Materials;
using UniverseOfSwordsMod.Projectiles;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GrandPiano : ModItem
{
    public override void SetStaticDefaults()
    {
        Item.ResearchUnlockCount = 1;
    }

    public override void SetDefaults()
	{
		Item.Size = new(142);
		Item.rare = ItemRarityID.Orange;
		Item.crit = 11;
		Item.useStyle = ItemUseStyleID.Swing;
		Item.useTime = 20;
		Item.useAnimation = 20;
		Item.damage = 75;
		Item.knockBack = 10f;
		Item.UseSound = SoundID.Item169;
		Item.value = Item.sellPrice(0, 8, 0, 0);
		Item.autoReuse = true;
		Item.ArmorPenetration = 20;
		Item.DamageType = DamageClass.Melee; 
		Item.holdStyle = ItemHoldStyleID.HoldGuitar;
	}

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
		player.itemLocation = player.MountedCenter - Vector2.UnitY * 8f;
    }

    public override void AddRecipes()
	{		
		CreateRecipe()
		.AddIngredient(ModContent.ItemType<BeethovenBeater>(), 1)
		.AddIngredient(ModContent.ItemType<GershwinGasher>(), 1)
		.AddIngredient(ModContent.ItemType<MozartMauler>(), 1)
		.AddIngredient(ModContent.ItemType<LisztLasher>(), 1)
		.AddIngredient(ModContent.ItemType<SwordMatter>(), 40)
		.AddTile(TileID.Autohammer)
		.Register();
	}

    public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
    {
        if (ModLoader.TryGetMod("CalamityMod", out _))
        {
            damage *= 1.25f;
        }
        return;
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
	{
        target.AddBuff(BuffID.Bleeding, 400);
        target.AddBuff(BuffID.Weak, 400);
        target.AddBuff(BuffID.Confused, 400);
    }
}
