using System.Collections.Generic;

namespace PokeMono.source.GameElement
{
    public abstract class GameEntityFactory
    {
        public IGameEntity Create(IList<IGameComponent> components)
        {
            IGameEntity pizza = CreatePizza(components);
            return pizza;
        }
        public abstract IGameEntity CreatePizza(IList<IGameComponent> components);
    }

    public class FirePokemonFactory : GameEntityFactory
    {
        public override IGameEntity CreatePizza(IList<IGameComponent> components)
        {
            //This is tied to a specific pizza implementation
            return new Pokemon(components);
        }
    }
    public class WaterPokemonFactory : GameEntityFactory
    {
        public override IGameEntity CreatePizza(IList<IGameComponent> components)
        {
            //This is tied to a specific pizza implementation
            return new Pokemon(components);
        }
    }
    public class PlantPokemonFactory : GameEntityFactory
    {
        public override IGameEntity CreatePizza(IList<IGameComponent> components)
        {
            //This is tied to a specific pizza implementation
            return new Pokemon(components);
        }
    }
}