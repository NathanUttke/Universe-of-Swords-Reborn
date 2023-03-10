using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class Brisingr : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 64;
        Item.height = 64;
        Item.rare = ItemRarityID.Pink;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 10;
        Item.useAnimation = 10;
        Item.damage = 67;
        Item.knockBack = 10f;
        Item.UseSound = SoundID.Item1;
        Item.value = 590000;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.Excalibur, 1);
        val.AddIngredient(ItemID.Sapphire, 1);
        val.AddIngredient(ItemID.MeteoriteBar, 10);
        val.AddIngredient(ItemID.SoulofLight, 10);
        val.AddIngredient(ItemID.SoulofMight, 5);
        val.AddTile(TileID.DemonAltar);
        val.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(24, 360, false);
    }
}
