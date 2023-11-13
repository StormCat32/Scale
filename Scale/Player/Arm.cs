using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;


namespace Scale
{
    internal class Arm
    {
        private List<ArmPoint> _points;
        private List<ArmStick> _sticks;

        //somehow stick the points to the player with a fixed rope
        public Arm() 
        {
            _points = new List<ArmPoint>();
            _sticks = new List<ArmStick>();
            ArmPoint topJoint = new ArmPoint(new(60,0),true); //the dynamic one, used for grabbing
            ArmPoint rotJoint = new ArmPoint(new(40, 60)); //the free one, used as the elbow
            ArmPoint fixedJoint = new ArmPoint(new(80, 120)); //the one attached to the body
            _points.Add(topJoint);
            _points.Add(rotJoint);
            _points.Add(fixedJoint);
            ArmStick topLimb = new ArmStick(topJoint, rotJoint,60);
            ArmStick bottomLimb = new ArmStick(rotJoint, fixedJoint, 60);
            _sticks.Add(topLimb);
            _sticks.Add(bottomLimb);
        }

        public void Update(float dt)
        {
            foreach(ArmPoint point in _points)
            {
                point.Update(dt);
            }
            foreach (ArmStick stick in _sticks)
            {
                stick.Update(dt);
            }
            //if space is down, crunch interior angles
        }

        public void Draw()
        {
            foreach (ArmPoint point in _points)
            {
                point.Draw();
            }
        }
    }
}
