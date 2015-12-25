using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Shooter2D
{
    public class Player
    {
        Texture2D texture;
        Vector2 position;
        float speed;
        KeyboardState ks;

        public Player()
        {
            texture = null;
            position = new Vector2(20, 200);
            speed = 4;
        }

        public void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("heli");
        }

        public void Update(GameTime gameTime)
        {
            ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Up) || ks.IsKeyDown(Keys.W))
            {
                if (position.Y <= 0)
                {
                    position.Y -= 0;
                }
                else
                {
                    position.Y -= speed;
                }
            }
            if (ks.IsKeyDown(Keys.Down) || ks.IsKeyDown(Keys.S))
            {
                if (position.Y + texture.Height >= 340 + texture.Height)
                {
                    position.Y += 0;
                }
                else
                {
                    position.Y += speed;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
