using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

/// <summary>
/// Pour ajouter un élément, Il faut rajouter une classe comme celle-ci (copier-coller) et la remplir avec les propriétés que l'on a besoin.
///     - C'est-à-dire remplacer Exemple à la ligne 'class Exemple : ElementInteractifGeneral' par le nom de l'élément.
///     - Mettre la texture Correspondante dans le LoadContent.
///     - Mettre les modifications en fonction de s'il est activer ou pas dans le Update.
///     - Dans la partie basse de cette classe, on peut trouver actionFeu, actionEau, actionTerre, actionAir, les remplir en 
///         fonction des interactions avec le pouvoir correspondant, si il ne se passe rien, ne rien mettre. Pour les fonctions basique comme supprimer,
///         activer l'élément ou le désactiver regarder dans la classe ElementInteractifGeneral.
///     
///     - Une fois la classe créer et compléter, aller dans la classe Monde.cs, dans la méthode chargerElementsInteractif() et dans le switch (readText[zdz])
///         rajouter la ligne avec la lettre correspondante.
///     - 
/// </summary>

namespace Magic___Scroll.Elements_Interactif
{
    class BlocCendre : ElementInteractifGeneral
    {
        Texture2D mon_bloc_friable;
        Texture2D trou;
        Texture2D mon_bloc;
        Texture2D mon_bloc_feu;
        Animation animSolidif;
        Animation animReconstruction;
        Animation animCassure;
        Int16 choixSolus;
        private bool alreadyBreak;
        Rectangle colFlamme;
        DateTime timer;
        bool TimerActive = false;

        public BlocCendre(int _screenWitdh, int _screenHeight, bool _isActive, bool _isAltered, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            //base.gravityReady = false;
            base.ElementsIsActived = _isActive;
            base.ElementsIsAltered = _isAltered;
            base.ElementsIsBloquant = _isActive;
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
            base.EtatFinale = false;
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y, screenWidth, screenHeight);
            colFlamme = new Rectangle(x - (screenWidth), y, (screenWidth) * 3, screenHeight);
            base.gravityReady = false;
            animSolidif = new Animation(false, "ElementsInteractifs/Sprite Terrain solidifie", base.rect, 6, 1, 1, 6);
            animReconstruction = new Animation(false, "ElementsInteractifs/Sprite Terrain reconstruction", base.rect, 6, 1, 1, 6);
            animCassure = new Animation(false, "ElementsInteractifs/Sprite Terrain cassure", new Rectangle(base.rect.X, base.rect.Y, base.rect.Width, base.rect.Height + _screenHeight), 6, 1, 1, 6);
            choixSolus = 0;
            alreadyBreak = false;
            timer = DateTime.Now;
        }

        public override void LoadContent(ContentManager Content)
        {
            animSolidif.LoadContent(Content);
            animReconstruction.LoadContent(Content);
            animCassure.LoadContent(Content);
            mon_bloc_friable = Content.Load<Texture2D>("ElementsInteractifs/Terrain friable feu");
            mon_bloc = Content.Load<Texture2D>("ElementsInteractifs/Terrain feu");
            mon_bloc_feu = Content.Load<Texture2D>("ElementsInteractifs/Terrain enflammer");
            trou = Content.Load<Texture2D>("ElementsInteractifs/Terrain friable detruit");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (ElementsIsBloquant && ElementsIsActived)
            {
                rect = new Rectangle(x, y - screenHeight, screenWidth, screenHeight * 2);
                col = new Rectangle(x, y - screenHeight, screenWidth, screenHeight * 2);
            }
            else
            {
                rect = new Rectangle(x, y, screenWidth, screenHeight);
                col = new Rectangle(x, y, screenWidth, screenHeight);
            }

            if (ElementsIsActived)
            {
                if (TimerActive && timer > (DateTime.Now))
                {
                    ElementsIsBloquant = false;
                    EtatFinale = true;
                }
                else
                {
                    ElementsIsBloquant = true;
                    EtatFinale = false;
                }
            }         
            
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
            if (choixSolus == 1)
                animSolidif.Update(gameTime, base.rect);
            if (choixSolus == 2)
                animReconstruction.Update(gameTime, base.rect);

            

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
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
                        if(ElementsIsBloquant)
                                spriteBatch.Draw(mon_bloc_feu, rect, Color.White);
                        else
                            spriteBatch.Draw(mon_bloc_friable, rect, Color.White);
                    }
                }

            spriteBatch.End();
        }

        public override void actionFeu()
        {
            if (ElementsIsActived)
            {
                ElementsIsActived = false;
                ElementsIsBloquant = false;
            }
        }
        public override void actionEau()
        {
            if (!EtatFinale && !ElementsIsAltered)
            {
                ElementsIsActived = false;
                ElementsIsBloquant = false;
                EtatFinale = true;
                choixSolus = 1;
                animSolidif.AnimActived = true;
            }
        }
        public override void actionTerre()
        {
            if (!ElementsIsActived && !ElementsIsAltered && !EtatFinale)
            {
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
            //if (!ElementsIsActived && !ElementsIsAltered && !EtatFinale)
            //{
            //    ElementsIsAltered = true;
            //}
            //if (ElementsIsActived)
            //{
            //    deplacementElement(p);
            //}
            //else
            //{
            //    deplacementEnCours = 0;
            //    seDeplace = true;
            //    if (p.rect.X < x)
            //    {
            //        seDeplaceVersGauche = false;
            //    }
            //    else seDeplaceVersGauche = true;
            //}

            timer = DateTime.Now.AddSeconds(15);
            TimerActive = true;
        }
    }
}
