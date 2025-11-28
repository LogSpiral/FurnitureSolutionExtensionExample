namespace FurnitureSolutionExtensionExample;

internal struct FurnitureFrameData
{
    internal int UnitWidth { get; set; }
    internal int UnitHeight { get; set; }
    internal bool RowMode { get; set; }
    internal int WrapCount { get; set; }
    internal int WidthTileCount { get; set; }
    internal int HeightTileCount { get; set; }
    internal int AnchorX { get; set; }
    internal int AnchorY { get; set; }
    internal int SubSylesX { get; set; }
    public static object[] ToArray(in FurnitureFrameData data)
    {
        return [
            data.UnitWidth, 
            data.UnitHeight, 
            data.RowMode,
            data.WrapCount, 
            data.WidthTileCount, 
            data.HeightTileCount, 
            data.AnchorX, 
            data.AnchorY, 
            data.SubSylesX
            ];
    }
}
