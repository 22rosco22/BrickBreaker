using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Block_Breaker
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        const int WindowHeight = 600;
        const int WindowWidth = 800;

        Texture2D Ball;
        Texture2D Paddle;
        Texture2D Block;
        Vector2 PaddlePos = new Vector2(350, 500);
        Vector2 BallPos;
        Vector2 BallSpeed;
        List<Vector2> BricksPos;
        SpriteFont Lives;
        int Numberlives = 5;
        int score;
        SoundEffect PaddleBounce;
        SoundEffect BlockBounce;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                // sets the height and width of the screen
                PreferredBackBufferWidth = WindowWidth,
                PreferredBackBufferHeight = WindowHeight

            };
            Content.RootDirectory = "Content";

          
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //adds in a ball at the same position as the paddle and set the speed
            BallPos = new Vector2(PaddlePos.X + Paddle.Width /2 , PaddlePos.Y - Paddle.Height /2);
            BallSpeed = new Vector2( -1 , - 1);

            //begins the array of positions
            BricksPos = new List<Vector2>();

            //adding in the position of the first row of bricks
            BricksPos.Add(new Vector2(050, 080));
            BricksPos.Add(new Vector2(150, 080));
            BricksPos.Add(new Vector2(250, 080));
            BricksPos.Add(new Vector2(350, 080));
            BricksPos.Add(new Vector2(450, 080));
            BricksPos.Add(new Vector2(550, 080));
            BricksPos.Add(new Vector2(650, 080));

            //adding in the positions of the second row of bricks
            BricksPos.Add(new Vector2(050, 110));
            BricksPos.Add(new Vector2(650, 110));
            BricksPos.Add(new Vector2(250, 110));
            BricksPos.Add(new Vector2(450, 110));

            //adding in the positions of the third row of bricks
            BricksPos.Add(new Vector2(050, 140));
            BricksPos.Add(new Vector2(150, 140));
            BricksPos.Add(new Vector2(250, 140));
            BricksPos.Add(new Vector2(350, 140));
            BricksPos.Add(new Vector2(450, 140));
            BricksPos.Add(new Vector2(550, 140));
            BricksPos.Add(new Vector2(650, 140));

            //adding in the position of the fourth row of bricks  
            BricksPos.Add(new Vector2(050, 170));
            BricksPos.Add(new Vector2(150, 170));
            BricksPos.Add(new Vector2(250, 170));
            BricksPos.Add(new Vector2(350, 170));
            BricksPos.Add(new Vector2(450, 170));
            BricksPos.Add(new Vector2(550, 170));
            BricksPos.Add(new Vector2(650, 170));

            //adding in the positions of the fifth row of bricks
            BricksPos.Add(new Vector2(050, 200));
            BricksPos.Add(new Vector2(150, 200));
            BricksPos.Add(new Vector2(250, 200));
            BricksPos.Add(new Vector2(350, 200));
            BricksPos.Add(new Vector2(450, 200));
            BricksPos.Add(new Vector2(550, 200));
            BricksPos.Add(new Vector2(650, 200));

            //adding in the positions of the sixth row of bricks
            BricksPos.Add(new Vector2(050, 230));
            BricksPos.Add(new Vector2(150, 230));
            BricksPos.Add(new Vector2(250, 230));
            BricksPos.Add(new Vector2(350, 230));
            BricksPos.Add(new Vector2(450, 230));
            BricksPos.Add(new Vector2(550, 230));
            BricksPos.Add(new Vector2(650, 230));

            //adding in the positions of the seventh row of bricks
            BricksPos.Add(new Vector2(050, 260));
            BricksPos.Add(new Vector2(150, 260));
            BricksPos.Add(new Vector2(250, 260));
            BricksPos.Add(new Vector2(350, 260));
            BricksPos.Add(new Vector2(450, 260));
            BricksPos.Add(new Vector2(550, 260));
            BricksPos.Add(new Vector2(650, 260));

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads in the textures of the ball, paddle and blocks
            Ball = Content.Load<Texture2D>("breakout ball");
            Paddle = Content.Load<Texture2D>("block breaker paddle");
            Block = Content.Load<Texture2D>("Breakout brick");
            Lives = Content.Load<SpriteFont>("Lives");
            PaddleBounce = Content.Load<SoundEffect>("PaddleBounce");
            BlockBounce = Content.Load<SoundEffect>("BlockBounce");

                
                // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //makes it so that if all the blocks are destroyed then the game will close adds the player another live and 100 points
            if (BricksPos.Count == 0)
            {
                BallPos = new Vector2(PaddlePos.X + Paddle.Width / 2, PaddlePos.Y - Paddle.Height / 2);
                BallSpeed = new Vector2(-1, -1);
                score += 100;

                //adding in the position of the first row of bricks
                BricksPos.Add(new Vector2(050, 080));
                BricksPos.Add(new Vector2(150, 080));
                BricksPos.Add(new Vector2(250, 080));
                BricksPos.Add(new Vector2(350, 080));
                BricksPos.Add(new Vector2(450, 080));
                BricksPos.Add(new Vector2(550, 080));
                BricksPos.Add(new Vector2(650, 080));

                //adding in the positions of the second row of bricks
                BricksPos.Add(new Vector2(050, 110));
                BricksPos.Add(new Vector2(650, 110));
                BricksPos.Add(new Vector2(350, 110));

                //adding in the positions of the third row of bricks
                BricksPos.Add(new Vector2(050, 140));
                BricksPos.Add(new Vector2(150, 140));
                BricksPos.Add(new Vector2(250, 140));
                BricksPos.Add(new Vector2(350, 140));
                BricksPos.Add(new Vector2(450, 140));
                BricksPos.Add(new Vector2(550, 140));
                BricksPos.Add(new Vector2(650, 140));

                //adding in the position of the fourth row of bricks  
                BricksPos.Add(new Vector2(050, 170));
                BricksPos.Add(new Vector2(150, 170));
                BricksPos.Add(new Vector2(250, 170));
                BricksPos.Add(new Vector2(350, 170));
                BricksPos.Add(new Vector2(450, 170));
                BricksPos.Add(new Vector2(550, 170));
                BricksPos.Add(new Vector2(650, 170));

                //adding in the positions of the fifth row of bricks
                BricksPos.Add(new Vector2(050, 200));
                BricksPos.Add(new Vector2(150, 200));
                BricksPos.Add(new Vector2(250, 200));
                BricksPos.Add(new Vector2(350, 200));
                BricksPos.Add(new Vector2(450, 200));
                BricksPos.Add(new Vector2(550, 200));
                BricksPos.Add(new Vector2(650, 200));

                //adding in the positions of the sixth row of bricks
                BricksPos.Add(new Vector2(050, 230));
                BricksPos.Add(new Vector2(150, 230));
                BricksPos.Add(new Vector2(250, 230));
                BricksPos.Add(new Vector2(350, 230));
                BricksPos.Add(new Vector2(450, 230));
                BricksPos.Add(new Vector2(550, 230));
                BricksPos.Add(new Vector2(650, 230));

                //adding in the positions of the seventh row of bricks
                BricksPos.Add(new Vector2(050, 260));
                BricksPos.Add(new Vector2(150, 260));
                BricksPos.Add(new Vector2(250, 260));
                BricksPos.Add(new Vector2(350, 260));
                BricksPos.Add(new Vector2(450, 260));
                BricksPos.Add(new Vector2(550, 260));
                BricksPos.Add(new Vector2(650, 260));

            Numberlives++;
            }

            if (Numberlives <= 0 || score >= 300)
            {
            }
            else
            {
                BallPos += BallSpeed;

                // has the left key controlling the direction it goes only allowing it to go left if it doesnt go off the screen
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    if (PaddlePos.X > 0)
                        PaddlePos.X -= 7;
                }

                // has the right key control the right direction but doesnt allow it to go off he screen
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    if (PaddlePos.X < 800 - Paddle.Width)
                        PaddlePos.X += 7;
                }

                

            }
            //creates the rectangles for the objects and adds collision properties to them
            Rectangle PaddleRectangle = new Rectangle((int)PaddlePos.X, (int)PaddlePos.Y, Paddle.Width, Paddle.Height);
            Rectangle BallRectangle = new Rectangle((int)BallPos.X, (int)BallPos.Y, Ball.Width, Ball.Height);

            // makes it so that the ball will bounce off of the paddle
            if (BallRectangle.Intersects(PaddleRectangle) && BallSpeed.Y < 0)
            {

                BallSpeed.Y = -BallSpeed.Y + 0.5f;
                PaddleBounce.Play();
               
            }

            if (BallRectangle.Intersects(PaddleRectangle) && BallSpeed.Y > 0)
            {

                BallSpeed.Y = -BallSpeed.Y - 0.5f;
                PaddleBounce.Play();
                
            }

            //add in the actual boundaries of the game on the top and he two sides but not the bottom

            if (BallPos.Y < 0 )
            {
                BallSpeed.Y = -BallSpeed.Y;
                
            }

            if (BallPos.X < 0 || BallPos.X > 800 - Ball.Width)
            {
                BallSpeed.X = -BallSpeed.X;
                
            }

            //tell the ball what to do if it goes below the paddle and off the screen

            if (BallPos.Y + Ball.Height > 800)
            {
                BallPos = new Vector2(PaddlePos.X + Paddle.Width / 2, PaddlePos.Y - Paddle.Height / 2);
                BallSpeed = new Vector2(-1, -1);
                Numberlives --;

            }

           

            //checks if the ball collides with the bricks
            for (int i = BricksPos.Count - 1; i >= 0; i--)
                {
                    Vector2 pos = BricksPos[i];


                    Rectangle brickRectangle = new Rectangle((int)pos.X, (int)pos.Y, Block.Width, Block.Height);
                    if (BallRectangle.Intersects(brickRectangle))
                    {
                        BallSpeed.Y = -BallSpeed.Y;
                        BricksPos.Remove(pos);
                        score++;
                        BlockBounce.Play();
                        break;
                    }

                }
                


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            //drawas all the objects to the game
            spriteBatch.Draw(Paddle, PaddlePos, Color.White);
            spriteBatch.Draw(Ball, BallPos, Color.White);
            spriteBatch.DrawString(Lives, "Lives = " + Numberlives, new Vector2(020,020), Color.White);
            spriteBatch.DrawString(Lives, "Score = " + score, new Vector2(580, 020), Color.White);

            //draws allthe bricks on the board
            foreach (var pos in BricksPos)
                spriteBatch.Draw(Block, pos, Color.Turquoise);

            // makes it so that if there are no more lives it displays some text to tell you
             if (Numberlives <= 0)
            {
                spriteBatch.DrawString(Lives, "You ran out of Lives, press [Esc] to leave", new Vector2(200, 400), Color.White);
             }

             if (score >= 300)
             {
                 spriteBatch.DrawString(Lives, "You won, GG press [Esc] to exit",  new Vector2(200, 400), Color.White);
             }

             PaddleBounce = Content.Load<SoundEffect>("PaddleBounce");
             BlockBounce = Content.Load<SoundEffect>("BlockBounce");


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
