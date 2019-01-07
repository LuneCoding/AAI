using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonVilleGameAI.Tools;

using System.Numerics;

namespace DragonVilleGameAI.Entities
{
    public class Dragon : MovingGameEntity
    {
        DragonSteeringBehaviours dragonSteeringBehaviours;
        
        public Dragon(Vector2 vVelocity, Vector2 vHeading, Vector2 vPos, double dAttackPow = 5, double dHitPoints = 50) : base(vVelocity, vHeading, vPos, dAttackPow, dHitPoints)
        {
            dragonSteeringBehaviours = new DragonSteeringBehaviours(this);
        }

        public Dragon(Vector2 Position) : base(new Vector2(), new Vector2(), Position, 5, 50)
        {
            this.Position = Position;
            dragonSteeringBehaviours = new DragonSteeringBehaviours(this);
        }

        public Dragon(Vector2 vVelocity, Vector2 vHeading, Vector2 vPosition, double dBoundingradius, double dAttackPow = 5, double dHitPoints = 50) : base(vVelocity, vHeading, vPosition, dAttackPow, dHitPoints, dBoundingradius)
        {
            dragonSteeringBehaviours = new DragonSteeringBehaviours(this);
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void Render(Graphics g)
        {
            int size = 25;
            g.DrawImage(Properties.Resources.Dragon, (float)Position.X, (float)Position.Y, size, size);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override Vector2 PredictFuturePosition(float predictionTime)
        {
            throw new NotImplementedException();
        }
    }
}
