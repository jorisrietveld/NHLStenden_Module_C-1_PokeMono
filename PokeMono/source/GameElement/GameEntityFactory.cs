using System.Collections.Generic;

namespace PokeMono.source.GameElement
{
    public abstract class GameEntityFactory
    {
        public IGameEntity Create(IList<IGameComponent> components)
        {
            IGameEntity pizza = CreateEntity(components);
            return pizza;
        }
        public abstract IGameEntity CreateEntity(IList<IGameComponent> components);
    }
}