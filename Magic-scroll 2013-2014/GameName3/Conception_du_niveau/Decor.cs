using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll
{
    public class Decor
    {
        Texture2D fond;   // texture dans laquelle on mettra l'image de notre fond 
        public int x { get; set; }
        public int y { get; set; }
        private int screenHeight;
        private int screenWidth;
        public char typeDecor { get; set; }
        public Rectangle rect { get; set; }
        public Rectangle col { get; set; }
        public Rectangle bottomcol { get; set; }
        public Rectangle headCol { get; set; }
        public Vector2 coordPositionAbsolu { get; set; }
        public Decor(char _typeDecor, int _screenHeight, int _screenWidth, Vector2 _coordPositionAbsolu, int _x = 50, int _y = 100)         // constructeur
        {
            typeDecor = _typeDecor;
            x = _x; // la position en X -------
            y = _y; // la position vertical
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
            rect = new Rectangle(x, y, screenWidth, screenHeight);
            col = new Rectangle(x, y, 50, 50);
            bottomcol = new Rectangle(x, y, screenWidth, 5);
            headCol = new Rectangle(x,y-(screenHeight/2),screenWidth,(screenHeight/2));
            coordPositionAbsolu = _coordPositionAbsolu;
        }

        public void LoadContent(ContentManager Content)
        {
            #region switch de la sélection de la texture pour le niveau
            switch (typeDecor)
            {
                case 'A':
                    fond = Content.Load<Texture2D>("Terrain/boutDT");
                    break;
                case 'B':
                    fond = Content.Load<Texture2D>("Terrain/bout1T");
                    break;
                case 'C':
                    fond = Content.Load<Texture2D>("Terrain/bout2T");
                    break;
                case 'D':
                    fond = Content.Load<Texture2D>("Terrain/bout3T");
                    break;
                case 'E':
                    fond = Content.Load<Texture2D>("Terrain/boutFT");
                    break;
                case 'F':
                    fond = Content.Load<Texture2D>("Terrain/boutDE");
                    break;
                case 'G':
                    fond = Content.Load<Texture2D>("Terrain/bout1E");
                    break;
                case 'H':
                    fond = Content.Load<Texture2D>("Terrain/bout2E");
                    break;
                case 'I':
                    fond = Content.Load<Texture2D>("Terrain/bout3E");
                    break;
                case 'J':
                    fond = Content.Load<Texture2D>("Terrain/boutFE");
                    break;
                case 'K':
                    fond = Content.Load<Texture2D>("Terrain/boutDF");
                    break;
                case 'L':
                    fond = Content.Load<Texture2D>("Terrain/bout1F");
                    break;
                case 'M':
                    fond = Content.Load<Texture2D>("Terrain/bout2F");
                    break;
                case 'N':
                    fond = Content.Load<Texture2D>("Terrain/bout3F");
                    break;
                case 'O':
                    fond = Content.Load<Texture2D>("Terrain/boutFF");
                    break;
                case 'P':
                    fond = Content.Load<Texture2D>("Terrain/boutDA");
                    break;
                case 'Q':
                    fond = Content.Load<Texture2D>("Terrain/bout1A");
                    break;
                case 'R':
                    fond = Content.Load<Texture2D>("Terrain/bout2A");
                    break;
                case 'S':
                    fond = Content.Load<Texture2D>("Terrain/bout3A");
                    break;
                case 'T':
                    fond = Content.Load<Texture2D>("Terrain/boutFA");
                    break;
                case 'U':
                    fond = Content.Load<Texture2D>("Terrain/boutDG");
                    break;
                case 'V':
                    fond = Content.Load<Texture2D>("Terrain/bout1G");
                    break;
                case 'W':
                    fond = Content.Load<Texture2D>("Terrain/bout32G");
                    break;
                case 'X':
                    fond = Content.Load<Texture2D>("Terrain/bout3G");
                    break;
                case 'Y':
                    fond = Content.Load<Texture2D>("Terrain/boutFG");
                    break;
            }
            #endregion
        }

        public void Update(GameTime gameTime)
        {
            rect = new Rectangle(x, y, screenWidth, screenHeight);
            col = new Rectangle(x, y, screenWidth, screenHeight);
            bottomcol = new Rectangle(x, y, screenWidth, 4);
            headCol = new Rectangle(x, y - (screenHeight / 4), screenWidth, (screenHeight / 4) -1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(fond, rect, Color.White);
            //spriteBatch.Draw(fond, bottomcol, Color.White);
            spriteBatch.End();
        }
    }
}
