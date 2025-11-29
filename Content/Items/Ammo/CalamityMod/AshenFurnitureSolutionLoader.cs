using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class AshenFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("SmoothBrimstoneSlag"),
            WallType = calamityMod.Find<ModWall>("SmoothBrimstoneSlagWall").Type,
            PlatformType = GetTileType("AshenPlatform"),
            WorkbenchType = GetTileType("AshenWorkbench"),
            TableType = GetTileType("AshenTable"),
            ChairType = GetTileType("AshenChair"),
            ClosedDoorType = GetTileType("AshenDoorClosed"),
            OpenDoorType = GetTileType("AshenDoorOpen"),
            ChestType = GetTileType("AshenChest"),
            BedType = GetTileType("AshenBed"),
            BookcaseType = GetTileType("AshenBookcase"),
            BathtubType = GetTileType("AshenBathtub"),
            CandelabraType = GetTileType("AshenCandelabra"),
            CandleType = GetTileType("AshenCandle"),
            ChandelierType = GetTileType("AshenChandelier"),
            ClockType = GetTileType("AshenMonolith"),
            DresserType = GetTileType("AshenDresser"),
            LampType = GetTileType("AshenLamp"),
            LanternType = GetTileType("AshenLantern"),
            PianoType = -1, //Size mismatch
            SinkType = GetTileType("AshenSink"),
            SofaType = GetTileType("AshenSofa"),
            ToiletType = GetTileType("AshenToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("SmoothBrimstoneSlag").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "AshenFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/AshenFurnitureSolution",
            calamityMod.Find<ModDust>("BrimstoneFlame").Type,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
