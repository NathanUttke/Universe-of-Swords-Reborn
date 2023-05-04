using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Items.Weapons;
public class CaesarSword : ModItem
{
	public override void SetStaticDefaults()
	{
		Tooltip.SetDefault("'Et tu, Brute?'\nHold right click for a stabbing attack");
	}

	public override void SetDefaults()
	{
		Item.width = 64;
		Item.height = 64;
		Item.rare = ItemRarityID.Green;

        Item.DamageType = DamageClass.Melee;
        Item.useStyle = ItemUseStyleID.Swing;
        Item.UseSound = SoundID.Item1;

		Item.value = Item.sellPrice(0, 0, 30, 0);
		Item.autoReuse = true;	
		SacrificeTotal = 1;
		ItemID.Sets.ItemsThatAllowRepeatedRightClick[Type] = true;
	}
	public override bool AltFunctionUse(Player player) => true;

    public override bool CanUseItem(Player player)
    {
        if (player.altFunctionUse == 2)
		{
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.damage = 44;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.knockBack = 3f;
            Item.crit = 8;
        }
		else
		{
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.damage = 22;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 5f;
            Item.crit = 12;
        }
        return true;
    }

    public override bool? UseItem(Player player)
    {
        if (player.altFunctionUse == 2)
        {
            Item.useStyle = ItemUseStyleID.Thrust;
        }
        else
        {
            Item.useStyle = ItemUseStyleID.Swing;
        }
        return true;
    }
}
