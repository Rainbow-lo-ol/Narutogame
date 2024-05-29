using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Naruto_game.gameplay.baza;
using Naruto_game.gameplay.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naruto_game
{
    public class GameManager
    {
        MainMenu MainMenu = new();
        DeathMenu DeathMenu = new();
        Rules Rules = new();
        GamePlay GamePlay = new();

        Song MainOp;
        //Song MainMenuOp;
        //Song DeathMenuOp;

        public GameManager()
        {
            MainOp = Global.Content.Load<Song>("audio/mainOp");
            //MainMenuOp = Global.Content.Load<Song>("audio/mainMenu");
            //DeathMenuOp = Global.Content.Load<Song>("audio/deathMenu");
            MediaPlayer.Play(MainOp);
            MediaPlayer.Volume = 0.1f;
            MediaPlayer.IsRepeating = true;
        }

        public void ActionMainNewGame(object sender, EventArgs e) => MainMenu.NewGame++;
        public void ActionRules(object sender, EventArgs e) => MainMenu.Rules++;
        public void ActionMainExitGame(object sender, EventArgs e) => MainMenu.ExitGame++;
        public void ActionDeathNewGame(object sender, EventArgs e) => DeathMenu.NewGame++;
        public void ActionDeathExitGame(object sender, EventArgs e) => DeathMenu.ExitGame++;

        public void Update()
        {
            MainMenu.NewGameButton.Click += ActionMainNewGame;
            MainMenu.RulesButton.Click += ActionRules;
            MainMenu.ExitGameButton.Click += ActionMainExitGame;

            DeathMenu.NewGameButton.Click += ActionDeathNewGame;
            DeathMenu.ExitGameButton.Click += ActionDeathExitGame;

            MainMenu.Update();
            if (MainMenu.NewGame > 0 || DeathMenu.NewGame > 0)
            {
                //MediaPlayer.Play(MainOp);
                MainMenu.ExitGame = 0;
                MainMenu.Rules = 0;
                GamePlay.Update();
            }
            if (GamePlay.IsBreak)
            {
                //MediaPlayer.Play(DeathMenuOp);
                MainMenu.ExitGame = 0;
                MainMenu.Rules = 0;
                MainMenu.NewGame = 0;
                DeathMenu.Update();
            }
            if (MainMenu.Rules > 0)
            {
                MainMenu.NewGame = 0;
                MainMenu.ExitGame = 0;
                DeathMenu.ExitGame = 0;
                Rules.Update();
                if (Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Enter))
                    MainMenu.Rules = 0;
            }
        }

        public void Draw()
        {
            MainMenu.Draw();
            if (MainMenu.NewGame > 0)
                GamePlay.Draw();
            if (GamePlay.IsBreak)
                DeathMenu.Draw();
            if (MainMenu.Rules > 0 && !Microsoft.Xna.Framework.Input.Keyboard.GetState().IsKeyDown(Keys.Enter))
                Rules.Draw();
        }
    }
}
