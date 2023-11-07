using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Scale
{
    internal class GameScene : Scene
    {
        //need a player, a wall, some ui bits, some stuff with the height 
        //i think that might be it?
        private Player _player;
        private Camera _camera;
        public GameScene(GraphicsDeviceManager graphics, SpriteBatch spriteBatch):base(graphics, spriteBatch)
        {
            _player = new Player(this);
            //player gets given all the stats from the start themselves
        }

        public override void Update(float dt)
        {
            _player.Update(dt);
        }

        public override void Draw()
        {
            _player.Draw();
        }
    }
}
