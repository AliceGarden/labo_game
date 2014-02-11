using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Magic___Scroll.Elements_Interactif
{
    class NuagePlateforme : ElementInteractifGeneral
    {
        Texture2D ma_texture;
        Texture2D autre;
        Rectangle Gauche;
        Rectangle Droite;
        List<Decor> Liste_decor;
        Perso personnage;
        public bool isDroite;
        public bool toucheDecor = true;
        int _variable = 0;
        int i = 0;
        public int DX = 2;
        bool BoolEau = false;
        bool BoolFeu = false;        

        public NuagePlateforme (int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 50, int _y = 100)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            base.ElementsIsActived = _isActive;
            base.gravityReady = false;
            base.ElementsIsActived = false;
            base.ElementsIsBloquant = false;
            isDroite = true;
            base.rect = new Rectangle(x, y - 25, screenWidth, screenHeight +25);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            Gauche = new Rectangle(x, y, 5, screenHeight);
            Droite = new Rectangle(x + screenWidth - 5, y, 5, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)
        {
            ma_texture = Content.Load<Texture2D>("ElementsInteractifs/Nuage");
            autre = Content.Load<Texture2D>("ElementsInteractifs/Boue");
        }

        public override void Update(GameTime gameTime)
        {
            
            if (ElementsIsActived)
            {
                foreach (Decor d in Liste_decor)
                {
                    if (isDroite) //on le déplace à gauche
                    {
                        if (_variable >= 20) // temps d'attente pour augmenter x du nuage.
                        {
                            DX = 2;
                            base.x += DX;
                            _variable = 0;
                            toucheDecor = false;
                        }
                        else
                            DX = 0;
                        _variable ++;
                        
                    }
                    if(d.col.Intersects(Droite) && isDroite)
                    {
                            DX = -5;
                            isDroite = false;
                            _variable = -2000; // attente
                            toucheDecor = true;
                            
                    }
                    if (!isDroite) //on le déplace à droite
                    {
                        if (_variable >= 20)
                        {
                            DX = 2;
                            base.x -= DX;
                            _variable = 0;
                            toucheDecor = false;
                        }
                        else
                            DX = 0;
                        _variable++;
                       
                    }
                    if (d.col.Intersects(Gauche) && !isDroite)
                    {                        
                        isDroite = true;
                        _variable = -2000; // attente
                        toucheDecor = true;
                    }

                }
            }
            if (ElementsIsAltered)
            {
                if (BoolEau == true)
                {
                    if (base.y < (i + screenHeight))
                    {
                        if (_variable >= 5) // temps d'attente pour augmenter x du nuage.
                        {
                            base.y += (1);
                            _variable = 0;
                        }
                        _variable++;
                    }
                    else
                    {
                        BoolEau = false;
                        ElementsIsAltered = false;
                    }
                }
                if (BoolFeu == true)
                {
                    if (base.y > (i - screenHeight))
                    {
                        if (_variable >= 5) // temps d'attente pour augmenter x du nuage.
                        {
                            base.y -= (1);
                            _variable = 0;
                        }
                        _variable++;
                    }
                    else
                    {
                        BoolFeu = false;
                        ElementsIsAltered = false;
                    }
                }
            }

            base.rect = new Rectangle(x, y - 25, screenWidth, screenHeight +25);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            Gauche = new Rectangle(x, y, 5, screenHeight);
            Droite = new Rectangle(x + screenWidth - 5, y, 5, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);

            base.Update(gameTime);
        }
        

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(autre, col, Color.White);            
            spriteBatch.Draw(ma_texture, rect, Color.White);            
            spriteBatch.End();
        }

        public override void actionFeu(Perso p)
        {
            i = base.y;
            ElementsIsAltered = true;
            BoolFeu= true;
            personnage = p;
        }
        public override void actionEau(Perso p)
        {
            i = base.y;
            ElementsIsAltered = true;
            BoolEau = true;
            personnage = p;
            
        }
        public override void actionTerre()
        {

        }
        public override void actionAir(Perso p)
        {
            
        }
        public override void actionAir(Perso p, List<Decor> liste_decor)
        {
            personnage = p;
            Liste_decor = liste_decor;
            ElementsIsActived = true;
        }
    }
}
