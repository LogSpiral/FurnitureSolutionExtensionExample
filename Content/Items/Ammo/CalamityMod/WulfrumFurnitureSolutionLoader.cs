using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class WulfrumFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("WulfrumPlating"),
            WallType = calamityMod.Find<ModWall>("WulfrumPlatingWall").Type,
            PlatformType = GetTileType("WulfrumPlatform"),
            WorkbenchType = GetTileType("WulfrumWorkbench"),
            TableType = GetTileType("WulfrumTable"),
            ChairType = -1, // Size mismatch
            ClosedDoorType = GetTileType("WulfrumDoorClosed"),
            OpenDoorType = GetTileType("WulfrumDoorOpen"),
            ChestType = GetTileType("WulfrumChest"),
            BedType = GetTileType("WulfrumBed"),
            BookcaseType = GetTileType("WulfrumBookcase"),
            BathtubType = GetTileType("WulfrumBathtub"),
            CandelabraType = GetTileType("WulfrumCandelabra"),
            CandleType = GetTileType("WulfrumCandle"),
            ChandelierType = -1, // Size mismatch
            ClockType = GetTileType("WulfrumClock"),
            DresserType = GetTileType("WulfrumDresser"),
            LampType = GetTileType("WulfrumLamp"),
            LanternType = -1, // Size mismatch
            PianoType = GetTileType("WulfrumPiano"),
            SinkType = GetTileType("WulfrumSink"),
            SofaType = GetTileType("WulfrumSofa"),
            ToiletType = -1 // Size mismatch
        };
        int ingredientType = calamityMod.Find<ModItem>("WulfrumPlating").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "WulfrumFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/WulfrumFurnitureSolution",
            (int)DustID.Tungsten,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
