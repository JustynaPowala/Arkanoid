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
using RectangleF = System.Drawing.RectangleF;
using System.Runtime.InteropServices;

namespace Arkanoid
{
    internal class Platform : IGameObject
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;

        private float _boardWidth;
        private Vector2 _position;
        private float _speed;

        public Platform(float posX, float posY, float speed, float BoardWidth)
        {
            _position = new Vector2(posX, posY);
            _speed = speed;
            _boardWidth = BoardWidth;
        }

        public Vector2 Position => _position;
        public float Speed => _speed;


        public RectangleF BoundingBox => new RectangleF(_position.X - _texture.Width / 2, _position.Y - _texture.Height, _texture.Width, _texture.Height);
        // prostokąt w którym wskazujemy współrzędne lewego górnego rogu  i wielkość

        public float RightEdgePosition => BoundingBox.Right;

        public float LeftEdgePosition => BoundingBox.Left;
        public Texture2D Texture => _texture;

        public bool IsAlive => true;

        public void SetContent(SpriteBatch spritebatch, Texture2D texture)
        {
            _spriteBatch = spritebatch;
            _texture = texture;
        }

        public void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Left))
            {
                _position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                _position.X += _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (RightEdgePosition > _boardWidth)
            {

                _position.X = _boardWidth - _texture.Width / 2;
                //RightEdgePosition = boardX;
            }
            else if (LeftEdgePosition < 0)
            {
                _position.X = 0 + _texture.Width / 2;
                //LeftEdgePosition = 0;
            }
        }


        public void Draw(GameTime gametime)
        {
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height), Vector2.One, SpriteEffects.None, 0f);
        }

    }
}
