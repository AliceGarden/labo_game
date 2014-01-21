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
    class Background2Plan
    {
        Texture2D mon_background1;   // texture dans laquelle on mettra l'image de notre fond 
        public int ax { get; set; }
        public int ay { get; set; }
        private int screenHeight;

        public Background2Plan(int _screenHeight)         // constructeur
        {
            screenHeight = _screenHeight;
            ax = 0;
            ay = 0;

        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            mon_background1 = Content.Load<Texture2D>("Background/Foret-2"); // on applique l'image "background.jpg" a notre background
        }

        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            //spriteBatch.Begin();        // on pose notre crayon
            //spriteBatch.Draw(mon_background1, new Rectangle(ax, ay, mon_background1.Width * 3, mon_background1.Height), Color.White);  // on dessine le fond
            //spriteBatch.Draw(mon_background1, new Rectangle(ax - 10                        , /*ay-50- */(screenHeight - (mon_background1.Height * 4 / 5)), mon_background1.Width, mon_background1.Height), Color.White);  // on dessine le fond   
            //spriteBatch.Draw(mon_background1, new Rectangle(ax - 10 + mon_background1.Width, /*ay-50- */(screenHeight - (mon_background1.Height * 4 / 5)), mon_background1.Width, mon_background1.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.End();          /// on leve notre crayon
        }
    }

}
