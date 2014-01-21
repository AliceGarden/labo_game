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
    class Background3Fond
    {
        Texture2D mon_background5;   // texture dans laquelle on mettra l'image de notre fond 
        public int bx { get; set; }
        public int by { get; set; }
        private int screenHeight;

        public Background3Fond(int _screenHeight)         // constructeur
        {
            bx = 0;
            by = 0;
            screenHeight = _screenHeight;
        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            mon_background5 = Content.Load<Texture2D>("Foret-5"); // on applique l'image "background.jpg" a notre background
        }

        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            //spriteBatch.Begin();        // on pose notre crayon
            //spriteBatch.Draw(mon_background5, new Rectangle(bx - mon_background5.Width, (screenHeight - (mon_background5.Height * 4 / 5)), mon_background5.Width, mon_background5.Height), Color.White);  // on dessine le fond
            //spriteBatch.Draw(mon_background5, new Rectangle(bx, (screenHeight - (mon_background5.Height * 4 / 5)), mon_background5.Width, mon_background5.Height), Color.White);  // on dessine le fond   
            //spriteBatch.Draw(mon_background5, new Rectangle(bx + mon_background5.Width, (screenHeight - (mon_background5.Height * 4 / 5)), mon_background5.Width, mon_background5.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.End();          /// on leve notre crayon
        }
    }

}