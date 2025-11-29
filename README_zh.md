# 如何添加一个新的溶液

你需要通过家具溶液的Call调用 `RegisterModFurnitureSolution` 函数

当然，如果你是强引用也可以用强类型版本的，本示例包内均采用Call

你需要依次提供:

你的mod的实例

家具套件的名称(不是本地化的)

溶液的贴图在你的模组中的位置

溶液使用的粒子的ID

你这套家具的信息

其中家具的信息建议复制这个模组中的FurnitureSetData.cs到你的项目中使用，记得修改名称空间

xxxType 提供的是某个分类的家具的物块ID，对于模组物块一般用`ModContent.TileType<T>()`获取

WallType 提供的是家具套件中墙壁的ID

xxxIndex 提供的是某个分类的家具的PlaceStyle，如果你的家具是分散在多个类实现的就不需要这么写

需要注意的是你的家具的规格需要和原版家具一致，不支持4格高的门或者两个物块宽的椅子

一个示例如下
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

# 救命！我的家具在帧排版上和原版的不一样

比如瑟银的椅子是以**36x38**为单位的，而原版是**36x40**

这个时候我们就需要自己注册自己椅子物块的帧信息

建议复制这个模组的FurnitureFrameData.cs到你的项目中使用

其中

 - **UnitWidth** 指帧图上不同套件互相区分的单元格宽度

 - **UnitHeight** 指帧图上不同套件互相区分的单元格高度

 - **RowMode** 指不同套件在帧上是横向排版还是纵向排版

 - **WrapCount** 指一行(列)有多少元素之后换到了下一行(列)，不换行用-1

 - **WidthTileCount** 指这个家具的物块宽度数，同种类的需要和原版的保持一致不然炸

 - **HeightTileCount** 指这个家具的物块高度数，同种类的需要和原版的保持一致不然炸

 - **AnchorX** 指溶液转化家具的锚点物块X偏移，建议和原版的保持一致

 - **AnchorY** 指溶液转化家具的锚点物块Y偏移，建议和原版的保持一致

 - **SubSylesX** 指家具在单元格内横向的样式数，比如椅子有两个朝向所以是2，默认0，和1等效

 原版的物块帧信息参考家具溶液中的代码 **Furniture/Solutions/Core/FurnitureFrameData.cs**

 上文提到的解决瑟银椅子问题的代码如下
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
