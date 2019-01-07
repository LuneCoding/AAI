using DragonVilleGameAI.Tools;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace DragonVilleGameAI.Entities
{
    public class Villager:MovingGameEntity
    {


        public Villager(Vector2 vVelocity, Vector2 vHeading, Vector2 vPos, double dAttackPow = 5, double dHitPoints = 50) : base(vVelocity, vHeading, vPos, dAttackPow, dHitPoints)
        {
        }

        public Villager(Vector2 vVelocity, Vector2 vHeading, Vector2 vPosition, double dBoundingradius, double dAttackPow = 5, double dHitPoints = 50) : base(vVelocity, vHeading, vPosition, dAttackPow, dHitPoints, dBoundingradius)
        {
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }


        public override void Render(Graphics g)
        {
            int size = 5;
            g.DrawImage(Properties.Resources.Warrior, (float)Position.X + (size / 2), (float)Position.Y + (size / 2), 15, 20);

        }

        public override Vector2 PredictFuturePosition(float predictionTime)
        {
            throw new NotImplementedException();
        }
    }
}
