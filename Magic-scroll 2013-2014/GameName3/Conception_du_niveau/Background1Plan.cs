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
    class Background1Plan
    {
        Texture2D mon_background2;   // texture dans laquelle on mettra l'image de notre fond 
        //Texture2D test;
        public int x { get; set; }
        public int y { get; set; }
        private int screenHeight;
        private int screenWidth;
        int TypeFond;
        public Rectangle rectp1;
        int valeur { get; set; }
        

        public Background1Plan(int _screenHeight, int _screenWidth,int  Typefond, int _ValeurSol)         // constructeur
        {
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
            x = 0;
            y = 0;
            TypeFond = Typefond;
            valeur = _ValeurSol;
            

        }

        public void LoadContent(ContentManager Content) // pendant le chargement :
        {
            

            switch (TypeFond)
            {
                case 0:
                    mon_background2 = Content.Load<Texture2D>("Background/Foret-1"); // on applique l'image "background.jpg" a notre background
                    break;
                case 1:
                    mon_background2 = Content.Load<Texture2D>("Background/Foret-1");
                    break;
                case 2:
                    mon_background2 = Content.Load<Texture2D>("Background/Volcan-1");
                    break;
            }
            
            //test = Content.Load<Texture2D>("Logo");

            
            
        }

        public void Update(GameTime gametime) // pendant le chargement :
        {
            rectp1 = new Rectangle(x, y, 20, 20);
            if (rectp1.X < -1)
            {
                x += (mon_background2.Width);
                rectp1.X += mon_background2.Width;
            }
            if (rectp1.X > screenWidth)
            {
                x -= (mon_background2.Width);
                rectp1.X -= mon_background2.Width;
            }
           
        }
        public void Draw(SpriteBatch spriteBatch)    // on dessine notre fond ( avant le perso pour pas l'ecraser )
        {
            //spriteBatch.Begin();        // on pose notre crayon
            spriteBatch.Draw(mon_background2, new Rectangle(x , valeur*100 +y- mon_background2.Height, mon_background2.Width, mon_background2.Height), Color.White);  // on dessine le fond
            spriteBatch.Draw(mon_background2, new Rectangle(x - mon_background2.Width, valeur*100 +y- mon_background2.Height, mon_background2.Width, mon_background2.Height), Color.White);  // on dessine le fond                           
            //spriteBatch.End();          /// on leve notre crayon
        }
    }
}
