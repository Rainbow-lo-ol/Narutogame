using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Naruto_game.gameplay.baza;

namespace Naruto_game
{
    public class GamePlay
    {
        public Basic2d Background;
        public SpriteFont Font;
        public KeyboardState CurrentKeyboardState;
        public KeyboardState PreviousKeyboardState;
        public static string InputText = "";

        Battle1 Battle1;
        Battle2 Battle2;
        Battle3 Battle3;
        Battle4 Battle4;
        Battle5 Battle5;
        Battle6 Battle6;

        public static bool IsBreak = false;
        public static bool IsBattle1;
        public static bool IsBattle2;
        public static bool IsBattle3;
        public static bool IsBattle4;
        public static bool IsBattle5;
        public static bool IsBattle6;

        int DisplayWidth = BaseValue.DisplayWidth;
        int DisplayHeight = BaseValue.DisplayHeight;

        public GamePlay()
        {
            Background = new Basic2d("2d/background",
                                     new Vector2(0, 0),
                                     new Vector2(DisplayWidth, DisplayHeight));
            
            Font = Global.Content.Load<SpriteFont>("fonts/Arial90");
            
            Battle1 = new Battle1();
            Battle2 = new Battle2();
            Battle3 = new Battle3();
            Battle4 = new Battle4();
            Battle5 = new Battle5();
            Battle6 = new Battle6();
        } 

        public void Update () 
        {
            Background.Update();

            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();

            if (CurrentKeyboardState.GetPressedKeys().Length > 0
                && PreviousKeyboardState.GetPressedKeys().Length == 0
                && InputText.Length != 4)
            {
                Keys key = CurrentKeyboardState.GetPressedKeys()[0];
                if (key >= Keys.A && key <= Keys.Z)
                    InputText += (char)key;
            }

            if (IsBattle1)
            {
                Battle1.Update();
                Battle1.InputTimer.Start();
            }

            if (!IsBattle1 && IsBattle2)
            {
                Battle2.Update();
                Battle2.InputTimer.Start();
            }

            if (!IsBattle2 && IsBattle3)
            {
                Battle3.Update();
                Battle3.InputTimer.Start();
            }

            if (!IsBattle3 && IsBattle4)
            {
                Battle4.Update();
                Battle4.InputTimer.Start();
            }

            if (!IsBattle4 && IsBattle5)
            {
                Battle5.Update();
                Battle5.InputTimer.Start();
            }

            if (!IsBattle5 && IsBattle6)
            {
                Battle6.Update();
                Battle6.InputTimer.Start();
            }

            if (IsBreak)
                MediaPlayer.Stop();
        }

        public void Draw()
        {
            Background.Draw();

            Battle1.Draw();

            if (!IsBattle1)
                Battle2.Draw();

            if (!IsBattle2)
                Battle3.Draw();

            if (!IsBattle3)
                Battle4.Draw();

            if (!IsBattle4)
                Battle5.Draw();

            if (!IsBattle5)
                Battle6.Draw();
        }
    }
}
