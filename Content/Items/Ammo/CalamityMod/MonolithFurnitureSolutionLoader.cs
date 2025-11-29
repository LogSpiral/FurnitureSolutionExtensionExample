using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class MonolithFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("AstralMonolith"),
            WallType = calamityMod.Find<ModWall>("AstralMonolithWall").Type,
            PlatformType = GetTileType("MonolithPlatform"),
            WorkbenchType = GetTileType("MonolithWorkBench"),
            TableType = GetTileType("MonolithTable"),
            ChairType = GetTileType("MonolithChair"),
            ClosedDoorType = GetTileType("MonolithDoorClosed"),
            OpenDoorType = GetTileType("MonolithDoorOpen"),
            ChestType = GetTileType("MonolithChest"),
            BedType = GetTileType("MonolithBed"),
            BookcaseType = GetTileType("MonolithBookcase"),
            BathtubType = GetTileType("MonolithBathtub"),
            CandelabraType = GetTileType("MonolithCandelabra"),
            CandleType = GetTileType("MonolithCandle"),
            ChandelierType = GetTileType("MonolithChandelier"),
            ClockType = GetTileType("MonolithClock"),
            DresserType = GetTileType("MonolithDresser"),
            LampType = GetTileType("MonolithLamp"),
            LanternType = GetTileType("MonolithLantern"),
            PianoType = GetTileType("MonolithPiano"),
            SinkType = GetTileType("MonolithSink"),
            SofaType = GetTileType("MonolithBench"),
            ToiletType = GetTileType("MonolithToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("AstralMonolith").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "MonolithFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/MonolithFurnitureSolution",
            calamityMod.Find<ModDust>("AstralBasic").Type,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
