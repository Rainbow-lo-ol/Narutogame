using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Naruto_game.gameplay.baza;

namespace Naruto_game
{
    public class Basic2d
    {
        public Vector2 Position, Dimension;
        public Texture2D Graf;
        
        public Basic2d(string path, Vector2 pos, Vector2 dim)
        {
            Position = pos;
            Dimension = dim;

            Graf = Global.Content.Load<Texture2D>(path);
        }

        public virtual void Update() 
        { 
        
        }

        public virtual void Draw()
        {
            Global.SpriteBatch.Begin();

            if (Graf != null)
            {
                Global.SpriteBatch.Draw(Graf, new Rectangle((int)Position.X, (int)Position.Y, (int)Dimension.X, (int)Dimension.Y), Color.White);
            }

            Global.SpriteBatch.End();
        }
    }
}
