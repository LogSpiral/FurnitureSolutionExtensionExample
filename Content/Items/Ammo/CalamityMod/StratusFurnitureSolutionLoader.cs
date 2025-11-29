using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class StratusFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("StratusBricks"),
            WallType = calamityMod.Find<ModWall>("StratusWall").Type,
            PlatformType = GetTileType("StratusPlatform"),
            WorkbenchType = GetTileType("StratusWorkbench"),
            TableType = GetTileType("StratusTable"),
            ChairType = GetTileType("StratusChair"),
            ClosedDoorType = GetTileType("StratusDoorClosed"),
            OpenDoorType = GetTileType("StratusDoorOpen"),
            ChestType = GetTileType("StratusChest"),
            BedType = GetTileType("StratusBed"),
            BookcaseType = GetTileType("StratusBookcase"),
            BathtubType = GetTileType("StratusBathtub"),
            CandelabraType = GetTileType("StratusCandelabra"),
            CandleType = GetTileType("StratusCandle"),
            ChandelierType = GetTileType("StratusChandelier"),
            ClockType = GetTileType("StratusClock"),
            DresserType = GetTileType("StratusDresser"),
            LampType = GetTileType("StratusLamp"),
            LanternType = GetTileType("StratusLantern"),
            PianoType = GetTileType("StratusPiano"),
            SinkType = GetTileType("StratusSink"),
            SofaType = GetTileType("StratusSofa"),
            ToiletType = GetTileType("StratusToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("StratusBricks").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "StratusFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/StratusFurnitureSolution",
            (int)DustID.FrostStaff,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
