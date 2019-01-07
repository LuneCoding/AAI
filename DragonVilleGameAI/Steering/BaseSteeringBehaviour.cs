using DragonVilleGameAI.Entities;
using DragonVilleGameAI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace DragonVilleGameAI.Steering
{
    public class BaseSteeringBehaviour
    {
        private MovingGameEntity owner;

        public MovingGameEntity TargetEntity1;
        private MovingGameEntity TargetEntity2;

        private Vector2 TargetLocation;

        private double DetectionBoxLength;

        //the current position on the wander circle the agent is
        //attempting to steer towards
        private Vector2 vWanderTarget;

        //explained above
        double WanderJitter;
        double WanderRadius;
        double WanderDistance;

        public BaseSteeringBehaviour(MovingGameEntity owner)
        {
            this.owner = owner;
        }

        public Vector2 Seek(Vector2 TargetPosition)
        {
            Vector2 offset = TargetPosition - owner.Position;
            Vector2 desiredVelocity = Vector2.Clamp(offset, new Vector2(-owner.MaxSpeed), new Vector2(owner.MaxSpeed)); //xxxnew
            return desiredVelocity - owner.Velocity;
        }

        public Vector2 Flee(Vector2 TargetPosition)
        {
            Vector2 offset = owner.Position - TargetPosition;
            Vector2 desiredVelocity = Vector2.Clamp(offset, new Vector2(-owner.MaxSpeed), new Vector2(owner.MaxSpeed)); //xxxnew
            return desiredVelocity - owner.Velocity;
        }


        public Vector2 Arrive(Vector2 TargetPosition)
        {
            int slowingDistance = 5;
            Vector2 offset = TargetPosition - owner.Position;
            float distance = offset.Length();

            float rampedSpeed = owner.MaxSpeed * (distance / slowingDistance);
            float clippedSpeed = Math.Min(rampedSpeed, owner.MaxSpeed);
            Vector2 desiredVelocity = (clippedSpeed / distance) * offset;
            return desiredVelocity - owner.Velocity;
        }
    }
}
