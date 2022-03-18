using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace GangplankEngine
{
    public class Animation
    {
        List<Frame> Frames;

        public GTexture this[int index] => Frames[index].Texture;

        public Animation()
        {
            Frames = new List<Frame>();
        }

        public void AddFrame(GTexture texture, Vector2 offset)
        {
            Frames.Add(new Frame(texture, offset));
        }

        public void AddFrame(GTexture texture)
        {
            AddFrame(texture, Vector2.Zero);
        }

        public void AddFrames(params GTexture[] textures)
        {
            foreach (var item in textures)
                AddFrame(item);
        }

        public void SetFrame(int index)
        {
            CurrentIndex = index;
        }

        public void NextFrame()
        {
            CurrentIndex += 1;
        }

        public void PreviousFrame()
        {
            CurrentIndex -= 1;
        }

        private Frame CurrentFrame => Frames[CurrentIndex];
        public GTexture CurrentTexture => CurrentFrame.Texture;
        public int CurrentIndex
        {
            get => currentIndex;
            set
            {
                if (value < 0)
                    currentIndex = 0;
                else if (value >= Frames.Count)
                    currentIndex = Frames.Count - 1;
                else
                    currentIndex = value;
            }
        }
        private int currentIndex = 0;


        public void Draw(Vector2 pos)
        {
            Frame f = CurrentFrame;

            f.Texture?.Draw(pos, f.Offset, Color.White);
        }

        private struct Frame
        {
            public GTexture Texture;
            public Vector2 Offset;

            public Frame(GTexture texture, Vector2 offset)
            {
                Texture = texture;
                Offset = offset;
            }
        }



    }
}
