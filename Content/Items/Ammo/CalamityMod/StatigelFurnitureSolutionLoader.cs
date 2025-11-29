using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class StatigelFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("StatigelBlock"),
            WallType = calamityMod.Find<ModWall>("StatigelWall").Type,
            PlatformType = GetTileType("StatigelPlatform"),
            WorkbenchType = GetTileType("StatigelWorkbench"),
            TableType = GetTileType("StatigelTable"),
            ChairType = GetTileType("StatigelChair"),
            ClosedDoorType = GetTileType("StatigelDoorClosed"),
            OpenDoorType = GetTileType("StatigelDoorOpen"),
            ChestType = GetTileType("StatigelChest"),
            BedType = GetTileType("StatigelBed"),
            BookcaseType = GetTileType("StatigelBookcase"),
            BathtubType = GetTileType("StatigelBath"),
            CandelabraType = GetTileType("StatigelCandelabra"),
            CandleType = GetTileType("StatigelCandle"),
            ChandelierType = GetTileType("StatigelChandelier"),
            ClockType = GetTileType("StatigelClock"),
            DresserType = GetTileType("StatigelDresser"),
            LampType = GetTileType("StatigelLamp"),
            LanternType = GetTileType("StatigelLantern"),
            PianoType = GetTileType("StatigelPiano"),
            SinkType = GetTileType("StatigelSink"),
            SofaType = GetTileType("StatigelSofa"),
            ToiletType = GetTileType("StatigelToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("StatigelBlock").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "StatigelFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/StatigelFurnitureSolution",
            (int)DustID.PinkSlime,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
