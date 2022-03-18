using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GangplankEngine
{
    public static class Drawing
    {
        public static SpriteBatch SpriteBatch { get; private set; }
        private static GTexture Pixel { get; set; }
        public static PixelFont Font { get; private set; }

        public static Renderer CurrentRenderer;

        public static void Initialize()
        {
            SpriteBatch = new SpriteBatch(Engine.Instance.GraphicsDevice);
            Pixel = new GTexture(1, 1, Color.White);
            Font = new PixelFont("TahomaFont.png", "tahoma13pt.xml");
        }

        public static void DrawPoint(Vector2 pos, Color color)
        {
            Pixel.Draw(pos, color);
        }

        public static void DrawBox(Rectangle rect, Color color)
        {
            Pixel.Draw(new Vector2(rect.X, rect.Y), color, new Vector2(rect.Width, rect.Height));
        }

        public static void DrawBoxBorder(Rectangle rect, Color color)
        {
            Pixel.Draw(new Vector2(rect.X, rect.Y), color, new Vector2(rect.Width, 1f));
            Pixel.Draw(new Vector2(rect.X, rect.Y), color, new Vector2(1f, rect.Height));
            Pixel.Draw(new Vector2(rect.X + rect.Width - 1, rect.Y), color, new Vector2(1f, rect.Height));
            Pixel.Draw(new Vector2(rect.X, rect.Y + rect.Height - 1), color, new Vector2(rect.Width, 1f));
        }

        public static void DrawBox(Rectangle rect, Color innerColor, Color borderColor)
        {
            DrawBox(rect, innerColor);
            DrawBoxBorder(rect, borderColor);
        }

        public static void DrawLine(Vector2 start, Vector2 end, Color color)
        {
            float distance = Calc.Distance(start, end);
            float angle = Calc.Angle(start, end);
            Pixel.Draw(start, color, angle, new Vector2(0, 0), new Vector2(distance, 1f));
        }

        public static void DrawLinePlus(Vector2 start, Vector2 end, Color color)
        {
            Vector2 slope = end - start;
            slope = slope.NormalizeSquare();
            Vector2 increment = Vector2.Zero;

            while (Vector2.Distance(start, start + increment) < Vector2.Distance(start, end))
            {
                Pixel.Draw(new Vector2((int)(start.X + increment.X), (int)(start.Y + increment.Y)), color);
                increment += slope;
            }
        }


    }

    public enum DrawAlignment
    {
        TopLeft,
        TopCenter,
        TopRight,
        CenterLeft,
        Center,
        CenterRight,
        BottomLeft,
        BottomCenter,
        BottomRight
    }
}
