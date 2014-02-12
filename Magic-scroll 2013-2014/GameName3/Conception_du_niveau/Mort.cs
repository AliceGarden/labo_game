using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Conception_du_niveau
{
    class Mort
    {
        public int x { get; set; }
        public int y { get; set; }
        private int screenHeight;
        private int screenWidth;
        public Rectangle rect { get; set; }
        public Rectangle downRect { get; set; }
        Texture2D mort;

        public Mort(int _screenWitdh, int _screenHeight, int _x, int _y)
        {
            x = _x;
            y = _y;
            screenWidth = (_screenWitdh*10);
            screenHeight = _screenHeight;
            rect = new Rectangle(x - (screenWidth / 5), y, screenWidth, screenHeight);
            downRect = new Rectangle(x - (screenWidth / 5), y +(screenHeight) , screenWidth, 1);
        }
        public void LoadContent(ContentManager Content)
        {
            mort = Content.Load<Texture2D>("Terrain/bout2T");
        }

        public void Update(GameTime gameTime)
        {
            rect = new Rectangle(x - (screenWidth), y, screenWidth * 2, screenHeight);
            downRect = new Rectangle(x - (screenWidth / 5), y + (screenHeight), screenWidth, 1);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mort, rect, Color.White);
            spriteBatch.End();
        }
    }
}
