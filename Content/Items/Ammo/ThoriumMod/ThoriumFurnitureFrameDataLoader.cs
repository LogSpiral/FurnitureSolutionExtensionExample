using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.ThoriumMod;

internal class ThoriumFurnitureFrameDataLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod, Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("ThoriumMod", out var thoriumMod)) return;
        int chair = thoriumMod.Find<ModTile>("FurnitureChair").Type;
        int toilet = thoriumMod.Find<ModTile>("FurnitureToilet").Type;
        FurnitureFrameData chairData = new()
        {
            UnitHeight = 38,
            UnitWidth = 36,
            RowMode = false,
            WrapCount = -1,
            WidthTileCount = 1,
            HeightTileCount = 2,
            AnchorX = -1,
            AnchorY = 0
        };
        var dataArray = FurnitureFrameData.ToArray(chairData);
        furnitureSolutionMod.Call("SetModFurnitureFrameData", chair, dataArray);
        furnitureSolutionMod.Call("SetModFurnitureFrameData", toilet, dataArray);

    }
}
