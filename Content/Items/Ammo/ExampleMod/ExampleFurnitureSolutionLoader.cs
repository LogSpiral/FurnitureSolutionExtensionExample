using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.ExampleMod;

internal class ExampleFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("ExampleMod", out var exampleMod)) return;

        int GetTileType(string name) => exampleMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("ExampleBlock"),
            WallType = exampleMod.Find<ModWall>("ExampleWall").Type,
            PlatformType = GetTileType("ExamplePlatform"),
            WorkbenchType = GetTileType("ExampleWorkbench"),
            TableType = GetTileType("ExampleTable"),
            ChairType = GetTileType("ExampleChair"),
            ClosedDoorType = GetTileType("ExampleDoorClosed"),
            OpenDoorType = GetTileType("ExampleDoorOpen"),
            ChestType = GetTileType("ExampleChest"),
            BedType = GetTileType("ExampleBed"),
            BookcaseType = -1, // Missing furnitures use -1 instead.
            BathtubType = -1,
            CandelabraType = -1,
            CandleType = -1,
            ChandelierType = GetTileType("ExampleChandelier"),
            ClockType = GetTileType("ExampleClock"),
            DresserType = GetTileType("ExampleDresser"),
            LampType = GetTileType("ExampleLamp"),
            LanternType = -1,
            PianoType = -1,
            SinkType = GetTileType("ExampleSink"),
            SofaType = -1,
            ToiletType = GetTileType("ExampleToilet")
        };
        int ingredientType = exampleMod.Find<ModItem>("ExampleBlock").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "ExampleFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/ExampleMod/ExampleFurnitureSolution",
            exampleMod.TryFind("Sparkle", out ModDust dust) ? dust.Type : 0,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
    }
}
