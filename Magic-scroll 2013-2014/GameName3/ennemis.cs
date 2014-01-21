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
using Magic___Scroll.Elements_Interactif;

namespace Magic___Scroll
{
    public class Ennemis
    {
        Texture2D creature;   // texture dans laquelle on mettra l'image de notre fond 
        Animation animPersoG, animPersoD;
        public int x { get; set; }
        public int y { get; set; }
        private int screenHeight;
        private int screenWidth;
        public bool gravityReady = true;
        public char typeEnnemis { get; set; }
        public Rectangle rect { get; set; }
        public Rectangle col { get; set; }
        public Rectangle bottomCol { get; set; }
        public Rectangle miniMapCoord { get; set; }
        public Vector2 coordPositionAbsolu { get; set; }
        public bool bottomCollisionIsTrue;
        public int initX, initY;
        public bool isRight = false;
        public bool isLeft = false;
        protected int speed;

        public Ennemis(char _typeEnnemis, int _screenHeight, int _screenWidth, Vector2 _coordPositionAbsolu, int _x = 50, int _y = 100)         // constructeur
        {
            typeEnnemis = _typeEnnemis;
            x = _x; // la position en X -------
            y = _y; // la position vertical
            initX = x;
            initY = y;
            screenHeight = _screenHeight;
            screenWidth = _screenWidth;
            rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            coordPositionAbsolu = _coordPositionAbsolu;
        }

        public void LoadContent(ContentManager Content)
        {
            #region sélection de la texture et des animations pour l'ennemi
            switch (typeEnnemis)
            {
                case '1':
                    creature = Content.Load<Texture2D>("Ennemis/Ennemi Terre");
                    animPersoD = new Animation(false, "Ennemis/Sprite ennemi terre", rect, 8, 2, 1, 8);
                    animPersoG = new Animation(false, "Ennemis/Sprite ennemi terre", rect, 8, 2, 2, 8);
                    break;
                case '2':
                    creature = Content.Load<Texture2D>("Ennemis/Ennemi Feu");
                    animPersoD = new Animation(false, "Ennemis/Sprite ennemi feu", rect, 8, 2, 1, 8);
                    animPersoG = new Animation(false, "Ennemis/Sprite ennemi feu", rect, 8, 2, 2, 8);
                    break;
                case '3':
                    creature = Content.Load<Texture2D>("Terrain/bout2T");
                    animPersoD = new Animation(false, "Sprite magicienne", rect, 8, 2, 1, 8);
                    animPersoG = new Animation(false, "Sprite magicienne", rect, 8, 2, 2, 8);
                    break;
                case '4':
                    creature = Content.Load<Texture2D>("Terrain/bout3T");
                    animPersoD = new Animation(false, "Sprite magicienne", rect, 8, 2, 1, 8);
                    animPersoG = new Animation(false, "Sprite magicienne", rect, 8, 2, 2, 8);
                    break;
                case '5':
                    creature = Content.Load<Texture2D>("Terrain/boutFT");
                    animPersoD = new Animation(false, "Sprite magicienne", rect, 8, 2, 1, 8);
                    animPersoG = new Animation(false, "Sprite magicienne", rect, 8, 2, 2, 8);
                    break;

            }
            animPersoD.LoadContent(Content);
            animPersoG.LoadContent(Content);
        }
            #endregion

        public void Update(GameTime gameTime)
        {
            if (gravityReady)
            {
                if (!bottomCollisionIsTrue)
                    y += (speed + 4);
            }
            rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            
            if (bottomCollisionIsTrue) //si l'ennemi ne chute pas
            {
                if (x <= initX + 100 && isRight) //on le déplace à gauche
                {
                    x += 1;
                }
                else
                {
                    isRight = false;
                    isLeft = true;
                }

                if (x >= initX - 100 && !isRight) //on le déplace à droite
                {
                    x -= 1;
                }
                else
                {
                    isRight = true;
                    isLeft = false;
                }
            }

            #region Animation de l'ennemi en fonction de sa direction
            animPersoD.AnimActived = false;
            animPersoG.AnimActived = false;
            if (isRight)
            {
                animPersoD.AnimActived = true;
                animPersoG.ReInitialize();
            }
            if (isLeft)
            {
                animPersoG.AnimActived = true;
                animPersoD.ReInitialize();
            }
            animPersoD.Update(gameTime, rect);
            animPersoG.Update(gameTime, rect);
            #endregion
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (isRight)
                animPersoD.Draw(spriteBatch);
            else if (isLeft)
                animPersoG.Draw(spriteBatch);
            else
            {
                spriteBatch.Draw(creature, rect, Color.White);
                spriteBatch.End();
            }
        }


        public bool bottomCollision(List<Decor> _liste_decor_bottomCol, List<ElementInteractifGeneral> _liste_element_interractif)
        {
            bool collision = false;
            foreach (Decor d in _liste_decor_bottomCol)
            {
                if (bottomCol.Intersects(d.bottomcol))
                    collision = true;
                else
                {
                    foreach (ElementInteractifGeneral b in _liste_element_interractif)
                    {
                        if (b is BlocFriable)
                        {
                            if (bottomCol.Intersects(b.bottomCol))
                                collision = true;
                        }
                    }
                }
            }
            return collision;
        }
    }
}