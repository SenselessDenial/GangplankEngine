using System;
using System.IO;
using System.Reflection;
using System.Runtime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GangplankEngine
{
    public class Engine : Game
    {
        private GraphicsDeviceManager graphics;

        public static Engine Instance { get; private set; }
        public static double RawTotalTime { get; private set; }
        public static double RawDeltaTime { get; private set; }
        public static float DeltaTime { get; private set; }
        public static string AssemblyLocationPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static string ResourceFolderPath => Path.Combine(AssemblyLocationPath, Instance.Content.RootDirectory);

        public int ScreenWidth
        {
            get => graphics.PreferredBackBufferWidth;
            set
            {
                graphics.PreferredBackBufferWidth = value;
                graphics.ApplyChanges();
            }
        }
        public int ScreenHeight
        {
            get => graphics.PreferredBackBufferHeight;
            set
            {
                graphics.PreferredBackBufferHeight = value;
                graphics.ApplyChanges();
            }
        }

        public Scene Scene
        {
            get => scene;
            set => nextScene = value;
        }
        private Scene scene;
        private Scene nextScene;



        public Engine(int width, int height)
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = @"Content";
            Instance = this;

            ScreenWidth = width;
            ScreenHeight = height;

            DeltaTime = 0f;
            RawDeltaTime = 0;
            RawTotalTime = 0;

            IsMouseVisible = true;

            GCSettings.LatencyMode = GCLatencyMode.SustainedLowLatency;
        }


        protected override void Initialize()
        {
            base.Initialize();

            Input.Initialize();
            Drawing.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            RawDeltaTime = gameTime.ElapsedGameTime.TotalSeconds;
            RawTotalTime += RawDeltaTime;
            DeltaTime = (float)RawDeltaTime;

            Input.Update();

            if (Input.Check(Keys.Escape))
                Exit();

            if (Scene != null)
                Scene.Update();

            if (scene != nextScene)
            {
                if (scene != null)
                    scene.End();
                OnSceneTransition(scene, nextScene);
                scene = nextScene;
                if (scene != null)
                    scene.Begin();
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            if (Scene != null)
                GraphicsDevice.Clear(Scene.FillColor);

            if (Scene != null)
                Scene.Renderers.Render();

            base.Draw(gameTime);
        }

        protected virtual void OnSceneTransition(Scene from, Scene to)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
