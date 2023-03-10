using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class SwordOfTheEmperor : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Sword of The Emperor");
        Tooltip.SetDefault("'Grant them the Emperor's mercy. Let the heretics burn!'");
    }

    public override void SetDefaults()
    {
        Item.width = 170;
        Item.height = 170;        
        Item.rare = ItemRarityID.Red;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 11;
        Item.useAnimation = 11;
        Item.damage = 100;
        Item.knockBack = 3f;
        Item.UseSound = SoundID.Item74;
        Item.value = 999999;
        Item.autoReuse = true;
        Item.DamageType = DamageClass.Melee; SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.X -= 1f * (float)player.direction;
        player.itemLocation.Y -= 1f * (float)player.direction;
    }

    public override void AddRecipes()
    {

        Recipe val = CreateRecipe(1);
        val.AddIngredient(Mod, "SwordMatter", 4000);
        val.AddIngredient(ItemID.HallowedBar, 4000);
        val.AddIngredient(ItemID.BrokenHeroSword, 16);
        val.AddIngredient(ItemID.EnchantedSword, 4);
        val.AddIngredient(ItemID.Terragrim, 1);
        val.AddTile(TileID.MythrilAnvil);
        val.Register();
    }

    public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
    {
        target.AddBuff(Mod.Find<ModBuff>("EmperorBlaze").Type, 999, true);
    }
    public override void OnHitPvp(Player player, Player target, int damage, bool crit)
    {
        target.AddBuff(Mod.Find<ModBuff>("EmperorBlaze").Type, 999, true);
    }
}
