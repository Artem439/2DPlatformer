using Game.Scripts.Entities.Player;

namespace Game.Scripts.Entities.Base
{
    public interface ICollectable
    {
        void Collect(Collector collector);
    }
}