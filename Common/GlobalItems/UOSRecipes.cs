using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using UniverseOfSwordsMod.Items.Materials;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class UOSRecipes : ModSystem
    {
        public static RecipeGroup UOSRecipeGroup;

        public override void Unload()
        {
            UOSRecipeGroup = null;
        }

        public override void AddRecipeGroups()
        {
            //EXAMPLES

            ////hardmode anvils
            //RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Hardmode Anvil", new int[]
            //{
            //    ItemID.OrichalcumAnvil,
            //    ItemID.MythrilAnvil
            //});
            //RecipeGroup.RegisterGroup("FlexTapeIII:HardmodeAnvils", group);


            ////pre-hardmode anvils
            //group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Anvil", new int[]
            //{
            //    ItemID.IronAnvil,
            //    ItemID.LeadAnvil
            //});
            //RecipeGroup.RegisterGroup("FlexTapeIII:Anvils", group);
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Terragrim, 1)
            .AddIngredient(ItemID.EnchantedSword, 1)
            .AddIngredient(ModContent.ItemType<SwordMatter>(), 20)
            .Register();
        }
    }
}

