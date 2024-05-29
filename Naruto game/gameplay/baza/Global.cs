using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Naruto_game.gameplay.baza
{
    public class Global
    {
        public static ContentManager Content { get; set; }
        public static SpriteBatch SpriteBatch { get; set; }
        public static GameTime GameTime;
        public static MouseState MouseState { get; set; }
        public static MouseState LastMouseState { get; set; }
        public static bool Clicked { get; set; }
        public static Rectangle MouseCursor { get; set; }

        public static void Update()
        {
            LastMouseState = MouseState;
            MouseState = Mouse.GetState();

            Clicked = MouseState.LeftButton == ButtonState.Pressed && LastMouseState.LeftButton == ButtonState.Released;
            MouseCursor = new(MouseState.Position, new(1, 1));
        }
    }
}
