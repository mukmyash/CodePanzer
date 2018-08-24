using CodePanzer.Abstractions.Map;

namespace CodePanzer.GameLogic.Map.Generator
{
    public interface IMapGenerator
    {
        IMap CreateMap(int width, int heigth, int countPanzer);
    }
}