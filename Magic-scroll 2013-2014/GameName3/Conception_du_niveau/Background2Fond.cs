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
    class Background2Fond
    {
        Texture2D mon_background3;   // texture dans laquelle on mettra l'image de notre fond 
        public int __x { get; set; }
        public int __y { get; set; }
        private int screenHeight;
        private int screenWidth;
        int TypeFond;
        public Rectangle rectf2;

        int valeur { get; set; }

        public Background2Fond(int _screenHeight, int _screenWidth,int typefond, int _ValeurSol)         // constructeur
        {
            __x = 0;
            __y = 0;
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
                    mon_background3 = Content.Load<Texture2D>("Background/Foret-3"); // on applique l'image "background.jpg" a notre background
                    break;
                case 1:
                    mon_background3 = Content.Load<Texture2D>("Background/Foret-3");
                    break;
                case 2:
                    mon_background3 = Content.Load<Texture2D>("Background/Volcan-3");
                    break;
            }
            

            
        }

        public void Update(GameTime gametime)
        {
            rectf2 = new Rectangle(__x, __y, 20, 20);
            if (rectf2.X < -1)
            {
                __x += (mon_background3.Width);
                rectf2.X += mon_background3.Width;
            }
            if (rectf2.X > screenWidth)
            {
                __x -= (mon_background3.Width);
                rectf2.X -= mon_background3.Width;
            }
        }

        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            //spriteBatch.Begin();        // on pose notre crayon
            spriteBatch.Draw(mon_background3, new Rectangle(__x, valeur*100 + __y- mon_background3.Height, mon_background3.Width, mon_background3.Height), Color.White);  // on dessine le fond
            spriteBatch.Draw(mon_background3, new Rectangle(__x - mon_background3.Width, valeur*100 + __y- mon_background3.Height, mon_background3.Width, mon_background3.Height), Color.White);  // on dessine le fond   
            //spriteBatch.Draw(mon_background3, new Rectangle(__x + mon_background3.Width, (screenHeight - mon_background3.Height - 100/*(mon_background3.Height * 4 / 5)*/), mon_background3.Width, mon_background3.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.Draw(mon_background, new Rectangle(x + mon_background.Width + mon_background.Width + mon_background.Width, y, mon_background.Width, mon_background.Height), Color.White);  // on dessine le fond 
            //spriteBatch.End();          /// on leve notre crayon
        }
    }

}

