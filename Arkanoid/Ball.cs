using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Runtime.Intrinsics.X86;
using System.Reflection.Metadata;

namespace Arkanoid
{
    internal class Ball : IGameObject
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;


        private Vector2 _position;
        private Vector2 _velocity;
        


        public Ball(float posX, float posY, float velX, float velY)
        {   
            _position = new Vector2(posX, posY);
            _velocity = new Vector2(velX, velY);
            IsAlive = true;
        }

        public Vector2 Position => _position;
        public Vector2 Velocity => _velocity;

        public float Radius => _texture.Width / 4;       // równa się też _texture.Height/2

        public float RightEdgePosition => _position.X + Radius;
        public float LeftEdgePosition => _position.X - Radius;

        public float TopEdgePosition => _position.Y - Radius;
        public float BottomEdgePosition => _position.Y + Radius;

        public Circle BoundingBox => new Circle(Radius, _position);

        public bool IsAlive { get; private set; }

        public void HandleCollision(CollisionInfo collisionInfo)                                // odbcie wektora predkosci pilki w stosunku do wektora normalnego plaszczyzny, z ktora nastąpila kolizja
        {
 
            float dotProduct = Vector2.Dot(_velocity, collisionInfo.Normal);
            if (dotProduct < 0)                                                 // kiedy piłka uderzała między 2 klocki (2 kolzije jednocześnie) to zamiast odbić się w górę, przechodziła przez te klocki w dół. Jeśli nacieramy na płaszcyzne to iloczyn skalarny będzie ujemny, w takim przypadku dwóch kolizji piłka odbijała się w górę(chociaż nie było tego nawet widać) i od razu zmieiała kierunek w dół, wynik dot product byl wtedy dodatni.  Dlatego zmieniać velocity będziemy tylko wtedy kiedy iloczyn skalarny(dot product) będzie ujemny.
            {        
             _velocity = _velocity - 2 *  dotProduct * collisionInfo.Normal;
            }
            // Update(new GameTime(TimeSpan.Zero, TimeSpan.FromSeconds(1f / 30f)));            //Zapobieganie zatrzymaniu się piłki (w ścianie) przy wytracaniu energii. 
            //_velocity *= .9f;                                                               //Wytracanie Energii
        }

        public void GameOver()
        {
            IsAlive = false;
        }

        public void SetContent(SpriteBatch spritebatch, Texture2D texture)
        {
            _spriteBatch = spritebatch;
            _texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            var ballOffset = _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position = _position + ballOffset;
        }

        public void Draw(GameTime gametime)
        {
            if (IsAlive)
            {
                _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            }
        }

      
    }
}
