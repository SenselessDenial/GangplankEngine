using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GangplankEngine
{
    public class Scene : IEnumerable<Entity>
    {
        public EntityList Entities { get; private set; }
        public RendererList Renderers;
        private Dictionary<int, double> depthLookup;
        protected internal Color FillColor = Color.White;
        protected Entity helper;

        public Scene()
        {
            Entities = new EntityList(this);
            Renderers = new RendererList(this);
            depthLookup = new Dictionary<int, double>();
            helper = new Entity(this);
        }

        public void Add(Entity entity)
        {
            Entities.Add(entity);
            SetDepth(entity);
        }

        public void Remove(Entity entity)
        {
            Entities.Remove(entity);
        }

        public virtual void Begin()
        {

        }

        public virtual void End()
        {
            Entities.Clear();
        }

        public virtual void Update()
        {
            Entities.Update();
            Renderers.UpdateLists();
            Renderers.Update();
        }

        public virtual void BeforeRender()
        {

        }

        public virtual void Render()
        {
            Entities.Render();
        }

        public virtual void AfterRender()
        {

        }

        protected void SetNextScene(Scene scene)
        {
            Engine.Instance.Scene = scene;
        }

        internal void SetDepth(Entity entity)
        {
            const double increment = 0.00001;

            double add = 0;
            if (depthLookup.TryGetValue(entity.layer, out add))
                depthLookup[entity.layer] += increment;
            else
                depthLookup.Add(entity.layer, increment);

            entity.depth = entity.layer - add;
            Entities.MarkUnsorted();
        }

        protected void Exit()
        {
            Engine.Instance.Exit();
        }

        public IEnumerator<Entity> GetEnumerator()
        {
            return ((IEnumerable<Entity>)Entities).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Entities).GetEnumerator();
        }
    }
}
