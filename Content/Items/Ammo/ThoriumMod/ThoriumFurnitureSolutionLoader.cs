using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.ThoriumMod;

internal class ThoriumFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod, Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("ThoriumMod", out var thoriumMod)) return;

        int GetTileType(string name) => thoriumMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        const int style = 0;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("ThoriumBlockTile"),
            WallType = thoriumMod.Find<ModWall>("ThoriumBlockWall").Type,
            PlatformType = GetTileType("ThoriumPlatform"),
            PlatformIndex = style,
            WorkbenchType = GetTileType("FurnitureWorkbench"),
            WorkbenchIndex = style,
            TableType = GetTileType("FurnitureTable"),
            TableIndex = style,
            ChairType = GetTileType("FurnitureChair"),
            ChairIndex = style,
            ClosedDoorType = GetTileType("FurnitureDoorClosed"),
            OpenDoorType = GetTileType("FurnitureDoorOpen"),
            DoorIndex = style,
            ChestType = GetTileType("ThoriumChest"),
            ChestIndex = style,
            BedType = GetTileType("FurnitureBed"),
            BedIndex = style,
            BookcaseType = GetTileType("FurnitureBookcase"),
            BookcaseIndex = style,
            BathtubType = GetTileType("FurnitureBathtub"),
            BathtubIndex = style,
            CandelabraType = GetTileType("FurnitureCandelabra"),
            CandelabraIndex = style,
            CandleType = GetTileType("FurnitureCandle"),
            CandleIndex = style,
            ChandelierType = GetTileType("FurnitureChandelier"),
            ChandelierIndex = style,
            ClockType = GetTileType("FurnitureClock"),
            ClockIndex = style,
            DresserType = GetTileType("FurnitureDresser"),
            DresserIndex = style,
            LampType = GetTileType("FurnitureLamp"),
            LampIndex = style,
            LanternType = GetTileType("FurnitureLantern"),
            LanternIndex = style,
            PianoType = GetTileType("FurniturePiano"),
            PianoIndex = style,
            SinkType = GetTileType("FurnitureSink"),
            SinkIndex = style,
            SofaType = GetTileType("FurnitureSofa"),
            SofaIndex = style,
            ToiletType = GetTileType("FurnitureToilet"),
            ToiletIndex = style
        };
        int ingredientType = thoriumMod.Find<ModItem>("ThoriumBlock").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        var result = furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "ThoriumFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/ThoriumMod/ThoriumFurnitureSolution",
            (int)DustID.Frost,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
    }
}
