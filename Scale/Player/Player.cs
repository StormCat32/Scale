using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Scale
{
    internal class Player
    {
        private Vector2 _pos; //centre of rectangle body, also pivot point
        private Vector2 _vel; //the movement
        private Vector2 _force; //probably just gravity and tension

        private float _rot; //rotation from the pivot point
        private float _angVel; //angular velocity from the pivot point
        private float _torque; //torque. guess from where

        private const float _mass = 1f; //mass and inertia, for force and torque respectively
        private const float _inertia = 1f;

        private Texture2D _sprite;
        private const string _imageName = "player.png";
        private Vector2 _dimensions;

        private List<Arm> _arms;
        public Player()
        {
            _sprite = Scene.LoadImage(_imageName);
            
            _pos = new Vector2(200,20);
            _dimensions = new Vector2(_sprite.Width, _sprite.Height);

            _arms = new List<Arm>();
            Arm leftArm = new Arm(new (_pos.X,_pos.Y+_dimensions.Y/3));
            Arm rightArm = new Arm(new(_pos.X+_dimensions.X, _pos.Y + _dimensions.Y / 3));
            _arms.Add(rightArm); 
            _arms.Add(leftArm);
        }

        public void Update(float dt)
        {
            //update positional movements
            _vel +=  (Scene.Grav + (1 / _mass) * _force) * dt; //grav added constant irrespective of mass
            _pos += _vel * dt;

            //update rotational movements
            _angVel += _torque * (1 / _inertia) * dt;
            _rot += _angVel * dt;

            _force = Vector2.Zero; //force resets to zero at the end of any data steps, then has effects reapplied whenever things appear
            _torque = 0;

            //need to add some rotational and horizontal damping

            foreach(Arm arm in _arms)
            {
                arm.Update(dt);
            }
        }

        public void Draw()
        {
            Scene.SpriteBatch.Draw(_sprite, _pos,null,Color.White,_rot, _dimensions/2, 1f,SpriteEffects.None,1f);

            foreach (Arm arm in _arms)
            {
                arm.Draw();
            }
        }
    }
}
