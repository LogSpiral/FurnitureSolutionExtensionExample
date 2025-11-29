using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class SacrilegiousFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("OccultBrickTile"),
            WallType = calamityMod.Find<ModWall>("OccultBrickWall").Type,
            PlatformType = GetTileType("OccultPlatformTile"),
            WorkbenchType = GetTileType("SacrilegiousWorkBenchTile"),
            TableType = GetTileType("SacrilegiousTableTile"),
            ChairType = GetTileType("SacrilegiousChairTile"),
            ClosedDoorType = GetTileType("SacrilegiousDoorClosed"),
            OpenDoorType = GetTileType("SacrilegiousDoorOpen"),
            ChestType = GetTileType("SacrilegiousChestTile"),
            BedType = GetTileType("SacrilegiousBedTile"),
            BookcaseType = GetTileType("SacrilegiousBookcaseTile"),
            BathtubType = GetTileType("SacrilegiousBathtubTile"),
            CandelabraType = GetTileType("SacrilegiousCandelabraTile"),
            CandleType = GetTileType("SacrilegiousCandleTile"),
            ChandelierType = GetTileType("SacrilegiousChandelierTile"),
            ClockType = GetTileType("SacrilegiousClockTile"),
            DresserType = GetTileType("SacrilegiousDresserTile"),
            LampType = GetTileType("SacrilegiousLampTile"),
            LanternType = GetTileType("SacrilegiousLanternTile"),
            PianoType = GetTileType("SacrilegiousPianoTile"),
            SinkType = GetTileType("SacrilegiousSinkTile"),
            SofaType = GetTileType("SacrilegiousBenchTile"),
            ToiletType = GetTileType("SacrilegiousToiletTile")
        };
        int ingredientType = calamityMod.Find<ModItem>("OccultBrickItem").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "SacrilegiousFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/SacrilegiousFurnitureSolution",
            (int)DustID.Confetti_Yellow,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
