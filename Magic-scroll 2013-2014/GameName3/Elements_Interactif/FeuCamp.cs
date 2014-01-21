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
            mon_feu_camp = new Animation(true, "ElementsInteractifs/Feu de camp sprite", base.rect, 4, 1, 1, 5);
            feuCampExtinction = new Animation(true, "ElementsInteractifs/Feu de camp etein sprite", base.rect, 14, 1, 1, 8);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)
        {
            mon_feu_camp.LoadContent(Content);
            feuCampExtinction.LoadContent(Content);
            mon_feu_eteint = Content.Load<Texture2D>("ElementsInteractifs/Feu de camp etein sprite");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            if (base.ElementsIsActived)
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                base.col = new Rectangle(x - (screenWidth), y - screenHeight , (screenWidth)*2 , screenHeight * 2);            
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
            //spriteBatch.Draw(mon_feu_eteint, col, Color.White);
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

        }
    }
}
