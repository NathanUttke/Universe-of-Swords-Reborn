using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;

public class IceSword : ModItem
{
    public override void SetDefaults()
    {
        Item.width = 44;
        Item.height = 50;
        Item.rare = ItemRarityID.Blue;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.useTime = 30;
        Item.useAnimation = 30;
        Item.damage = 11;
        Item.knockBack = 1f;
        Item.UseSound = SoundID.Item1;
        Item.value = 128;
        Item.autoReuse = false;
        Item.DamageType = DamageClass.Melee; 
        SacrificeTotal = 1;
    }

    public override void UseStyle(Player player, Rectangle heldItemFrame)
    {
        player.itemLocation.Y -= 1f * player.gravDir;
    }

    public override void MeleeEffects(Player player, Rectangle hitbox)
    {
        if (Main.rand.NextBool(2))
        {
            int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.DungeonSpirit, 0f, 0f, 100, default, 2f);
            Main.dust[dust].noGravity = true;
        }
    }
    public override void AddRecipes()
    {
        Recipe val = CreateRecipe(1);
        val.AddIngredient(ItemID.IceBlock, 25);
        val.AddTile(TileID.WorkBenches);
        val.Register();
    }
}
