namespace FurnitureSolutionExtensionExample;

internal struct FurnitureSetData
{
    internal int SolidTileType { get; set; }

    internal int WallType { get; set; }

    internal int PlatformType { get; set; }

    internal int WorkbenchType { get; set; }

    internal int TableType { get; set; }

    internal int ChairType { get; set; }

    internal int ClosedDoorType { get; set; }

    internal int OpenDoorType { get; set; }

    internal int ChestType { get; set; }

    internal int BedType { get; set; }

    internal int BookcaseType { get; set; }

    internal int BathtubType { get; set; }

    internal int CandelabraType { get; set; }

    internal int CandleType { get; set; }

    internal int ChandelierType { get; set; }

    internal int ClockType { get; set; }

    internal int DresserType { get; set; }

    internal int LampType { get; set; }

    internal int LanternType { get; set; }

    internal int PianoType { get; set; }

    internal int SinkType { get; set; }

    internal int SofaType { get; set; }

    internal int ToiletType { get; set; }

    internal int PlatformIndex { get; set; }

    internal int WorkbenchIndex { get; set; }

    internal int TableIndex { get; set; }

    internal int ChairIndex { get; set; }

    internal int DoorIndex { get; set; }

    internal int ChestIndex { get; set; }

    internal int BedIndex { get; set; }

    internal int BookcaseIndex { get; set; }

    internal int BathtubIndex { get; set; }

    internal int CandelabraIndex { get; set; }

    internal int CandleIndex { get; set; }

    internal int ChandelierIndex { get; set; }

    internal int ClockIndex { get; set; }

    internal int DresserIndex { get; set; }

    internal int LampIndex { get; set; }

    internal int LanternIndex { get; set; }

    internal int PianoIndex { get; set; }

    internal int SinkIndex { get; set; }

    internal int SofaIndex { get; set; }

    internal int ToiletIndex { get; set; }

    internal static object[] ToArray(in FurnitureSetData data)
    {
        return [
                data.SolidTileType,
                data.WallType,
                (data.PlatformType,data.PlatformIndex),
                (data.WorkbenchType,data.WorkbenchIndex),
                (data.TableType,data.TableIndex),
                (data.ChairType,data.ChairIndex),
                (data.ClosedDoorType,data.OpenDoorType,data.DoorIndex),
                (data.ChestType,data.ChestIndex),
                (data.BedType,data.BedIndex),
                (data.BookcaseType,data.BookcaseIndex),
                (data.BathtubType,data.BathtubIndex),
                (data.CandelabraType,data.CandelabraIndex),
                (data.CandleType,data.CandleIndex),
                (data.ChandelierType,data.ChandelierIndex),
                (data.ClockType,data.ClockIndex),
                (data.DresserType,data.DresserIndex),
                (data.LampType,data.LampIndex),
                (data.LanternType,data.LanternIndex),
                (data.PianoType,data.PianoIndex),
                (data.SinkType,data.SinkIndex),
                (data.SofaType,data.SofaIndex),
                (data.ToiletType,data.ToiletIndex)
            ];
    }
}