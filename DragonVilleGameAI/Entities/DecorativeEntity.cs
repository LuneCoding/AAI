using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonVilleGameAI.Entities
{
    public class DecorativeEntity : BaseGameEntity
    {
        int Type;
        Image Image;
        public DecorativeEntity() : base(){
            Random r = new Random();
            Type = r.Next(3);
            switch (Type)
            {
                case 1:
                    Image = Properties.Resources.flowers2;
                    break;
                case 2:
                    Image = Properties.Resources.flowers3;
                    break;
                default:
                    Image = Properties.Resources.flowers1;
                    break;
            }
        }
        public override void Render(Graphics g)
        {
            int size = 15;
            g.DrawImage(Image, (float)Position.X - (size / 2), (float)Position.Y - (size / 2), size, size);
        }
    }
}
