using DragonVilleGameAI.Tools;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DragonVilleGameAI.Entities
{
    public abstract class BaseGameEntity
    {
        //All entities need a unique ID
        int ID;

        static int nextID = 0;

        int type;

        bool bTag;

        //Location in the gameworld

        public Vector2 Position = new Vector2();

        Vector2 vScale;

        //Size of objects bounding radius
        public double dBoundingRadius;

        //make default entity
        public BaseGameEntity()
        {
            ID = NextID();
            bTag = false;
            Position = new Vector2();
            vScale = new Vector2();
            dBoundingRadius = 0.0;
        }

        //Make entity with position
        public BaseGameEntity(Vector2 position, double radius)
        {
            dBoundingRadius = radius;
            ID = NextID();
            bTag = false;
            Position = position;
            vScale = new Vector2();
            dBoundingRadius = 0.0;
        }

        //Used for forcing a second entity with same ID, like for undo/redo
        public BaseGameEntity(int forcedID)
        {
            dBoundingRadius = 0.0;
            ID = forcedID;
            bTag = false;
            Position = new Vector2();
            vScale = new Vector2();
            dBoundingRadius = 0.0;
        }

        public abstract void Render(Graphics g);

        private int NextID()
        {
            return nextID++;
        }
        
    }
}
