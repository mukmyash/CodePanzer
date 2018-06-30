using CodePanzer.Abstractions.Panzer;

namespace CodePanzer.GameLogic.PanzerFactory
{
    internal interface IPanzerBuilderFactory
    {
        PanzerBuilder GetBuilder(IPanzerCommander panzer);
    }
}