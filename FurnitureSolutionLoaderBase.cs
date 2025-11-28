using Terraria.ModLoader;

namespace FurnitureSolutionExtensionExample;

internal abstract class FurnitureSolutionLoaderBase : ILoadable
{
    void ILoadable.Load(Mod mod)
    {
        if (ModLoader.TryGetMod("FurnitureSolution", out var furnitureSolution))
            AddSolution(mod, furnitureSolution);
    }

    void ILoadable.Unload() { }

    public abstract void AddSolution(Mod mod, Mod furnitureSolutionMod);
}
