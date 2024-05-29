using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Naruto_game.gameplay.baza;

namespace Naruto_game
{
    public class Battle6
    {
        public SpriteFont Font;
        public string Code;
        public Vector2 InputPosition;
        public Stopwatch InputTimer;
        public TimeSpan InputTimeout;

        public Hero Naruto;
        public Villian Sasuke;

        public HP HPHero1;
        public HP HPHero2;
        public HP HPHero3;
        public HP HPVillian1;
        public HP HPVillian2;
        public HP HPVillian3;

        public int CounterWin;
        public int CounterLoss;

        int DisplayWidth = BaseValue.DisplayWidth;
        int DisplayHeight = BaseValue.DisplayHeight;
        float XPossitionPlayer = BaseValue.XPossitionPlayer;
        float XPossitionVillian = BaseValue.XPossitionVillian;
        float YPossition = BaseValue.YPossition;
        float XDimention = BaseValue.XDimention;
        float YDimention = BaseValue.YDimention;
        float XPositionHPHero = BaseValue.XPositionHPHero;
        float XPositionHPVillian = BaseValue.XPositionHPVillian;

        SoundEffect Attac6;
        SoundEffect Attac5;
        SoundEffect Pain1;
        SoundEffect Pain3;
        SoundEffect Death;
        public Battle6()
        {
            Attac6 = Global.Content.Load<SoundEffect>("audio/attack6");
            Attac5 = Global.Content.Load<SoundEffect>("audio/attack5");
            Pain3 = Global.Content.Load<SoundEffect>("audio/pain2");
            Pain1 = Global.Content.Load<SoundEffect>("audio/pain4");
            Death = Global.Content.Load<SoundEffect>("audio/death");

            Font = Global.Content.Load<SpriteFont>("fonts/Arial90");

            InputTimer = new Stopwatch();
            InputTimeout = TimeSpan.FromSeconds(15);

            HPHero1 = new HP("2d/hp",
                                 new Vector2(XPositionHPHero, YPossition),
                                 new Vector2(70, 70));
            HPHero2 = new HP("2d/hp",
                                 new Vector2(XPositionHPHero, YPossition + 100),
                                 new Vector2(70, 70));
            HPHero3 = new HP("2d/hp",
                                 new Vector2(XPositionHPHero, YPossition + 200),
                                 new Vector2(70, 70));

            HPVillian1 = new HP("2d/hp",
                                 new Vector2(XPositionHPVillian, YPossition),
                                 new Vector2(70, 70));
            HPVillian2 = new HP("2d/hp",
                                 new Vector2(XPositionHPVillian, YPossition + 100),
                                 new Vector2(70, 70));
            HPVillian3 = new HP("2d/hp",
                                 new Vector2(XPositionHPVillian, YPossition + 200),
                                 new Vector2(70, 70));

            Naruto = new Hero("2d/Naruto",
                             new Vector2(XPossitionPlayer, YPossition),
                             new Vector2(XDimention, YDimention));

            Sasuke = new Villian("2d/Sasuke",
                              new Vector2(XPossitionVillian, YPossition),
                              new Vector2(XDimention, YDimention));

            HPHero1.Live = true;
            HPHero2.Live = true;
            HPHero3.Live = true;
            HPVillian1.Live = true;
            HPVillian2.Live = true;
            HPVillian3.Live = true;

            GamePlay.IsBattle6 = true;

            CounterWin = 0;
            CounterLoss = 0;
            
            GamePlay.InputText = "";
            Code = GenerateCode.GenerateWord();
        }

        public void Update()
        {
            if ((GamePlay.InputText != Code && GamePlay.InputText.Length == 4)
                            || InputTimer.ElapsedMilliseconds >= InputTimeout.TotalMilliseconds)
            {
                InputTimer.Restart();
                GamePlay.InputText = "";
                Code = GenerateCode.GenerateWord();
                CounterLoss++;
                if (CounterLoss == 1)
                {
                    Pain1.Play();
                    HPHero1.Live = false;
                }
                if (CounterLoss == 2)
                {
                    Pain3.Play();
                    HPHero2.Live = false;
                }
                if (CounterLoss == 3)
                {
                    HPHero3.Live = false;
                    GamePlay.IsBreak = true;
                }
            }

            if (GamePlay.InputText == Code)
            {
                InputTimer.Restart();
                GamePlay.InputText = "";
                Code = GenerateCode.GenerateWord();
                CounterWin++;
                if (CounterWin == 1)
                {
                    Attac6.Play();
                    HPVillian1.Live = false;
                }
                if (CounterWin == 2)
                {
                    Attac5.Play();
                    HPVillian2.Live = false;
                }
                if (CounterWin == 3)
                {
                    HPVillian3.Live = false;
                    GamePlay.IsBattle6 = false;
                    GamePlay.InputText = "";
                    Death.Play();
                }
            }
        }

        public void Draw()
        {
            if (GamePlay.IsBattle6 && !GamePlay.IsBreak)
            {
                Naruto.Draw();
                Sasuke.Draw();

                if (HPHero1.Live)
                    HPHero1.Draw();

                if (HPHero2.Live)
                    HPHero2.Draw();

                if (HPHero3.Live)
                    HPHero3.Draw();

                if (HPVillian1.Live)
                    HPVillian1.Draw();

                if (HPVillian2.Live)
                    HPVillian2.Draw();

                if (HPVillian3.Live)
                    HPVillian3.Draw();


                Global.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);

                Vector2 dimStr = Font.MeasureString(Code);
                Global.SpriteBatch.DrawString(Font, Code, new Vector2(DisplayWidth / 2 - dimStr.X / 2, DisplayHeight / 4), Color.Black);

                Global.SpriteBatch.End();
            }
        }
    }
}
