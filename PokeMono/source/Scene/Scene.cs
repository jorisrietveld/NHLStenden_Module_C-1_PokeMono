using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMono.source.Scene
{
    public abstract class Scene
    {
        private SpriteBatch _spriteBatch;

        public float PlankTime { get; set; } = 1f;

        // public List<GameEntity> GameEntities { get; protected set; }


        public void Draw(GameTime gameTime)
        {
        }
    }
}