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
using Windows.UI.Xaml;

namespace Magic___Scroll
{
    class Background1Fond
    {
        Texture2D mon_background;   // texture dans laquelle on mettra l'image de notre fond 
        public int x { get; set; }
        public int y { get; set; }
        private int screenHeight;
        private int screenWidth;
        public Rectangle rectf1;
        int TypeFond;
        int valeur { get; set; }

        public Background1Fond(int _screenHeight, int _screenWidth,int typefond, int _ValeurSol)         // constructeur
        {
            x = 0;
            y = 0;
            screenHeight = _screenHeight;
            
            screenWidth = _screenWidth;
            TypeFond = typefond;
            valeur = _ValeurSol;
        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            
            switch (TypeFond)
            {
                case 0:
                    mon_background = Content.Load<Texture2D>("Background/Foret-4"); // on applique l'image "background.jpg" a notre background
                    break;
                case 1:
                    mon_background = Content.Load<Texture2D>("Background/Foret-4");
                    break;
                case 2:
                    mon_background = Content.Load<Texture2D>("Background/Volcan-4");
                    break;
            }
            
        }
        public void Update(GameTime gametime) // pendant le chargement :
        {
            rectf1 = new Rectangle(x, y , 20, 20);
            if (rectf1.X < -1)
            {
                x += (mon_background.Width);
                rectf1.X += mon_background.Width;
            }
            if (rectf1.X > screenWidth)
            {
                x -= (mon_background.Width);
                rectf1.X -= mon_background.Width;
            }

        }

        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            //spriteBatch.Begin();        // on pose notre crayon
            spriteBatch.Draw(mon_background, new Rectangle(x , valeur*100 - mon_background.Height+y , mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond
            spriteBatch.Draw(mon_background, new Rectangle(x - mon_background.Width, valeur*100 - mon_background.Height + y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond   
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width, (screenHeight - (mon_background.Height/** 4 / 5*/ - 50)), mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.End();          /// on leve notre crayon
        }
    }

}
