using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scale
{
    abstract class Scene
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public Scene(GraphicsDeviceManager graphics, SpriteBatch spriteBatch) 
        { 
            _graphics = graphics;
            _spriteBatch = spriteBatch;
        }

        public abstract void Update(float dt);

        public abstract void Draw();

        public GraphicsDeviceManager Graphics { get { return _graphics; } }
        public SpriteBatch SpriteBatch { get { return _spriteBatch; } }

        //maybe add a mousepressed button activation? 
    }
}
