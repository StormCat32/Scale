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

        private const float _fps = 100;
        private const float _dt = 1 / _fps;
        private float _accumulator;
        private const float _accumulatorMax = 0.2f;

        private Vector2 _grav;
        public GameScene(GraphicsDeviceManager graphics, SpriteBatch spriteBatch):base(graphics, spriteBatch)
        {
            _player = new Player(this);

            _grav = new Vector2(0,9.8f);
            //player gets given all the stats from the start themselves
        }

        public override void Update(float dt)
        {
            _accumulator += dt;
            if (_accumulator > _accumulatorMax)
                _accumulator = _accumulatorMax;

            while(_accumulator > _dt)
            {
                PhysicsUpdate(_dt);
                _accumulator -= _dt;
            }

            // create float alpha = _accumulator / _dt;
            //use this to render all transform images (arms and player) as such:
            /* 
            void RenderGame( float alpha )
                for shape in game do
                    Transform i = shape.previous * alpha + shape.current * (1.0f - alpha)
                    shape.previous = shape.current
                    shape.Render( i )
            */
        }

        private void PhysicsUpdate(float dt)
        {
            _player.Update(dt,_grav);
        }

        public override void Draw()
        {
            _player.Draw();
        }
    }
}
