using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Naruto_game.gameplay.baza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naruto_game.gameplay.Menu
{
    public class Rules
    {
        Basic2d Background;
        Basic2d _rules;
        MainMenu MainMenu;
        public Rules() 
        {
            Background = new Basic2d("2d/MainMenuBackground",
                                     new Vector2(0, 0),
                                     new Vector2(BaseValue.DisplayWidth, BaseValue.DisplayHeight));
            _rules = new Basic2d("2d/Rules",
                                     new Vector2(0, 0),
                                     new Vector2(BaseValue.DisplayWidth, BaseValue.DisplayHeight));
        }
        public void Update() 
        { 
            Background.Update();
            _rules.Update();
        }

        public void Draw()
        {
            Background.Draw();
            _rules.Draw();

        }
    }
}
