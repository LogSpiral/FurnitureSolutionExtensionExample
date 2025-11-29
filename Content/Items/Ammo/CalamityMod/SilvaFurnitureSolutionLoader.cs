using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class SilvaFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("SilvaCrystal"),
            WallType = calamityMod.Find<ModWall>("SilvaWall").Type,
            PlatformType = GetTileType("SilvaPlatform"),
            WorkbenchType = GetTileType("SilvaWorkBench"),
            TableType = GetTileType("SilvaTable"),
            ChairType = GetTileType("SilvaChair"),
            ClosedDoorType = GetTileType("SilvaDoorClosed"),
            OpenDoorType = GetTileType("SilvaDoorOpen"),
            ChestType = GetTileType("SilvaChest"),
            BedType = GetTileType("SilvaBed"),
            BookcaseType = GetTileType("SilvaBookcase"),
            BathtubType = GetTileType("SilvaBathtub"),
            CandelabraType = GetTileType("SilvaCandelabra"),
            CandleType = GetTileType("SilvaCandle"),
            ChandelierType = GetTileType("SilvaChandelier"),
            ClockType = GetTileType("SilvaClock"),
            DresserType = GetTileType("SilvaDresser"),
            LampType = GetTileType("SilvaLamp"),
            LanternType = GetTileType("SilvaLantern"),
            PianoType = GetTileType("SilvaPiano"),
            SinkType = GetTileType("SilvaSink"),
            SofaType = GetTileType("SilvaBench"),
            ToiletType = GetTileType("SilvaToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("SilvaCrystal").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "SilvaFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/SilvaFurnitureSolution",
            calamityMod.Find<ModDust>("SilvaTileGold").Type,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
