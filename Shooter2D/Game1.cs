using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Shooter2D
{
    enum GameState
    {
        MENU, PLAYING
    }

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D title;
        Texture2D playBtn;
        Texture2D quitBtn;

        GameState gameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;
            graphics.ApplyChanges();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            gameState = GameState.MENU;

            title = Content.Load<Texture2D>("title");
            playBtn = Content.Load<Texture2D>("playButton");
            quitBtn = Content.Load<Texture2D>("quitButton");
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (gameState)
                {
                case GameState.MENU:
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(title, Vector2.Zero, Color.White);
                        spriteBatch.Draw(playBtn, new Vector2(355, 150), Color.White);
                        spriteBatch.Draw(quitBtn, new Vector2(355, 250), Color.White);
                        spriteBatch.End();
                        break;
                    }
                case GameState.PLAYING:
                    {
                        spriteBatch.Begin();

                        spriteBatch.End();
                        break;
                    }
                
                }

            base.Draw(gameTime);
        }
    }
}
