#region Using Statements

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PokeMono.source.GameElement;
using PokeMono.source.Graphics;
using PokeMono.source.Player;

#endregion

namespace PokeMono
{
    /// <summary>
    ///     Used in the scene switch to load different scenes in the game.
    /// </summary>
    public enum GameState
    {
        Intro,
        MainMenu,
        PokemonSelect,
        Battle,
        Score
    }

    /// <summary>
    ///     This is the main type for your game.
    /// </summary>
    public class PokeMonoGame : Game
    {
        public static PokeMonoGame Instance;
        public static int ScreenHeight = 1080;
        public static int ScreenWidth = 1920;

        private readonly GraphicsDeviceManager _graphicsDevice;
        private Scene _currentScene;
        private RenderTargetScaler _renderTargetScaler;


        public PokeMonoGame()
        {
            Instance = this;
            _graphicsDevice = new GraphicsDeviceManager(this);
            _graphicsDevice.PreferredBackBufferHeight = ScreenHeight;
            _graphicsDevice.PreferredBackBufferWidth = ScreenHeight;
            _graphicsDevice.IsFullScreen = true;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        ///     Allows the game to perform any initialization it needs to before starting to run.
        ///     This is where it can query for any required services and load any non-graphic
        ///     related content.  Calling base.Initialize will enumerate through any components
        ///     and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _renderTargetScaler = new RenderTargetScaler(this, _graphicsDevice, ScreenWidth, ScreenHeight);

            this.SetState(GameState.Intro);
            base.Initialize();
        }

        /// <summary>
        ///     LoadContent will be called once per game and is the place to load
        ///     all of your content.
        ///     Currently not used because each scene will loads its own assets.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            //TODO: use this.Content to load your game content here 
        }

        /// <summary>
        ///     Allows the game to run logic such as updating the world,
        ///     gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
#endif
            InputManager.Update();
            base.Update(gameTime);
        }

        /// <summary>
        ///     This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}