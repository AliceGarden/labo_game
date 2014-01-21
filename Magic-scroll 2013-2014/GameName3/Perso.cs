using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Magic___Scroll
{

    public class Perso
    {
        Texture2D perso;
        Texture2D bottom;
        Texture2D mario;
        Animation animPersoG, animPersoD, animPersoH;
        public Rectangle rect;
        public Rectangle col;
        public Rectangle bottomCol;
        public Vector2 coordAbsolute;
        public int Y;
        public int X;
        private bool vaADroite;
        private bool vaAGauche;
        private bool vaEnHaut;

        public bool isDroite
        {
            get { return vaADroite; }
            set { vaADroite = value; }
        }
        public bool isGauche
        {
            get { return vaAGauche; }
            set { vaAGauche = value; }
        }
        public bool isHaut
        {
            get { return vaEnHaut; }
            set { vaEnHaut = value; }
        }
        public int exDirG;

        public bool isAnimated { get; set; }

        //int speed;

        public Perso()
        {
            //speed = 4;  // on dit que la vitesse est egale a 4, donc on se deplacera de 4 pixel a chaque fois que on appuit sur une touche
            vaAGauche = false;
            vaADroite = false;
            vaEnHaut = false;
            exDirG = 0; // 0:Droite, 1:gauche, 2:haut
            coordAbsolute = new Vector2();
        }

        public void LoadContent(ContentManager Content)
        {
            perso = Content.Load<Texture2D>("Terrain/boutDT");
            bottom = Content.Load<Texture2D>("Terrain/boutFT");
            mario = Content.Load<Texture2D>("Sprite magicienne");

            rect = new Rectangle(X, Y, 100, 150);
            col = new Rectangle(0, 0, 100, 130);
            bottomCol = new Rectangle(rect.X + 20, rect.Y + rect.Height - 1, rect.X + rect.Width - 20, 2);
            isAnimated = false;

            animPersoD = new Animation(false, "Sprite magicienne", rect, 12, 2, 1, 10);
            animPersoG = new Animation(false, "Sprite magicienne", rect, 12, 2, 2, 10);
            //animPersoD = new Animation(false, "Sprite magicienne marche1", rect, 12, 2, 1, 10);
            //animPersoG = new Animation(false, "Sprite magicienne marche1", rect, 12, 2, 2, 10);
            animPersoH = new Animation(false, "Sprite Magicienne dos", rect, 12, 1, 1, 10);
            animPersoD.LoadContent(Content);
            animPersoG.LoadContent(Content);
            animPersoH.LoadContent(Content);
        }

        public void Update(GameTime gameTime, GraphicsDevice gd)
        {
            col = new Rectangle(rect.X +30, rect.Y, 40, 130);
            bottomCol = new Rectangle(rect.X + 20, rect.Y + rect.Height - 1, rect.Width - 20, 3);
            animPersoD.AnimActived = false;
            animPersoG.AnimActived = false;
            animPersoH.AnimActived = false;
            if (vaADroite)
            {
                animPersoD.AnimActived = true;
                exDirG = 0;
            }
            else animPersoD.ReInitialize();
            if (vaAGauche)
            {
                animPersoG.AnimActived = true;
                exDirG = 1;
            }
            else animPersoG.ReInitialize();
            if (vaEnHaut)
            {
                animPersoH.AnimActived = true;
                exDirG = 2;
            }
            else animPersoH.ReInitialize();
            animPersoD.Update(gameTime, rect);
            animPersoG.Update(gameTime, rect);
            animPersoH.Update(gameTime, rect);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (vaADroite || exDirG == 0)
                animPersoD.Draw(spriteBatch);
            else if (vaAGauche || exDirG == 1)
                animPersoG.Draw(spriteBatch);
            else if (vaEnHaut || exDirG == 2)
                animPersoH.Draw(spriteBatch);
            //spriteBatch.Draw(bottom, col, Color.White);
            //spriteBatch.Draw(bottom, bottomCol, Color.White);
            spriteBatch.End();
            //else
            //{
            //    spriteBatch.Begin();
                
            //    // spriteBatch.Draw(bottom, bottomCol, Color.White);
            //    spriteBatch.Draw(mario, rect, new Rectangle(0, 0, mario.Width / 12, mario.Height / 2), Color.White);
            //    // spriteBatch.Draw(perso, rect, Color.White);    
            //    //spriteBatch.Draw(bottom, bottomCol, Color.White);
            //    spriteBatch.End();
            //}
        }

    }
}
