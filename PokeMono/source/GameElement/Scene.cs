using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using PokeMono.source.GameScene;

namespace PokeMono.source.GameElement
{
    public abstract class Scene
    {

        private SpriteBatch _spriteBatch;

        public float PlankTime { get; set; } = 1f;

       // public List<GameEntity> GameEntities { get; protected set; }

    }
}
