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
    class BlocFriable : ElementInteractifGeneral
    {
        Texture2D mon_bloc_friable;
        Texture2D ma_boue;
        Texture2D trou;
        Texture2D mon_bloc;
        Animation animEmbouer;
        Animation animSolidif;
        Animation animReconstruction;
        Animation animCassure;
        SoundEffect BlocCasse; 
        Int16 choixSolus;
        private bool alreadyBreak;
        
        public BlocFriable(int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 50, int _y = 100)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            base.ElementsIsActived = false;
            base.ElementsIsBloquant = false;
            base.EtatFinale = false;
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y, screenWidth, screenHeight);
            base.gravityReady = false;
            animEmbouer = new Animation(false, "ElementsInteractifs/Sprite Terrain boue", base.rect, 6, 1, 1, 6);
            animSolidif = new Animation(false, "ElementsInteractifs/Sprite Terrain solidifie", base.rect, 6, 1, 1, 6);
            animReconstruction = new Animation(false, "ElementsInteractifs/Sprite Terrain reconstruction", base.rect, 6, 1, 1, 6);
            animCassure = new Animation(false, "ElementsInteractifs/Sprite Terrain cassure", new Rectangle(base.rect.X, base.rect.Y, base.rect.Width, base.rect.Height + _screenHeight), 6, 1, 1, 6);
            choixSolus = 0;
            alreadyBreak = false;
            
        }

        public override void LoadContent(ContentManager Content)
        {
            animEmbouer.LoadContent(Content);
            animSolidif.LoadContent(Content);
            animReconstruction.LoadContent(Content);
            animCassure.LoadContent(Content);
            mon_bloc_friable = Content.Load<Texture2D>("ElementsInteractifs/Terrain friable");
            ma_boue = Content.Load<Texture2D>("ElementsInteractifs/Boue");
            mon_bloc = Content.Load<Texture2D>("Terrain/bout3T");
            trou = Content.Load<Texture2D>("ElementsInteractifs/Terrain friable detruit");
            BlocCasse = Content.Load<SoundEffect>("terre qui casse");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            rect = new Rectangle(x, y, screenWidth, screenHeight);
            col = new Rectangle(x, y, screenWidth, screenHeight);
            if (base.ElementsIsAltered)
            {
                if (!alreadyBreak)
                    animCassure.AnimActived = true;
                animCassure.Update(gameTime, new Rectangle(base.rect.X, base.rect.Y, base.rect.Width, base.rect.Height + screenHeight));
                bottomCol = new Rectangle(0, 0, 0, 0);
                alreadyBreak = true;
            }
            else
            {
                bottomCol = new Rectangle(x, y, screenWidth, screenHeight);
            }
            if (base.ElementsIsActived)
                animEmbouer.Update(gameTime, base.rect);
            if (choixSolus == 1)
                animSolidif.Update(gameTime, base.rect);
            if (choixSolus == 2)
                animReconstruction.Update(gameTime, base.rect);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (base.ElementsIsActived)
            {
                if (animEmbouer.AnimActived)
                    animEmbouer.Draw(spriteBatch);
                else
                spriteBatch.Draw(ma_boue, rect, Color.White);
            }
            else
            {
                if (base.ElementsIsAltered)
                {
                    if (animCassure.AnimActived)
                        animCassure.Draw(spriteBatch);
                    else
                        spriteBatch.Draw(trou, rect, Color.White);
                }
                else
                {
                    if (EtatFinale)
                    {
                        if (choixSolus == 1)
                            if (animSolidif.AnimActived)
                                animSolidif.Draw(spriteBatch);
                            else animSolidif.DrawLastImage(spriteBatch);
                        else if (choixSolus == 2)
                            if (animReconstruction.AnimActived)
                                animReconstruction.Draw(spriteBatch);
                            else animReconstruction.DrawLastImage(spriteBatch);
                        else spriteBatch.Draw(mon_bloc, rect, Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(mon_bloc_friable, rect, Color.White);
                    }
                }
            }

            spriteBatch.End();
        }

        public override void actionFeu()
        {
            if (ElementsIsActived && !EtatFinale)
            {
                ElementsIsActived = false;
                EtatFinale = true;
                choixSolus = 1;
                animSolidif.AnimActived = true;
            }
        }
        public override void actionEau()
        {
            if (!ElementsIsAltered && !EtatFinale)
            {
                animEmbouer.AnimActived = true;
                activerEtatSecondaire();
            }
        }
        public override void actionTerre()
        {
            if (!ElementsIsActived && !ElementsIsAltered && !EtatFinale)
            {
                ElementsIsAltered = true;
                BlocCasse.Play();
            }
            else
            {
                if (!ElementsIsActived)
                {
                    ElementsIsAltered = false;
                    EtatFinale = true;
                    choixSolus = 2;                    
                    animReconstruction.AnimActived = true;
                }
            }

        }
        public override void actionAir(Perso p)
        {

        }
    }
}