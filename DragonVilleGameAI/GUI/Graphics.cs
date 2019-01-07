using DragonVilleGameAI.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragonVilleGameAI.GUI
{
    static class WorldGraphics
    {
        private static Graphics graphicsPanel;
        private static Panel panel;

        private static Bitmap screen;
        private static Graphics graphics;

      
        public static void Render(Graphics g, Panel p)
        {
            graphicsPanel = g;
            panel = p;
            screen = new Bitmap(World.Instance.Width, World.Instance.Height);
            graphics = Graphics.FromImage(screen);



            DrawWorld();
            DrawStatic();
            DrawEntities();
            graphicsPanel.DrawImage(screen, 0, 0, panel.Width, panel.Height);
        }

        public static void DrawWorld()
        {
            graphics.FillRectangle(Brushes.DarkOliveGreen, 0, 0, World.Instance.Width, World.Instance.Height);
        }
        public static void DrawStatic()
        {
            foreach(DecorativeEntity decoration in World.Instance.Decorations)
            {
                decoration.Render(graphics);
            }
            foreach(StaticEntity obstacle in World.Instance.Obstacles)
            {
                obstacle.Render(graphics);
            }
        }

        public static void DrawEntities()
        {
            foreach (MovingGameEntity movingEntity in World.Instance.Entities)
            {
                movingEntity.Render(graphics);
            }
        }
    }
}
