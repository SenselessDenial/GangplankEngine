using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace GangplankEngine
{
    public class FullRenderer : Renderer
    {
        public BlendState BlendState;
        public SamplerState SamplerState;
        public DepthStencilState DepthStencilState;
        public RasterizerState RasterizerState;
        public Effect Effect;

        

        public FullRenderer()
        {
            BlendState = BlendState.NonPremultiplied;
            SamplerState = SamplerState.PointClamp;
            DepthStencilState = DepthStencilState.None;
            RasterizerState = RasterizerState.CullNone;
            Effect = null;
        }

        public override void Render(Scene scene)
        {
            base.Render(scene);

            if (scene == null)
            {
                Logger.Log("Scene is null. Cannot draw.");
                return;
            }

            Engine.Instance.GraphicsDevice.Clear(scene.FillColor);

            Drawing.SpriteBatch.Begin(SpriteSortMode.Deferred,
                                      BlendState,
                                      SamplerState,
                                      DepthStencilState,
                                      RasterizerState,
                                      Effect,
                                      Camera.Matrix);

            scene.BeforeRender();
            scene.Render();
            scene.AfterRender();

            Drawing.SpriteBatch.End();

        }












    }
}
