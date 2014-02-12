using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Elements_Interactif
{
    class FeuCamp : ElementInteractifGeneral
    {
        Animation mon_feu_camp;
        Animation feuCampExtinction;
        Texture2D mon_feu_eteint;
        Texture2D decors;
        Rectangle colFlamme;
        bool seDeplace = false;
        bool seDeplaceVersGauche = false;
        int  deplacementEnCours = 0;

        public FeuCamp(int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            base.ElementsIsActived = _isActive;
            base.ElementsIsBloquant = true;
            base.rect = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 3), (screenWidth / 2), screenHeight * 4);
            base.col = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 5) / 2), (screenWidth / 2), screenHeight * (7 / 2));
            //colFlamme = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 5) / 2), 0, 0);
            colFlamme = new Rectangle(x - (screenWidth), y, (screenWidth) * 3, screenHeight);
            mon_feu_camp = new Animation(true, "ElementsInteractifs/Feu de camp sprite", base.rect, 4, 1, 1, 5);
            feuCampExtinction = new Animation(true, "ElementsInteractifs/Feu de camp etein sprite", base.rect, 14, 1, 1, 8); // true ?, l'élément anime, son rectangle,nbr images,
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)
        {
            mon_feu_camp.LoadContent(Content);
            feuCampExtinction.LoadContent(Content);
            mon_feu_eteint = Content.Load<Texture2D>("ElementsInteractifs/Feu de camp etein sprite");
            decors = Content.Load<Texture2D>("Terrain/bout2T");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            if (base.ElementsIsActived)
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);                
                base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                if (!seDeplace)
                    colFlamme = new Rectangle(x - (screenWidth), y, (screenWidth) * 3, screenHeight);
            }
            else
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            }
            mon_feu_camp.AnimActived = true;
            mon_feu_camp.Update(gameTime, base.rect);
            if (feuCampExtinction.AnimActived)
                feuCampExtinction.Update(gameTime, base.rect);
       

        if (seDeplace)
            {
                if (seDeplaceVersGauche)
                {
                    if ((-deplacementEnCours) < screenWidth)
                    {
                        deplacementEnCours -= 2;
                        colFlamme.X -= 2;
                    }
                    else seDeplace = false;
                }

                if (!seDeplaceVersGauche)
                {
                    if (deplacementEnCours < screenWidth)
                    {
                        deplacementEnCours += 2;
                        colFlamme.X += 2;
                    }
                    else seDeplace = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (base.ElementsIsActived)
            {
                mon_feu_camp.Draw(spriteBatch);
            }
            else
            {
                if (feuCampExtinction.AnimActived == true)
                {
                    feuCampExtinction.Draw(spriteBatch);
                }
                else
                {
                    spriteBatch.Draw(mon_feu_eteint, rect, new Rectangle((mon_feu_eteint.Width * 13) / 14, 0, mon_feu_eteint.Width / 14, mon_feu_eteint.Height), Color.White);
                }
            }
            spriteBatch.Draw(decors, colFlamme, Color.White);
            spriteBatch.End();
        }

        public override void actionFeu()
        {
            if (!base.ElementsIsActived)
            {
                activerEtatSecondaire();
                base.ElementsIsBloquant = true;
            }
        }
        public override void actionEau()
        {
            if (base.ElementsIsActived)
            {
                desactiverEtatSecondaire();

                feuCampExtinction.AnimActived = true;
                base.ElementsIsBloquant = false;
            }
        }
        public override void actionTerre()
        {
            if (base.ElementsIsActived)
            {
                desactiverEtatSecondaire();
                base.ElementsIsBloquant = false;
            }
        }
        public override void actionAir(Perso p)
        {
            if (!ElementsIsActived)
            {
                deplacementElement(p);
            }
            else
            {
                deplacementEnCours = 0;
                seDeplace = true;
                if (p.rect.X < x)
                {
                    seDeplaceVersGauche = false;
                }
                else seDeplaceVersGauche = true;
            }
        }
    }
}
