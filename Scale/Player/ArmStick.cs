using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Scale
{
    internal class ArmStick
    {
        private ArmPoint _pointA;
        private ArmPoint _pointB;
        private float _length;

        private const int _simNum = 3; //number of physics simulations to move the points

        public ArmStick(ArmPoint pointA,ArmPoint pointB,float length)
        {
            _pointA = pointA;
            _pointB = pointB;
            _length = length;
        }

        public void Update(float dt)
        {
            for(int i=0; i<_simNum; i++)
            {
                Vector2 centre = (_pointA.Pos + _pointB.Pos)/2;
                Vector2 dir = (_pointA.Pos - _pointB.Pos)/Vector2.Distance(_pointA.Pos,_pointB.Pos);

                if (!_pointA.Locked)
                    _pointA.Pos = centre + dir * _length / 2;

                if (!_pointB.Locked)
                    _pointB.Pos = centre - dir * _length / 2;
            }
        }
    }
}
