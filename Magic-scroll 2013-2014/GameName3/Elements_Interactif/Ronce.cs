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
    class Ronce:ElementInteractifGeneral
    {
        Texture2D mon_ronce;
        Texture2D mon_grand_ronce;
        Texture2D mon_ronce_cramee;
        SoundEffect VentPousse; 

        public Ronce(int _screenWitdh, int _screenHeight, bool _isActive, bool _isAltered, Vector2 coordPositionAbsolu, int _x = 50, int _y = 50)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.ElementsIsBloquant = true;
            //base.ElementsIsActived = _isActive;
            base.ElementsIsAltered = _isAltered;
            base.ElementsIsActived = false;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
        }

        public override void LoadContent(ContentManager Content)
        {
            mon_ronce = Content.Load<Texture2D>("ElementsInteractifs/Ronce");
            mon_grand_ronce = Content.Load<Texture2D>("ElementsInteractifs/Grande Ronce");
            mon_ronce_cramee = Content.Load<Texture2D>("ElementsInteractifs/Ronce Cramé");
            VentPousse = Content.Load<SoundEffect>("foretW");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            if (base.ElementsIsActived)
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 3), (screenWidth / 2), screenHeight * 4);
                base.col = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 5) / 2), (screenWidth / 2), screenHeight * (7 / 2));
            }
            else
            {
                if (base.ElementsIsAltered)
                {
                    base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                }
                else
                {
                    base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                    base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (ElementsIsActived)
            {
                spriteBatch.Draw(mon_grand_ronce, rect, Color.White);
            }
            else
            {
                if (base.ElementsIsAltered)
                {
                    spriteBatch.Draw(mon_ronce_cramee, rect, Color.White);
                }
                else
                {
                    spriteBatch.Draw(mon_ronce, rect, Color.White);
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
                VentPousse.Play();
                deplacementElement(p);
            }
        }
    }
}
