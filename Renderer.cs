using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GangplankEngine
{
    public abstract class Renderer
    {
        public Camera Camera;
        public Vector2 MousePos => (Input.MousePos / Camera.Scale) + Camera.Position;

        public bool IsVisible = true;
        public virtual void Update(Scene scene) { }
        public virtual void Render(Scene scene) 
        {
            Drawing.CurrentRenderer = this;
        }
    }
}
