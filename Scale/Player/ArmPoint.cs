using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace Scale
{
    internal class ArmPoint
    {
        private Vector2 _pos;
        private Vector2 _lastPos;
        public Vector2 Pos { get { return _pos; } set { _pos = value; } }
        public Vector2 LastPos { get { return _lastPos; } set { _lastPos = value; } }

        private bool _locked;
        public bool Locked { get { return _locked; } set { _locked = value; } }

        private const float _damping = 0.92f;

        public ArmPoint(Vector2 pos,bool locked){
            _pos = pos;
            _lastPos = pos;

            Locked = locked;
        }

        public ArmPoint(Vector2 pos)
        {
            _pos = pos;
            _lastPos = pos;

            Locked = false;
        }

        public void Update(float dt)
        {
            if (Locked)
                return;
            Vector2 posBefore = Pos;
            Pos += (Pos - LastPos) * _damping;
            Pos += Scene.Grav * dt;
            LastPos = posBefore;
        }

        public void Draw()
        {
            FileStream fileStream = new FileStream("arm.png", FileMode.Open);
            Texture2D sprite = Texture2D.FromStream(Scene.Graphics.GraphicsDevice, fileStream);
            fileStream.Dispose();

            Scene.SpriteBatch.Draw(sprite, Pos, null, Color.White, 0, new Vector2(8,8), 1f, SpriteEffects.None, 1f);
        }
    }
}
