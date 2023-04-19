using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class Circle
    {

        public Circle(float radius, Vector2 position) 
        { 
            Radius= radius;
            Position = position;
        }

        public float Radius { get; }
        public Vector2 Position { get; }
    }
}
