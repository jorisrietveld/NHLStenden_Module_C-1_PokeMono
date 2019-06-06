using System.Collections.Generic;
using PokeMono.source.GameElement;

namespace PokeMono.source.Pokemons
{
    public class PlantPokemonFactory : GameEntityFactory
    {
        public override IGameEntity CreateEntity(IList<IGameComponent> components)
        {
            return new Pokemon(components);
        }
    }
}