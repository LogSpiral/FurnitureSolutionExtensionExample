using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class AbyssFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("SmoothAbyssGravel"),
            WallType = calamityMod.Find<ModWall>("AbyssGravelWallSafe").Type,
            PlatformType = GetTileType("SmoothAbyssGravelPlatform"),
            WorkbenchType = GetTileType("AbyssWorkbench"),
            TableType = GetTileType("AbyssTable"),
            ChairType = GetTileType("AbyssChair"),
            ClosedDoorType = GetTileType("AbyssDoorClosed"),
            OpenDoorType = GetTileType("AbyssDoorOpen"),
            ChestType = GetTileType("AbyssChest"),
            BedType = GetTileType("AbyssBed"),
            BookcaseType = GetTileType("AbyssBookcase"),
            BathtubType = GetTileType("AbyssBathtub"),
            CandelabraType = GetTileType("AbyssCandelabra"),
            CandleType = GetTileType("AbyssCandle"),
            ChandelierType = GetTileType("AbyssChandelier"),
            ClockType = GetTileType("AbyssClock"),
            DresserType = GetTileType("AbyssDresser"),
            LampType = GetTileType("AbyssLamp"),
            LanternType = GetTileType("AbyssLantern"),
            PianoType = GetTileType("AbyssPiano"),
            SinkType = GetTileType("AbyssSink"),
            SofaType = GetTileType("AbyssSofa"),
            ToiletType = GetTileType("AbyssToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("SmoothAbyssGravel").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "AbyssFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/AbyssFurnitureSolution",
            (int)DustID.WaterCandle,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
