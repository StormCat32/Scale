using System.Numerics;

namespace Scale
{
    static class PhysicsFunctions
    {
        // Two crossed vectors return a scalar 
        static float CrossProduct( Vector2 a, Vector2 b)
        {
            return a.X* b.Y - a.Y* b.X;
        }
        // More exotic (but necessary) forms of the cross product 
        // with a vector a and scalar s, both returning a vector 
        static Vector2 CrossProduct( Vector2 a, float s)
        {
            return new Vector2(s * a.Y, -s * a.X);
        }
        static Vector2 CrossProduct(float s, Vector2 a )
        {
            return new Vector2(-s * a.Y, s * a.X);
        }
}
}
