using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class OtherworldlyFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("OtherworldlyStone"),
            WallType = calamityMod.Find<ModWall>("OtherworldlyStoneWall").Type,
            PlatformType = GetTileType("OtherworldlyPlatform"),
            WorkbenchType = GetTileType("OtherworldlyWorkBench"),
            TableType = GetTileType("OtherworldlyTable"),
            ChairType = GetTileType("OtherworldlyChair"),
            ClosedDoorType = GetTileType("OtherworldlyDoorClosed"),
            OpenDoorType = GetTileType("OtherworldlyDoorOpen"),
            ChestType = GetTileType("OtherworldlyChest"),
            BedType = GetTileType("OtherworldlyBed"),
            BookcaseType = GetTileType("OtherworldlyBookcase"),
            BathtubType = GetTileType("OtherworldlyBathtub"),
            CandelabraType = GetTileType("OtherworldlyCandelabra"),
            CandleType = GetTileType("OtherworldlyCandle"),
            ChandelierType = GetTileType("OtherworldlyChandelier"),
            ClockType = GetTileType("OtherworldlyClock"),
            DresserType = GetTileType("OtherworldlyDresser"),
            LampType = GetTileType("OtherworldlyLamp"),
            LanternType = GetTileType("OtherworldlyLantern"),
            PianoType = GetTileType("OtherworldlyPiano"),
            SinkType = GetTileType("OtherworldlySink"),
            SofaType = GetTileType("OtherworldlySofa"),
            ToiletType = GetTileType("OtherworldlyToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("OtherworldlyStone").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "OtherworldlyFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/OtherworldlyFurnitureSolution",
            calamityMod.TryFind("OtherworldlyTileCloth", out ModDust dust) ? dust.Type : 0,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
