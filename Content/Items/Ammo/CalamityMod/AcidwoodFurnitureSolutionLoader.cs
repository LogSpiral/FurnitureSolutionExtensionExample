using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class AcidwoodFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("AcidwoodTile"),
            WallType = calamityMod.Find<ModWall>("AcidwoodWall").Type,
            PlatformType = GetTileType("AcidwoodPlatformTile"),
            WorkbenchType = GetTileType("AcidwoodWorkbenchTile"),
            TableType = GetTileType("AcidwoodTableTile"),
            ChairType = -1, // Size mismatch
            ClosedDoorType = GetTileType("AcidwoodDoorClosed"),
            OpenDoorType = GetTileType("AcidwoodDoorOpen"),
            ChestType = GetTileType("AcidwoodChestTile"),
            BedType = GetTileType("AcidwoodBedTile"),
            BookcaseType = GetTileType("AcidwoodBookcaseTile"),
            BathtubType = GetTileType("AcidwoodBathTile"),
            CandelabraType = GetTileType("AcidwoodCandelabraTile"),
            CandleType = GetTileType("AcidwoodCandleTile"),
            ChandelierType = GetTileType("AcidwoodChandelierTile"),
            ClockType = GetTileType("AcidwoodClockTile"),
            DresserType = GetTileType("AcidwoodDresserTile"),
            LampType = GetTileType("AcidwoodLampTile"),
            LanternType = GetTileType("AcidwoodLanternTile"),
            PianoType = GetTileType("AcidwoodPianoTile"),
            SinkType = GetTileType("AcidwoodSinkTile"),
            SofaType = GetTileType("AcidwoodBenchTile"),
            ToiletType = GetTileType("AcidwoodToiletTile")
        };
        int ingredientType = calamityMod.Find<ModItem>("Acidwood").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "AcidwoodFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/AcidwoodFurnitureSolution",
            (int)DustID.PalmWood,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
