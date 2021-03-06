using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GangplankEngine
{
    public static class Input
    {
        private static KeyboardState currKeyboardState;
        private static KeyboardState prevKeyboardState;
        private static MouseState currMouseState;
        private static MouseState prevMouseState;

        public static Vector2 MousePos => currMouseState.Position.ToVector2();


        public static void Initialize()
        {
            currKeyboardState = Keyboard.GetState();
            prevKeyboardState = Keyboard.GetState();
            currMouseState = Mouse.GetState();
            prevMouseState = Mouse.GetState();
        }

        public static void Update()
        {
            prevKeyboardState = currKeyboardState;
            currKeyboardState = Keyboard.GetState();
            prevMouseState = currMouseState;
            currMouseState = Mouse.GetState();
        }

        public static bool Check(Keys key)
        {
            return currKeyboardState.IsKeyDown(key);
        }

        public static bool Pressed(Keys key)
        {
            return currKeyboardState.IsKeyDown(key) && prevKeyboardState.IsKeyUp(key);
        }

        public static bool Released(Keys key)
        {
            return currKeyboardState.IsKeyUp(key) && prevKeyboardState.IsKeyDown(key);
        }

        public static bool LeftClick()
        {
            return currMouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool LeftMouseDown()
        {
            return currMouseState.LeftButton == ButtonState.Pressed;
        }

        public static int HorizontalAxisCheck()
        {
            int num = 0;
            if (Check(Keys.Right))
                num += 1;
            if (Check(Keys.Left))
                num -= 1;

            return num;
        }
    }
}
