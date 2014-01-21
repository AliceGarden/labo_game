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
    class Bambou:ElementInteractifGeneral
    {
        Texture2D mon_bambou;
        Texture2D mon_grand_bambou;
        Texture2D mon_bambou_cramee;
        Texture2D testcoll;
        Animation animGrandir;
        //bool animfinie;

        public Bambou(int _screenWitdh, int _screenHeight, bool _isActive, bool _isAltered, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            //animfinie = true;
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            base.ElementsIsAltered = _isAltered;
            base.ElementsIsActived = false;
            base.ElementsIsBloquant = false;
            base.headCol = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
            animGrandir = new Animation(false, "ElementsInteractifs/Sprite Banbou", new Rectangle(x + (screenWidth / 4), y - (screenHeight * 3), (screenWidth / 2), screenHeight * 4), 10, 1, 1, 5);
        }

        public override void LoadContent(ContentManager Content)
        {
            animGrandir.LoadContent(Content);
            testcoll = Content.Load<Texture2D>("Terrain/bout2T");
            mon_bambou = Content.Load<Texture2D>("ElementsInteractifs/PetitBambou");
            mon_grand_bambou = Content.Load<Texture2D>("ElementsInteractifs/bambou");
            mon_bambou_cramee = Content.Load<Texture2D>("ElementsInteractifs/Ronce");
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            if (base.ElementsIsActived)
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 3), (screenWidth / 2), screenHeight * 4);
                base.headCol = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 2)+(screenHeight/4)) + 1, (screenWidth / 2), (screenHeight /4 )-2);
                base.col = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 2) + 2, (screenWidth / 2), (screenHeight * 3) + 10);
                animGrandir.Update(gameTime, base.rect);
            }
            else
            {
                if (base.ElementsIsAltered)
                {
                    base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    ElementsIsBloquant = true;
                }
                else
                {
                    base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    ElementsIsBloquant = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            //spriteBatch.Draw(testcoll, headCol, Color.White);
            
            if (base.ElementsIsActived)
            {
                if (animGrandir.AnimActived)
                    animGrandir.Draw(spriteBatch);
                else
                    spriteBatch.Draw(mon_grand_bambou, rect, Color.White);
                //spriteBatch.Draw(testcoll, col, Color.White);
            }
            else
            {
                if (base.ElementsIsAltered)
                {
                    spriteBatch.Draw(mon_bambou_cramee, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(mon_bambou, rect, Color.White);
                }
            }
            spriteBatch.End();
        }

        public override void actionFeu()
        {
            if (ElementsIsAltered || !ElementsIsActived)
            {
                supprimerElement();
            }
            else
            {
                ElementsIsAltered = true;
                ElementsIsActived = false;
            }
        }
        public override void actionEau()
        {
            if (!ElementsIsAltered)
            {
                animGrandir.AnimActived = true;
                activerEtatSecondaire();
            }
        }
        public override void actionTerre()
        {
            if (ElementsIsAltered)
            {
                ElementsIsAltered = false;
            }
        }
        public override void actionAir(Perso p)
        {
            if (!ElementsIsActived)
            {
                deplacementElement(p);
            }
        }
    }
}
