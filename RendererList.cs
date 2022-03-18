using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangplankEngine
{
    public class RendererList
    {
        public Scene Scene { get; private set; }
        public List<Renderer> Renderers;
        private List<Renderer> adding;
        private List<Renderer> removing;

        public RendererList(Scene scene)
        {
            Scene = scene;

            Renderers = new List<Renderer>();
            adding = new List<Renderer>();
            removing = new List<Renderer>();
        }

        internal void UpdateLists()
        {
            if (adding.Count > 0)
                foreach (var renderer in adding)
                    Renderers.Add(renderer);
            adding.Clear();
            if (removing.Count > 0)
                foreach (var renderer in removing)
                    Renderers.Remove(renderer);
            removing.Clear();
        }

        public void Update()
        {
            foreach (var renderer in Renderers)
                renderer.Update(Scene);
        }

        public void Render()
        {
            foreach (var renderer in Renderers)
                if (renderer.IsVisible)
                    renderer.Render(Scene);
        }

        public void MoveToFront(Renderer renderer)
        {
            Renderers.Remove(renderer);
            Renderers.Add(renderer);
        }

        public void Add(Renderer renderer)
        {
            adding.Add(renderer);
        }

        public void Remove(Renderer renderer)
        {
            removing.Add(renderer);
        }





    }
}
