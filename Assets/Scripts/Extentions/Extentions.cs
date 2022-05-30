using UnityEngine;

namespace Extentions
{
    public static class Extentions
    {
        public static bool Equals(this Vector2 vector, Vector2 vector2, float error)
        {
            var x = vector.x;
            var y = vector.y;
            var x2 = vector2.x;
            var y2 = vector2.y;
            return x > x2 - error 
                   && x < x2 + error 
                   && y > y2 - error 
                   && y < y2 + error;
        }
    }
}