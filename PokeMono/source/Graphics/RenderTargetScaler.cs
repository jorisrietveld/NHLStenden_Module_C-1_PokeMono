using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokeMono.source.Graphics
{
    /// <summary>
    /// Used to scale the graphics on different screen/window sizes 
    /// </summary>
    public class RenderTargetScaler
    {
        private readonly RenderTarget2D _renderCanvas;
        private readonly GraphicsDeviceManager _graphicsDeviceManager;

        public readonly int _screenHeight = 1080;
        public readonly int _screenWidth = 1920;

        private readonly Game _game;
        private readonly SpriteBatch _spriteBatch;

        public RenderTargetScaler(Game game, GraphicsDeviceManager graphicsDeviceManagerManager, int width, int height)
        {
            _game = game;
            _graphicsDeviceManager = graphicsDeviceManagerManager;
            _screenWidth = width;
            _screenHeight = height;

            _spriteBatch = new SpriteBatch(graphicsDeviceManagerManager.GraphicsDevice);

            // create a surface to draw on which is then scaled to the screen size on the PC
            _renderCanvas = new RenderTarget2D(
                graphicsDeviceManagerManager.GraphicsDevice,
                width, height);
        }

        /// <summary>
        /// Used to set the render target for a certain device.
        /// </summary>
        public void SetRenderTarget()
        {
            _graphicsDeviceManager.GraphicsDevice.SetRenderTarget(_renderCanvas);
        }

        public void Draw()
        {
            float outputAspectRatio = _game.Window.ClientBounds.Width / (float) _game.Window.ClientBounds.Height;
            float preferredAspectRatio = _screenWidth / (float) _screenHeight;

            Rectangle destinationRectangle;

            // If the output ratio is smaller as our preffered one we need to draw some black bars to prevent glitches.
            if (outputAspectRatio <= preferredAspectRatio)
            {
                // The output is taller than it is wider so draw bars at the bottom and top.
                int presentHeight = (int) ((_game.Window.ClientBounds.Width / preferredAspectRatio) + 0.5f);
                int barHeight = (_game.Window.ClientBounds.Height - presentHeight) / 2;

                destinationRectangle = new Rectangle(0, barHeight, _game.Window.ClientBounds.Width, presentHeight);
            }
            else
            {
                // The output is wider than it is tall so draw bars at the left and right.
                int presentWidth = (int) ((_game.Window.ClientBounds.Height * preferredAspectRatio) + 0.5f);
                int barWidth = (_game.Window.ClientBounds.Width - presentWidth) / 2;

                destinationRectangle = new Rectangle(barWidth, 0, presentWidth, _game.Window.ClientBounds.Height);
            }

            // Remove the default/current render target.
            _graphicsDeviceManager.GraphicsDevice.SetRenderTarget(null);

            // Write black over the complete window so we get black bars around our game scene.
            _graphicsDeviceManager.GraphicsDevice.Clear(Color.Black);

            // draw a quad to get the draw buffer to the back buffer
            _spriteBatch.Begin();
            _spriteBatch.Draw(_renderCanvas, destinationRectangle, Color.White);
            _spriteBatch.End();
        }
    }
}