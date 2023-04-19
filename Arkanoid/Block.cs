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
    internal class Block : IGameObject
    {
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;


        private Vector2 _position;

        public Block(float posX, float posY)
        {
            _position = new Vector2(posX, posY);
            IsAlive = true;
        }




        public Vector2 Position => _position;

        public RectangleF BoundingBox => new RectangleF(_position.X - _texture.Width / 2, _position.Y - _texture.Height, _texture.Width, _texture.Height);
        


        public bool IsAlive { get; private set; }

        public void HandleCollision(CollisionInfo collisionInfo)
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

        }

        public void Draw(GameTime gametime)
        {
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
