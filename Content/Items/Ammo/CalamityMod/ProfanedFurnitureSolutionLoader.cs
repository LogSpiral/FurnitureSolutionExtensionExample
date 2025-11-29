using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class ProfanedFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("ProfanedRock"),
            WallType = calamityMod.Find<ModWall>("ProfanedRockWall").Type,
            PlatformType = GetTileType("ProfanedPlatform"),
            WorkbenchType = GetTileType("ProfanedWorkbench"),
            TableType = GetTileType("ProfanedTable"),
            ChairType = GetTileType("ProfanedChair"),
            ClosedDoorType = GetTileType("ProfanedDoorClosed"),
            OpenDoorType = GetTileType("ProfanedDoorOpen"),
            ChestType = GetTileType("ProfanedChest"),
            BedType = GetTileType("ProfanedBed"),
            BookcaseType = GetTileType("ProfanedBookcase"),
            BathtubType = GetTileType("ProfanedBath"),
            CandelabraType = GetTileType("ProfanedCandelabra"),
            CandleType = GetTileType("ProfanedCandle"),
            ChandelierType = GetTileType("ProfanedChandelier"),
            ClockType = GetTileType("ProfanedClock"),
            DresserType = GetTileType("ProfanedDresser"),
            LampType = GetTileType("ProfanedLamp"),
            LanternType = GetTileType("ProfanedLantern"),
            PianoType = -1, // Size mismatch
            SinkType = GetTileType("ProfanedSink"),
            SofaType = GetTileType("ProfanedBench"),
            ToiletType = GetTileType("ProfanedToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("ProfanedRock").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "ProfanedFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/ProfanedFurnitureSolution",
            calamityMod.Find<ModDust>("ProfanedTileRock").Type,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
