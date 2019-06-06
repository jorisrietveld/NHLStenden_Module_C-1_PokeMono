using System.Collections.Generic;
using Microsoft.Xna.Framework;
using PokeMono.source.GameElement;
using IGameComponent = PokeMono.source.GameElement.IGameComponent;

namespace PokeMono.source.Pokemons
{
    public class Pokemon : GameEntity, IGameEntity
    {
        public Pokemon(IList<IGameComponent> components) : base(components)
        {
            
        }
    }
}