using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class CosmiliteFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod,Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("CosmiliteBrick"),
            WallType = calamityMod.Find<ModWall>("CosmiliteBrickWall").Type,
            PlatformType = GetTileType("CosmilitePlatform"),
            WorkbenchType = GetTileType("CosmiliteWorkbench"),
            TableType = GetTileType("CosmiliteTable"),
            ChairType = GetTileType("CosmiliteChair"),
            ClosedDoorType = GetTileType("CosmiliteDoorClosed"),
            OpenDoorType = GetTileType("CosmiliteDoorOpen"),
            ChestType = GetTileType("CosmiliteChest"),
            BedType = GetTileType("CosmiliteBed"),
            BookcaseType = GetTileType("CosmiliteBookcase"),
            BathtubType = GetTileType("CosmiliteBathtub"),
            CandelabraType = GetTileType("CosmiliteCandelabra"),
            CandleType = GetTileType("CosmiliteCandle"),
            ChandelierType = GetTileType("CosmiliteChandelier"),
            ClockType = GetTileType("CosmiliteClock"),
            DresserType = GetTileType("CosmiliteDresser"),
            LampType = GetTileType("CosmiliteLamp"),
            LanternType = GetTileType("CosmiliteLantern"),
            PianoType = GetTileType("CosmilitePiano"),
            SinkType = GetTileType("CosmiliteSink"),
            SofaType = GetTileType("CosmiliteSofa"),
            ToiletType = GetTileType("CosmiliteToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("CosmiliteBrick").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "CosmiliteFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/CosmiliteFurnitureSolution",
            (int)DustID.StarRoyale,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
	}
}
