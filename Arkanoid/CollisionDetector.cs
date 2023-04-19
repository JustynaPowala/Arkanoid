using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    internal class CollisionDetector
    {
        
        public static CollisionInfo? Detect(Circle circleBoundingBox, RectangleF rectangleBoundingBox) 
        {
            float closestPointOnRectangleX;
            float closestPointOnRectangleY;

            var circleCenterX = circleBoundingBox.Position.X;
            var circleCenterY = circleBoundingBox.Position.Y;
            var radius = circleBoundingBox.Radius;

            if (circleCenterX > rectangleBoundingBox.Right)
            {
                closestPointOnRectangleX = rectangleBoundingBox.Right;
            }

            else if (circleCenterX < rectangleBoundingBox.Left)
            {
                closestPointOnRectangleX = rectangleBoundingBox.Left;
            }

            else 
            { closestPointOnRectangleX = circleCenterX; }


            if(circleCenterY > rectangleBoundingBox.Bottom)
            {
                closestPointOnRectangleY = rectangleBoundingBox.Bottom;
            }

            else if(circleCenterY < rectangleBoundingBox.Top)
            {
                closestPointOnRectangleY = rectangleBoundingBox.Top;
            }

            else 
            { closestPointOnRectangleY = circleCenterY; }


            var closestPointOnRectangle = new Vector2(closestPointOnRectangleX, closestPointOnRectangleY);

           ;
            var fromClosestPoinfOnRectangleToCircleCenter = circleBoundingBox.Position - closestPointOnRectangle; 
          

           
            var d = fromClosestPoinfOnRectangleToCircleCenter.LengthSquared();
            //  The length function was not used because rooting is inefficient.
            //  The LenghtSquared function will return length squared,
            //  so below we compare this result to radois* radius, not radius.


            if ( d <= radius*radius && d > float.Epsilon)    //when normalizing vector to 1 we divide by the lenght of the vector- so it must be greater than 0
                                                          
            {
                fromClosestPoinfOnRectangleToCircleCenter.Normalize();   
                                                                         
                return new  CollisionInfo(fromClosestPoinfOnRectangleToCircleCenter);
            }

            return null;

      
        }


    }
}
