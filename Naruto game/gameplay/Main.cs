using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Naruto_game.gameplay.baza;

namespace Naruto_game
{
    public class Main : Game
    {
        private GraphicsDeviceManager Graphics;
        SpriteBatch SpriteBatch;
        GameManager GameManager;
        
        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
                     
        }

        protected override void Initialize()
        {
            Graphics.PreferredBackBufferWidth = BaseValue.DisplayWidth;
            Graphics.PreferredBackBufferHeight = BaseValue.DisplayHeight;
            Graphics.IsFullScreen = true;
            Graphics.ApplyChanges();
            IsMouseVisible = true; 
            base.Initialize();
        }
         
        protected override void LoadContent()
        {
            Global.Content = this.Content;
            Global.SpriteBatch = new SpriteBatch(GraphicsDevice);
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            GameManager = new GameManager();
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed 
                || Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Escape)
                || MainMenu.ExitGame != 0 || DeathMenu.ExitGame != 0)
                Exit();

            Global.GameTime = gameTime;
            GameManager.Update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GameManager.Draw();

            base.Draw(gameTime);
        }

    }  

    public static class Program
    {
        static void Main()
        {
            using var game = new Main();
            game.Run();
        }
    }
}
