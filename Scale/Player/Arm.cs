using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;


namespace Scale
{
    enum ArmDirection
    {
        Left,
        Right
    }
    internal class Arm
    {
        private List<ArmJoint> _joints;

        private ArmDirection _dir; //used for capping internal angles and so on

        //somehow stick the points to the player with a fixed rope
        public Arm() 
        {
            _joints = new List<ArmJoint>();
            ArmJoint topJoint = new ArmJoint(); //the dynamic one, used for grabbing
            ArmJoint rotJoint = new ArmJoint(); //the free one, used as the elbow
            ArmJoint fixedJoint = new ArmJoint(); //the one attached to the body
        }

        public void Update(float dt)
        {

        }

        public void Draw()
        {

        }
    }
}
