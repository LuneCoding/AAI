using DragonVilleGameAI.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Numerics;

namespace DragonVilleGameAI.Entities
{
    public class World
    {
        public Form1 View;

        private Stopwatch watch;
        private Timer timer;
        public long TickCounter;
        public int TickLength;
        public int TickTime;

        private static World _instance = null;
        public static World Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new World();
                }
                return _instance;
            }
        }

        public List<DecorativeEntity> Decorations;
        public List<StaticEntity> Obstacles;
        public List<MovingGameEntity> Entities;

        public int Height { get; set; }
        public int Width { get; set; }
        public int DragonCount = 5;
        public int VillagerCount = 20;

        bool bShowWalls;
        bool bShowObstacles;
        bool bShowPath;
        bool bShowDetectionBox;
        bool bShowWanderCircle;
        bool bShowFeelers;
        bool bShowSteeringForce;
        bool bShowFPS;
        bool bRenderNeighbors;
        bool bViewKeys;
        bool bShowCellSpaceInfo;

        bool Paused;

        #region initialize

        public World()
        {
            TickLength = 50;
            Initialize();
            CreateCity();
            CreateObstacles();
            Populate();
        }


        private void Initialize()
        {
            Width = 500;
            Height = 500;
            Decorations = new List<DecorativeEntity>();
            Obstacles = new List<StaticEntity>();
            Entities = new List<MovingGameEntity>();
            

            watch = new Stopwatch();
            watch.Start();

            timer = new Timer();
            timer.Interval = TickLength;
            timer.Tick += new EventHandler(GameTick);
            timer.Start();

        }
        #endregion

        #region WorldContents

        private void CreateCity()
        {
            var House = new House
            {
                Position = new Vector2(100, 100)
            };
            Obstacles.Add(House);
            var House2 = new House
            {
                Position = new Vector2(300, 200)
            };
            Obstacles.Add(House2);
            var House3 = new House
            {
                Position = new Vector2(150, 400)
            };
            Obstacles.Add(House3);
        }

        private void CreateObstacles()
        {
            Random r = new Random();
            for (int i = 0; i < 10; i++)
            {
                var Decoration = new DecorativeEntity();
                int height = r.Next(0, Height);
                int width = r.Next(0, Width);
                Decoration.Position = new Vector2(height, width);
                Decorations.Add(Decoration);
                var Rock = new Rock();
                height = r.Next(0, Height);
                width = r.Next(0, Width);
                Rock.Position = new Vector2(height, width);
                Obstacles.Add(Rock);
            }
        }

        private void Populate()
        {
            Random r = new Random();
            for (int i = 0; i < DragonCount; i++)
            {
                Entities.Add(new Dragon(new Vector2(r.Next(Width), r.Next(Height))));
            }
            for (int i = 0; i < VillagerCount; i++)
            {
                Entities.Add(new Villager(new Vector2(10, 10), new Vector2(10, 10), new Vector2(r.Next(Width), r.Next(Height))));
            }

        }
        #endregion

        #region GameTick

        public void GameTick(object sender = null, EventArgs e = null)
        {
            UpdateMovement();
            View.Render();



            watch.Stop();
            TickTime = (int)watch.ElapsedMilliseconds;
            watch.Restart();
            TickCounter++;
            System.Console.WriteLine(TickCounter);
        }

        private void UpdateMovement()
        {
            foreach(MovingGameEntity movingGameEntity in Entities)
            {
                movingGameEntity.Update(1d);
            }
        }

        #endregion
    }
}
