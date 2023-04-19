using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class CollisionInfo
    {

        public CollisionInfo(Vector2 normal) 
        {
            Normal = normal;
        }

        
        public Vector2 Normal
        {
            get; 
        }


    }
}
