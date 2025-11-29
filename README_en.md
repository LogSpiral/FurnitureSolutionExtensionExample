# How to add a new Furniture Solution

You will need to call FurnitureSolution's `RegisterModFurnitureSolution` method by Call

You can use the method directly if you have the assembly,

In this example, we uses mod's Call() Method all the time.

You need to privide:

The instance of your mod

The name of your furniture set (Not Localized name)

The path of the solution's icon in your mod

The ID of the dust used by the solution

The Information of your furniture set

I'd advice that copy the file FurnitureSetData.cs in this mod and use it in your own project

remember to modify the namespace

xxxType  Provides the tile id of the furniture, usually we use `ModContent.TileType<T>()` for mod tiles

WallType Provides the wall id of the furniture set.

xxxIndex Provides the furniture's PlaceStyle, if your furniture uses different classes like calamity, then you don't need it.

You should notice that the scale of your furniture SHOULDN'T Different from vanilla's

Which means that this mod NOT SUPPORT 4 Tiles height Door.

An example as followed
```csharp
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample.Content.Items.Ammo.ThoriumMod;

internal class ShootingStarFurnitureSolutionLoader : FurnitureSolutionLoaderBase
{
    public override void AddSolution(Mod mod, Mod furnitureSolutionMod)
    {
        if (!ModLoader.TryGetMod("ThoriumMod", out var thoriumMod)) return;

        int GetTileType(string name) => thoriumMod.TryFind<ModTile>(name, out var tile) ? tile.Type : -1;
        const int style = 18;
        var data = new FurnitureSetData()
        {
            SolidTileType = GetTileType("ShootingStarBrick"),
            WallType = thoriumMod.Find<ModWall>("ShootingStarBrickWall").Type,
            PlatformType = GetTileType("ShootingStarPlatform"),
            PlatformIndex = 0,
            WorkbenchType = GetTileType("FurnitureWorkbench"),
            WorkbenchIndex = style,
            TableType = GetTileType("FurnitureTable"),
            TableIndex = style,
            ChairType = GetTileType("FurnitureChair"),
            ChairIndex = style,
            ClosedDoorType = GetTileType("FurnitureDoorClosed"),
            OpenDoorType = GetTileType("FurnitureDoorOpen"),
            DoorIndex = style,
            ChestType = GetTileType("ShootingStarChest"),
            ChestIndex = 0,
            BedType = GetTileType("FurnitureBed"),
            BedIndex = style,
            BookcaseType = GetTileType("FurnitureBookcase"),
            BookcaseIndex = style,
            BathtubType = GetTileType("FurnitureBathtub"),
            BathtubIndex = style,
            CandelabraType = GetTileType("FurnitureCandelabra"),
            CandelabraIndex = style,
            CandleType = GetTileType("FurnitureCandle"),
            CandleIndex = style,
            ChandelierType = GetTileType("FurnitureChandelier"),
            ChandelierIndex = style,
            ClockType = GetTileType("FurnitureClock"),
            ClockIndex = style,
            DresserType = GetTileType("FurnitureDresser"),
            DresserIndex = style,
            LampType = GetTileType("FurnitureLamp"),
            LampIndex = style,
            LanternType = GetTileType("FurnitureLantern"),
            LanternIndex = style,
            PianoType = GetTileType("FurniturePiano"),
            PianoIndex = style,
            SinkType = GetTileType("FurnitureSink"),
            SinkIndex = style,
            SofaType = GetTileType("FurnitureSofa"),
            SofaIndex = style,
            ToiletType = GetTileType("FurnitureToilet"),
            ToiletIndex = style
        };
        int ingredientType = thoriumMod.Find<ModItem>("ShootingStarBrick").Type;
        Action<Recipe> setRecipeContent = recipe => FurnitureSolutionExtensionExample.SimpleRecipe(recipe, ingredientType);
        var result = furnitureSolutionMod.Call(
            "RegisterModFurnitureSolution",
            mod,
            "ShootingStarFurniture",
            "FurnitureSolutionExtensionExample/Content/Items/Ammo/ThoriumMod/ShootingStarFurnitureSolution",
            (int)DustID.Firework_Red,
            setRecipeContent,
            FurnitureSetData.ToArray(data)
            );
    }
}

```

# Help! The Frame layout in my mod is different from vanilla

For example, Chair in Thorium has the unit of **36x38** in Texture,
while vanilla chair is **36x40**

We need to register the frame data of our own tiles.

I'd advice that copy the file FurnitureFrameData.cs in this mod and use it in your own project

In that structure

 - **UnitWidth** Means the width of the unit of one type of furniture in Texture

 - **UnitHeight** Means the height of the unit of one type of furniture in Texture

 - **RowMode** Means whether different furniture sets is layout by row or column

 - **WrapCount** Means the count needed to switch to next row(column) in a single row(column),

 - **WidthTileCount** Means the furniture's width tile count, should be equal with vanilla

 - **HeightTileCount** Means the furniture's height tile count, should be equal with vanilla

 - **AnchorX** Means the X offset of the anchor tile of furniture, advice to be equal with vanilla

 - **AnchorY** Means the Y offset of the anchor tile of furniture, advice to be equal with vanilla

 - **SubSylesX** Means the styles in single unit, like chair has two directions so the number is 2, default is 0 and has equal effect with 1

Vanilla furniture's frame datas are in FurnitureSolution's code **FurnitureSolutions/Core/FurnitureFrameData.cs**

The code fix that chair issue as followed

```csharp
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
```
