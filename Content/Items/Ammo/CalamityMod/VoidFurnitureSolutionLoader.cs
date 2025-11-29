using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class VoidFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("SmoothVoidstone"),
            WallType = calamityMod.Find<ModWall>("SmoothVoidstoneWall").Type,
            PlatformType = GetTileType("SmoothVoidstonePlatform"),
            WorkbenchType = GetTileType("VoidWorkbench"),
            TableType = GetTileType("VoidTable"),
            ChairType = GetTileType("VoidChair"),
            ClosedDoorType = GetTileType("VoidDoorClosed"),
            OpenDoorType = GetTileType("VoidDoorOpen"),
            ChestType = GetTileType("VoidChest"),
            BedType = GetTileType("VoidBed"),
            BookcaseType = GetTileType("VoidBookcase"),
            BathtubType = GetTileType("VoidBathtub"),
            CandelabraType = GetTileType("VoidCandelabra"),
            CandleType = GetTileType("VoidCandle"),
            ChandelierType = GetTileType("VoidChandelier"),
            ClockType = GetTileType("VoidClock"),
            DresserType = GetTileType("VoidDresser"),
            LampType = GetTileType("VoidLamp"),
            LanternType = GetTileType("VoidLantern"),
            PianoType = GetTileType("VoidPiano"),
            SinkType = GetTileType("VoidSink"),
            SofaType = GetTileType("VoidSofa"),
            ToiletType = GetTileType("VoidToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("SmoothVoidstone").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "VoidFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/VoidFurnitureSolution",
            (int)DustID.DarkCelestial,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
