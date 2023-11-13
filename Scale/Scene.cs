using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scale
{
    abstract class Scene
    {
        static private GraphicsDeviceManager _graphics;
        static private SpriteBatch _spriteBatch;
        private static Vector2 _grav = new Vector2(0, 9.8f);

        public Scene(GraphicsDeviceManager graphics, SpriteBatch spriteBatch) 
        { 
            _graphics = graphics;
            _spriteBatch = spriteBatch;
        }

        public abstract void Update(float dt);

        public abstract void Draw();

        static public GraphicsDeviceManager Graphics { get { return _graphics; } }
        static public SpriteBatch SpriteBatch { get { return _spriteBatch; } }
        static public Vector2 Grav { get { return _grav; } }

        //maybe add a mousepressed button activation? 
    }
}
