using System;
using System.Collections.Generic;
using System.Text;

namespace PokeMono.source.GameElement
{
    public class GameEntity
    {
        private IList<IGameComponent> _gameComponents;
        
        public GameEntity(IList<IGameComponent> components)
        {
            this._gameComponents = components;
        }
    }
}
