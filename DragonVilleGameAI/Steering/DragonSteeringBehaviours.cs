using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonVilleGameAI.Entities;
using DragonVilleGameAI.Tools;

using System.Numerics;

namespace DragonVilleGameAI
{
    public class DragonSteeringBehaviours
    {
        private Dragon owner;

        private MovingGameEntity TargetEntity1;
        private MovingGameEntity TargetEntity2;

        private Vector2 TargetLocation;

        private double DetectionBoxLength;

        //the current position on the wander circle the agent is
        //attempting to steer towards
        Vector2 vWanderTarget;

        //explained above
        double WanderJitter;
        double WanderRadius;
        double WanderDistance;

        public DragonSteeringBehaviours(Dragon owner)
        {
            this.owner = owner;
        }

        public Vector2 Seek(Vector2 TargetPosition)
        {
            Vector2 DesiredVelocity = Vector2.Normalize(owner.Position - TargetPosition) * owner.MaxSpeed;
            return (DesiredVelocity - owner.Velocity);
        }

    }
}
