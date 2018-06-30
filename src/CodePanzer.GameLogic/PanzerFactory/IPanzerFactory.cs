using CodePanzer.Abstractions.Map;
using CodePanzer.Abstractions.Panzer;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal interface IPanzerFactory
    {
        IPanzer GetPanzer(IMap map, IPanzerCommander panzer);
    }
}