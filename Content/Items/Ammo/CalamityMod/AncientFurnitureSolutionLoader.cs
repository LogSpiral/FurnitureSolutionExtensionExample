using System;
using Terraria;
using Terraria.ModLoader;
namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class AncientFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod, Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;

        int GetTileType(string name) => calamityMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("BrimstoneSlag"),
            WallType = calamityMod.Find<ModWall>("BrimstoneSlagWall").Type,
            PlatformType = GetTileType("AncientPlatform"),
            WorkbenchType = GetTileType("AncientWorkbench"),
            TableType = GetTileType("AncientTable"),
            ChairType = GetTileType("AncientChair"),
            ClosedDoorType = GetTileType("AncientDoorClosed"),
            OpenDoorType = GetTileType("AncientDoorOpen"),
            ChestType = GetTileType("AncientChest"),
            BedType = GetTileType("AncientBed"),
            BookcaseType = GetTileType("AncientBookcase"),
            BathtubType = GetTileType("AncientBathtub"),
            CandelabraType = GetTileType("AncientCandelabra"),
            CandleType = GetTileType("AncientCandle"),
            ChandelierType = GetTileType("AncientChandelier"),
            ClockType = GetTileType("AncientMonolith"),
            DresserType = GetTileType("AncientDresser"),
            LampType = GetTileType("AncientLamp"),
            LanternType = GetTileType("AncientLantern"),
            PianoType = -1, //Size mismatch
            SinkType = GetTileType("AncientSink"),
            SofaType = GetTileType("AncientSofa"),
            ToiletType = GetTileType("AncientToilet")
        };
        int ingredientType = calamityMod.Find<ModItem>("BrimstoneSlag").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "AncientFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/CalamityMod/AncientFurnitureSolution",
            calamityMod.TryFind("BrimstoneFlame", out ModDust dust) ? dust.Type : 0,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
    }
}
