using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class GelBlade : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 54;
        Item.height = 54;
        Item.rare = ItemRarityID.White;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 10;
        Item.knockBack = 4f;
        Item.UseSound = SoundID.Item1;
        Item.value = 1500;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        Item.ResearchUnlockCount = 1;
    }

    public override void AddRecipes()
    {
        CreateRecipe()
            .AddIngredient(ItemID.Gel, 25)
            .AddTile(TileID.WorkBenches)
            .Register();
    }

    public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
    {
        target.AddBuff(BuffID.Slimed, 400, false);
        if (!target.HasBuff(BuffID.Slow))
        {
            target.AddBuff(BuffID.Slow, 400, false);
        }
    }
}
