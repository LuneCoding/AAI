using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonVilleGameAI.Entities
{
    public class House:StaticEntity
    {
        public House() : base()
        {
            dBoundingRadius = 35;
        }
        public override void Render(Graphics g)
        {
            int size = (int)dBoundingRadius*2;
            g.DrawImage(Properties.Resources.HouseSprite, (float)Position.X - (size/2), (float)Position.Y-(size/2), size, size);
        }
    }
}
