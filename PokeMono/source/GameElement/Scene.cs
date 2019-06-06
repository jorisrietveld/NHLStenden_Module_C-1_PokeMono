using Microsoft.Xna.Framework.Graphics;

namespace PokeMono.source.GameElement
{
    public abstract class Scene
    {
        private SpriteBatch _spriteBatch;

        public float PlankTime { get; set; } = 1f;

        // public List<GameEntity> GameEntities { get; protected set; }
    }
}