using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.CalamityMod;

internal class CalamityFurnitureFrameDataLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod, Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("CalamityMod", out var calamityMod)) return;
        int monolithType = calamityMod.Find<ModTile>("AncientMonolith").Type;
        FurnitureFrameData monolithData = new()
        {
            UnitHeight = 90,
            UnitWidth = 1332,
            RowMode = false,
            WrapCount = -1,
            WidthTileCount = 2,
            HeightTileCount = 5,
            AnchorX = 0,
            AnchorY = 2,
            SubSylesX = 37
        };
        var dataArray = FurnitureFrameData.ToArray(monolithData);
        furnitureSolutionMod.Call("SetModFurnitureFrameData", monolithType, dataArray);
    }
}
