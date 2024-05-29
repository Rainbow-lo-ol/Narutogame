using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Naruto_game.gameplay.baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naruto_game
{
    public class MainMenu
    {
        private Basic2d MainMenuBackground;
        private Texture2D ButtonTexture;
        private SpriteFont Font;
        public Button NewGameButton;
        public Button RulesButton;
        public Button ExitGameButton;

        public int NewGame;
        public int Rules;
        public static int ExitGame;

        //Song MainOp;

        public MainMenu()
        {
            //MainOp = Global.Content.Load<Song>("audio/mainOp");

            MainMenuBackground = new Basic2d("2d/MainMenuBackground",
                                     new Vector2(0, 0),
                                     new Vector2(BaseValue.DisplayWidth, BaseValue.DisplayHeight));
            ButtonTexture = Global.Content.Load<Texture2D>("2d/botton");
            Font = Global.Content.Load<SpriteFont>("fonts/Arial80");

            NewGameButton = new(ButtonTexture, Font, "New Game", new(100, 100));
            RulesButton = new(ButtonTexture, Font, "Rules", new(100, 200));
            ExitGameButton = new(ButtonTexture, Font, "Exit", new(100, 300));

            NewGame = 0;
            Rules = 0;
            ExitGame = 0;


            //MediaPlayer.Play(MainOp);
            //MediaPlayer.Volume = 0.1f;
            //MediaPlayer.IsRepeating = true;
        }

        public void Update()
        {

            MainMenuBackground.Update();
            NewGameButton.Update();
            RulesButton.Update();
            ExitGameButton.Update();
        }

        public void Draw()
        {
            MainMenuBackground.Draw();
            NewGameButton.Draw();
            RulesButton.Draw();
            ExitGameButton.Draw();
        }
    }
}
