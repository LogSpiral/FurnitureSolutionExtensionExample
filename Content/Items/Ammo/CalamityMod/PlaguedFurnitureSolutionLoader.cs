using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class PlaguedFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("PlaguedPlate"),
            WallType = calamityMod.Find<ModWall>("PlaguedPlateWall").Type,
            PlatformType = GetTileType("PlaguedPlatePlatform"),
            WorkbenchType = GetTileType("PlaguedPlateWorkbench"),
            TableType = GetTileType("PlaguedPlateTable"),
            ChairType = GetTileType("PlaguedPlateChair"),
            ClosedDoorType = GetTileType("PlaguedPlateDoorClosed"),
            OpenDoorType = GetTileType("PlaguedPlateDoorOpen"),
            ChestType = GetTileType("PlaguedPlateChest"),
            BedType = -1, // Size mismatch
            BookcaseType = GetTileType("PlaguedPlateBookcase"),
            BathtubType = GetTileType("PlaguedPlateBathtub"),
            CandelabraType = GetTileType("PlaguedPlateCandelabra"),
            CandleType = GetTileType("PlaguedPlateCandle"),
            ChandelierType = GetTileType("PlaguedPlateChandelier"),
            ClockType = GetTileType("PlaguedPlateClock"),
            DresserType = GetTileType("PlaguedPlateDresser"),
            LampType = GetTileType("PlaguedPlateLamp"),
            LanternType = GetTileType("PlaguedPlateLantern"),
            PianoType = GetTileType("PlaguedPlatePiano"),
            SinkType = GetTileType("PlaguedPlateSink"),
            SofaType = GetTileType("PlaguedPlateSofa"),
            ToiletType = GetTileType("PlaguedPlateToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("PlaguedPlate").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "PlaguedFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/PlaguedFurnitureSolution",
            (int)DustID.TerraBlade,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
