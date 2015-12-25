using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

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

        Texture2D playButton;
        Texture2D quitButton;
        Rectangle playRect;
        Rectangle quitRect;

        GameState gameState;

        SoundEffect mMusic;
        SoundEffectInstance menuMusic;
        SoundEffect pMusic;
        SoundEffectInstance playingMusic;

        Texture2D quitBtn1;
        Texture2D playBtn1;

        MouseState mouse;
        Vector2 mousePosition;

        Texture2D bg;

        Player p = new Player();

        float volume = 0.4f;

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
            p.LoadContent(Content);

            gameState = GameState.MENU;

            title = Content.Load<Texture2D>("title");
            playBtn = Content.Load<Texture2D>("playButton");
            quitBtn = Content.Load<Texture2D>("quitButton");

            playRect = new Rectangle(335, 150, 250, 50);
            quitRect = new Rectangle(335, 250, 250, 50);

            mMusic = Content.Load<SoundEffect>("menuMusic");
            menuMusic = mMusic.CreateInstance();
            menuMusic.IsLooped = true;
            pMusic = Content.Load<SoundEffect>("playingMusic");
            playingMusic = pMusic.CreateInstance();
            playingMusic.IsLooped = true;
            menuMusic.Volume = volume;
            playingMusic.Volume = volume;

            quitBtn1 = Content.Load<Texture2D>("quitButton1");
            playBtn1 = Content.Load<Texture2D>("playButton1");

            bg = Content.Load<Texture2D>("background");
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouse = Mouse.GetState();
            mousePosition = new Vector2(mouse.X, mouse.Y);

            switch (gameState)
            {
                case GameState.MENU:
                    {
                        menuMusic.Play();

                        if (playRect.Contains(mousePosition))
                        {
                            playButton = playBtn1;
                            if (mouse.LeftButton == ButtonState.Pressed)
                            {
                                menuMusic.Stop();
                                gameState = GameState.PLAYING;
                            }
                        }
                        else
                        {
                            playButton = playBtn;
                        }
                        if (quitRect.Contains(mousePosition))
                        {
                            quitButton = quitBtn1;
                            if (mouse.LeftButton == ButtonState.Pressed)
                            {
                                Exit();
                            }
                        }
                        else
                        {
                            quitButton = quitBtn;
                        }

                        break;
                    }
                case GameState.PLAYING:
                    {
                        playingMusic.Play();
                        p.Update(gameTime);
                        break;
                    }
            }

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
                        spriteBatch.Draw(playButton, new Vector2(355, 150), Color.White);
                        spriteBatch.Draw(quitButton, new Vector2(355, 250), Color.White);
                        spriteBatch.End();
                        break;
                    }
                case GameState.PLAYING:
                    {
                        spriteBatch.Begin();
                        spriteBatch.Draw(bg, Vector2.Zero, Color.White);
                        p.Draw(spriteBatch);
                        spriteBatch.End();
                        break;
                    }
                
                }

            base.Draw(gameTime);
        }
    }
}
