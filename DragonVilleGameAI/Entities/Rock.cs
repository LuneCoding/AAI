using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonVilleGameAI.Entities
{
    public class Rock:StaticEntity
    {

        public override void Render(Graphics g)
        {
            int size = 20;
            g.DrawImage(Properties.Resources.RockSprite, (float)Position.X - (size / 2), (float)Position.Y - (size / 2), size, size);
        }
    }
}
