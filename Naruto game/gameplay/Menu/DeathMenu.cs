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
    public class DeathMenu
    {
        private Basic2d DeathMenuBackground;
        private Texture2D ButtonTexture;
        private SpriteFont Font;
        public Button NewGameButton;
        public Button ExitGameButton;

        public int NewGame;
        public static int ExitGame;

        Song MainOp;

        public DeathMenu()
        {
            MainOp = Global.Content.Load<Song>("audio/mainOp");

            DeathMenuBackground = new Basic2d("2d/DeathMenuBackground",
                                     new Vector2(0, 0),
                                     new Vector2(BaseValue.DisplayWidth, BaseValue.DisplayHeight));
            ButtonTexture = Global.Content.Load<Texture2D>("2d/botton");
            Font = Global.Content.Load<SpriteFont>("fonts/Arial80");

            NewGameButton = new(ButtonTexture, Font, "New Game", new(100, 100));
            ExitGameButton = new(ButtonTexture, Font, "Exit", new(100, 200));

            NewGame = 0;
            ExitGame = 0;


            MediaPlayer.Play(MainOp);
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
        }

        public void Update()
        {

            DeathMenuBackground.Update();
            NewGameButton.Update();
            ExitGameButton.Update();
        }

        public void Draw()
        {
            DeathMenuBackground.Draw();
            NewGameButton.Draw();
            ExitGameButton.Draw();
        }
    }
}
