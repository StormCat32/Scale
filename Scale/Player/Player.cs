using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scale
{
    internal class Player
    {
        private GameScene _parent;
        private Vector2 _pos;
        private Vector2 _vel;
        public Player(GameScene parent)
        {
            _parent = parent;
            _pos = new Vector2(200,20);
        }

        public void Update(float dt)
        {
            _vel.Y += dt*60;
            _pos.Y += dt*_vel.Y;
        }

        public void Draw()
        {
            Texture2D pixel = new Texture2D(_parent.Graphics.GraphicsDevice, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

            Rectangle bigRectangle = new Rectangle((int)_pos.X,(int)_pos.Y, 100, 180);
            _parent.SpriteBatch.Draw(pixel,bigRectangle,Color.White);
        }
    }
}
