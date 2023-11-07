using Microsoft.Xna.Framework;

namespace Scale
{
    internal class Camera
    {
        private Player _target;
        private Vector2 _pos;
        public Camera(Player target)
        {
            _target = target;
            //set up camera position and tracking behaviours
        }
    }
}
