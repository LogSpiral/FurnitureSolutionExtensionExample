using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class EutrophicFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("SmoothNavystone"),
            WallType = calamityMod.Find<ModWall>("SmoothNavystoneWall").Type,
            PlatformType = GetTileType("EutrophicPlatform"),
            WorkbenchType = GetTileType("EutrophicWorkBench"),
            TableType = GetTileType("EutrophicTable"),
            ChairType = GetTileType("EutrophicChair"),
            ClosedDoorType = GetTileType("EutrophicDoorClosed"),
            OpenDoorType = GetTileType("EutrophicDoorOpen"),
            ChestType = GetTileType("EutrophicChest"),
            BedType = GetTileType("EutrophicBed"),
            BookcaseType = GetTileType("EutrophicBookcase"),
            BathtubType = GetTileType("EutrophicBathtub"),
            CandelabraType = GetTileType("EutrophicCandelabra"),
            CandleType = GetTileType("EutrophicCandle"),
            ChandelierType = GetTileType("EutrophicChandelier"),
            ClockType = GetTileType("EutrophicClock"),
            DresserType = GetTileType("EutrophicDresser"),
            LampType = GetTileType("EutrophicLamp"),
            LanternType = GetTileType("EutrophicLantern"),
            PianoType = GetTileType("EutrophicPiano"),
            SinkType = GetTileType("EutrophicSink"),
            SofaType = GetTileType("EutrophicBench"),
            ToiletType = GetTileType("EutrophicToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("SmoothNavystone").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "EutrophicFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/EutrophicFurnitureSolution",
            (int)DustID.Confetti_Green,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
