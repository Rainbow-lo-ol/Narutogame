using Microsoft.Xna.Framework.Graphics;


namespace Naruto_game.gameplay.baza
{
    public class BaseValue
    {
        public static int DisplayWidth => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        public static int DisplayHeight => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        public static float XPossitionPlayer => (float)(DisplayWidth * 0.65);
        public static float XPossitionVillian => (float)(DisplayWidth * 0.01);
        public static float YPossition => (float)(DisplayHeight * 0.3);
        public static float XDimention => (float)(DisplayWidth * 0.36);
        public static float YDimention => (float)(DisplayHeight * 0.7);
        public static float XPositionHPHero => (float)(DisplayWidth * 0.65);
        public static float XPositionHPVillian => (float)(DisplayWidth * 0.33);
    }
}
