using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace PokeMono.source.Player
{
    /// <summary>
    ///     Used to determine what action the user is performing.
    /// </summary>
    public struct ControlState
    {
        public bool Start;
        public bool Quit;
        public float FingerPosition;
    }

    /// <summary>
    ///     Manages what actions are registered on user input form any input device.
    /// </summary>
    public static class InputManager
    {
        private static KeyboardState _keyboardState, _lastKeyboard;
        private static GamePadState _gamePadState, _lastGamePad;
        private static ControlState _controlState;

        static InputManager()
        {
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.HorizontalDrag;
        }

        public static ControlState ControlState => _controlState;

        /// <summary>
        ///     Gets called every game-loop iteration and updates the states of input devices.
        /// </summary>
        public static void Update()
        {
            _keyboardState = Keyboard.GetState();
            _gamePadState = GamePad.GetState(PlayerIndex.One);

            _controlState.Quit = _gamePadState.Buttons.Back == ButtonState.Pressed
                                 || _keyboardState.IsKeyDown(Keys.Escape);

            _controlState.Start = _gamePadState.Buttons.B == ButtonState.Pressed
                                  || _keyboardState.IsKeyDown(Keys.Enter)
                                  || _keyboardState.IsKeyDown(Keys.Space)
                                  || _gamePadState.IsButtonDown(Buttons.Start);

            while (TouchPanel.IsGestureAvailable)
            {
                var gs = TouchPanel.ReadGesture();
                _controlState.Start |= gs.GestureType == GestureType.Tap;
                if (gs.GestureType == GestureType.HorizontalDrag) _controlState.FingerPosition = gs.Position.X;
            }

            _lastGamePad = _gamePadState;
            _lastKeyboard = _keyboardState;
        }
    }
}