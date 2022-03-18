using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GangplankEngine
{
    public class Camera
    {
        public Matrix Matrix { get; private set; }
        public Viewport Viewport { get; private set; }

        public int Width => Viewport.Width;
        public int Height => Viewport.Height;

        public Vector2 Scale;
        public Vector2 Position;


        public Camera()
        {
            Matrix = Matrix.Identity;
            Scale = Vector2.One;
            Position = Vector2.Zero;
            Viewport = new Viewport(0, 0, Engine.Instance.ScreenWidth, Engine.Instance.ScreenHeight);
        }

        public void UpdateMatrix()
        {
            Matrix translate = Matrix.CreateTranslation(-Position.X, -Position.Y, 0f);
            Matrix scale = Matrix.CreateScale(Scale.X, Scale.Y, 1f);

            Matrix = scale * translate * Matrix.Identity;

            Viewport = new Viewport((int)Position.X,
                                    (int)Position.Y,
                                    (int)(Engine.Instance.ScreenWidth / Scale.X),
                                    (int)(Engine.Instance.ScreenHeight / Scale.Y));
        }









    }
}
