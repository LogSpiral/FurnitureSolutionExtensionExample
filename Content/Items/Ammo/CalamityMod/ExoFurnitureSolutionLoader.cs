using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class ExoFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("ExoPlatingTile"),
            WallType = calamityMod.Find<ModWall>("ExoPlatingWall").Type,
            PlatformType = GetTileType("ExoPlatformTile"),
            WorkbenchType = GetTileType("ExoWorkbenchTile"),
            TableType = GetTileType("ExoTableTile"),
            ChairType = -1, // Size mismatch
            ClosedDoorType = -1, // Size mismatch
            OpenDoorType = -1, // Size mismatch
            ChestType = GetTileType("ExoChestTile"),
            BedType = GetTileType("ExoBedTile"),
            BookcaseType = GetTileType("ExoBookcaseTile"),
            BathtubType = GetTileType("ExoBathtubTile"),
            CandelabraType = GetTileType("ExoCandelabraTile"),
            CandleType = GetTileType("ExoCandleTile"),
            ChandelierType = GetTileType("ExoChandelierTile"),
            ClockType = GetTileType("ExoClockTile"),
            DresserType = GetTileType("ExoDresserTile"),
            LampType = GetTileType("ExoLampTile"),
            LanternType = GetTileType("ExoLanternTile"),
            PianoType = GetTileType("ExoKeyboardTile"),
            SinkType = GetTileType("ExoSinkTile"),
            SofaType = GetTileType("ExoSofaTile"),
            ToiletType = -1 // Size mismatch
        };
        int ingredientType = calamityMod.Find<ModItem>("ExoPlating").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "ExoFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/ExoFurnitureSolution",
            (int)DustID.RainbowRod,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
