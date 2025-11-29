using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class BotanicFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("UelibloomBrick"),
            WallType = calamityMod.Find<ModWall>("UelibloomBrickWall").Type,
            PlatformType = GetTileType("BotanicPlatform"),
            WorkbenchType = GetTileType("BotanicWorkBench"),
            TableType = GetTileType("BotanicTable"),
            ChairType = GetTileType("BotanicChair"),
            ClosedDoorType = GetTileType("BotanicDoorClosed"),
            OpenDoorType = GetTileType("BotanicDoorOpen"),
            ChestType = GetTileType("BotanicChest"),
            BedType = GetTileType("BotanicBed"),
            BookcaseType = GetTileType("BotanicBookcase"),
            BathtubType = GetTileType("BotanicBathtub"),
            CandelabraType = GetTileType("BotanicCandelabra"),
            CandleType = GetTileType("BotanicCandle"),
            ChandelierType = GetTileType("BotanicChandelier"),
            ClockType = GetTileType("BotanicClock"),
            DresserType = GetTileType("BotanicDresser"),
            LampType = GetTileType("BotanicLamp"),
            LanternType = GetTileType("BotanicLantern"),
            PianoType = GetTileType("BotanicPiano"),
            SinkType = GetTileType("BotanicSink"),
            SofaType = GetTileType("BotanicBench"),
            ToiletType = GetTileType("BotanicToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("UelibloomBrick").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "BotanicFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/BotanicFurnitureSolution",
            calamityMod.Find<ModDust>("BloomTileLeaves").Type,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
