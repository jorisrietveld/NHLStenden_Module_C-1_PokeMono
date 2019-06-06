using System.Collections.Generic;
using PokeMono.source.GameElement;

namespace PokeMono.source.Pokemons
{
    public class WaterPokemonFactory : GameEntityFactory
    {
        public override IGameEntity CreateEntity(IList<IGameComponent> components)
        {
            return new Pokemon(components);
        }
    }
}