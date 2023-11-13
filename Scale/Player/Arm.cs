using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;


namespace Scale
{
    internal class Arm
    {
        private List<ArmPoint> _points;
        private List<ArmStick> _sticks;

        private const float _armLength = 60;

        private Vector2 _joint;

        //somehow stick the points to the player with a fixed rope
        public Arm(Vector2 jointPoint) 
        {
            _joint = jointPoint;

            _points = new List<ArmPoint>();
            _sticks = new List<ArmStick>();

            ArmPoint topJoint = new ArmPoint(jointPoint, true); //the dynamic one, used for grabbing
            ArmPoint rotJoint = new ArmPoint(jointPoint+new Vector2(0, _armLength)); //the free one, used as the elbow
            ArmPoint fixedJoint = new ArmPoint(jointPoint + new Vector2(0, _armLength*2)); //the one attached to the body
            _points.Add(topJoint);
            _points.Add(rotJoint);
            _points.Add(fixedJoint);

            ArmStick topLimb = new ArmStick(topJoint, rotJoint, _armLength);
            ArmStick bottomLimb = new ArmStick(rotJoint, fixedJoint, _armLength);
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
