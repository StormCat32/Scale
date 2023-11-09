using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace Scale
{
    internal class Player
    {
        private GameScene _parent;
        private Vector2 _pos; //centre of rectangle body, also pivot point
        private Vector2 _vel; //the movement
        private Vector2 _force; //probably just gravity and tension

        private float _rot; //rotation from the pivot point
        private float _angVel; //angular velocity from the pivot point
        private float _torque; //torque. guess from where

        private const float _mass = 1f; //mass and inertia, for force and torque respectively
        private const float _inertia = 1f;
        public Player(GameScene parent)
        {
            _parent = parent;
            _pos = new Vector2(200,20);
        }

        public void Update(float dt,Vector2 grav)
        {
            _force += grav; 
            _vel += ((1 / _mass) * _force) * dt;
            _pos += _vel * dt;

            _force = Vector2.Zero; //force resets to zero at the end of any data steps, then has effects reapplied whenever things appear
        }

        public void Draw()
        {
            FileStream fileStream = new FileStream("player.png", FileMode.Open);
            Texture2D sprite = Texture2D.FromStream(_parent.Graphics.GraphicsDevice, fileStream);
            fileStream.Dispose();

            _parent.SpriteBatch.Draw(sprite, _pos,null,Color.White,_rot, new Vector2(50, 90), 1f,SpriteEffects.None,1f);
        }
    }
}
