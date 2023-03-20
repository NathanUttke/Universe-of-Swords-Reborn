using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace UniverseOfSwordsMod.Common.GlobalItems
{
    public class UOSRRecipes : ModSystem
    {
        public static RecipeGroup UOSRRecipeGroup;

        public override void Unload()
        {
            UOSRRecipeGroup = null;
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
            Recipe a = Recipe.Create(ItemID.Terragrim, 1);
            a.AddIngredient(ItemID.EnchantedSword, 1);
            a.AddIngredient(null, "UpgradeMatter", 4);
            a.Register();
        }
    }
}

