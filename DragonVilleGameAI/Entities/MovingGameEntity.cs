using DragonVilleGameAI.Steering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DragonVilleGameAI.Entities
{
    public abstract class MovingGameEntity : BaseGameEntity
    {
        BaseSteeringBehaviour baseSteeringBehaviour;

        public float Mass { get; set; }
        public float Radius { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Acceleration { get; }
        public float Speed { get; set; }

        public abstract Vector2 PredictFuturePosition(float predictionTime);

        public float MaxForce { get; }
        public float MaxSpeed { get; }


        public Vector2 Heading = new Vector2();
        public Vector2 Side = new Vector2();

        static Random r = new Random();
        public double MaxTurnRate;

        public double AttackPower;
        public double HitPoints;

        public MovingGameEntity(Vector2 Velocity, Vector2 Heading, Vector2 Position, double AttackPow, double HitPoints, double Boundingradius):base(Position, Boundingradius)
        {
            this.Position = Position;
            this.Velocity = Velocity;
            this.Heading = Heading;
            this.HitPoints = HitPoints;
            this.AttackPower = AttackPow;
            baseSteeringBehaviour = new BaseSteeringBehaviour(this);
            MaxSpeed = 1;
        }

        public MovingGameEntity(Vector2 vVelocity, Vector2 vHeading, Vector2 vPos, double dAttackPow, double dHitPoints)
        {
            this.Position = vPos;
            this.Velocity = vVelocity;
            this.Heading = vHeading;
            this.HitPoints = dHitPoints;
            this.AttackPower = dAttackPow;
            baseSteeringBehaviour = new BaseSteeringBehaviour(this);
            MaxSpeed = 1;
        }

        public void Update(double tick)
        {
            Vector2 SteeringForce = CalculateSteeringForce();
            Vector2 acceleration = SteeringForce / Mass;
            Velocity += acceleration * (float)tick;
            Vector2.Clamp(Velocity, new Vector2(-MaxSpeed), new Vector2(MaxSpeed));
            Console.WriteLine("BeforeUpdate" + Position.X + " " + Position.Y + "SteeringForce" + Velocity.X + " " + Velocity.Y);
            Position = Position+ Velocity;
            Console.WriteLine("AfterUpdate" + Position.X + " " + Position.Y);
            if (Velocity.X != 0 || Velocity.Y !=0)
            {
                Heading = Vector2.Normalize(Velocity);
            }
        }

        protected Vector2 CalculateSteeringForce()
        {
            if (baseSteeringBehaviour.TargetEntity1 == null)
            {
                int random = r.Next(World.Instance.Entities.Count());
                baseSteeringBehaviour.TargetEntity1 = World.Instance.Entities[random];
            }

            return baseSteeringBehaviour.Flee(new Vector2(250, 250));
        }
    }
}
