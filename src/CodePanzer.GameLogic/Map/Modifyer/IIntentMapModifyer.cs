using CodePanzer.Abstractions.Map;

namespace CodePanzer.GameLogic.Map.Modifyer
{
    internal interface IIntentMapModifyer
    {
        void Modify(IPanzer panzer);
    }
}