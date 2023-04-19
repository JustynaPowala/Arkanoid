using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;
using RectangleF= System.Drawing.RectangleF;

namespace Arkanoid
{
    public class Game1 : Game
    {
        private Texture2D _platform2Texture;
   
        private Texture2D _ballTexture; 

        private Texture2D _blockTexture;

        private Texture2D _gameOverTexture;

        private Texture2D _winTexture;
   
        private Ball _ball;
        private Platform _platform;
        
        private List<Block> _blocks;
        private List<IGameObject> _gameObjects;

       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
      

        private bool _isWin = false;
        

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true; 
            _blocks = new List<Block>();
            _gameObjects = new List<IGameObject>();
        }


        protected override void Initialize()
        {
            
          

            _ball = new Ball(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2, 150f, -200f);
            _platform = new Platform(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight, 300f, _graphics.PreferredBackBufferWidth);


            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 100, _graphics.PreferredBackBufferHeight - 100));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 130, _graphics.PreferredBackBufferHeight - 130));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 160, _graphics.PreferredBackBufferHeight - 160));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 190, _graphics.PreferredBackBufferHeight - 190));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 600, _graphics.PreferredBackBufferHeight - 190));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 630, _graphics.PreferredBackBufferHeight - 160));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 660, _graphics.PreferredBackBufferHeight - 130));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 690, _graphics.PreferredBackBufferHeight - 100));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 100, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 150, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 200, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 250, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 300, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 350, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 400, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 450, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 500, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 550, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 600, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 650, _graphics.PreferredBackBufferHeight - 300));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 700, _graphics.PreferredBackBufferHeight - 300));

            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 150, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 200, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 250, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 300, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 350, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 400, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 450, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 500, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 550, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 600, _graphics.PreferredBackBufferHeight - 350));
            _blocks.Add(new Block(_graphics.PreferredBackBufferWidth - 650, _graphics.PreferredBackBufferHeight - 350));




            _gameObjects.Add(_ball);
            _gameObjects.Add(_platform);
            _gameObjects.AddRange(_blocks);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            

            _platform2Texture = Content.Load<Texture2D>("platform2");
            _ballTexture = Content.Load<Texture2D>("ball");
            _blockTexture = Content.Load<Texture2D>("klocek");
            _gameOverTexture = Content.Load<Texture2D>("game_over");
            _winTexture = Content.Load<Texture2D>("win2");

            _platform.SetContent(_spriteBatch, _platform2Texture);
            _ball.SetContent(_spriteBatch, _ballTexture);

            foreach(var block in _blocks)
            {
                block.SetContent(_spriteBatch, _blockTexture);
            }
            
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if (_ball.RightEdgePosition > _graphics.PreferredBackBufferWidth)
            {
                _ball.HandleCollision(new CollisionInfo(new Vector2(-1f, 0f)));       
            }

            else if (_ball.LeftEdgePosition < 0)
            {
                _ball.HandleCollision(new CollisionInfo(new Vector2(1f, 0f)));
            }


            if (_ball.BottomEdgePosition > _graphics.PreferredBackBufferHeight)
            {
               
                if (_isWin == false)
                {
                    _ball.GameOver();
                }
            }

            else if (_ball.TopEdgePosition < 0)
            {
                _ball.HandleCollision(new CollisionInfo(new Vector2(0f, 1f)));
            }


            var collision = CollisionDetector.Detect(_ball.BoundingBox, _platform.BoundingBox);
            if (collision != null)
            {
                _ball.HandleCollision(collision);
            }


            foreach (var block in _blocks)
            {
                var collision2 = CollisionDetector.Detect(_ball.BoundingBox, block.BoundingBox);

                if (collision2 != null)
                {
                    _ball.HandleCollision(collision2);
                    block.HandleCollision(collision2);
                }
                
            }


            foreach (var gameObject in _gameObjects)
            {
                gameObject.Update(gameTime);
            }

            var aliveGameObjects = new List<IGameObject>();


            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsAlive)
                {
                    aliveGameObjects.Add(gameObject);
                }
                else if (gameObject is Block blockGameObject)  
                {
                    _blocks.Remove(blockGameObject);
                }
            }

            _gameObjects = aliveGameObjects;

            if (_blocks.Count ==0)
            {
                _isWin = true;
            }

            

            base.Update(gameTime);

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            _spriteBatch.Begin();       

            foreach (var gameObject in _gameObjects)
            {
                gameObject.Draw(gameTime);
            }

            if (!_ball.IsAlive)
            {
                _spriteBatch.Draw(_gameOverTexture,new Vector2(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2), null, Color.White, 0f, new Vector2(_gameOverTexture.Width / 2, _gameOverTexture.Height/2), Vector2.One, SpriteEffects.None, 0f);
            }

            if (_isWin)
            {
                _spriteBatch.Draw(_winTexture, new Vector2(_graphics.PreferredBackBufferWidth/2.5f, _graphics.PreferredBackBufferHeight / 1.5f), null, Color.White, 0f, new Vector2(_gameOverTexture.Width /2.5f, _gameOverTexture.Height + 40), Vector2.One, SpriteEffects.None, 0f);
               
            }

            _spriteBatch.End();
            




            base.Draw(gameTime);
        }
    }
}