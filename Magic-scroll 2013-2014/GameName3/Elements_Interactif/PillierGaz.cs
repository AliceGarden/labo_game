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
    class PillierGaz : ElementInteractifGeneral
    {
        Texture2D Pillier_Gaz;
        Texture2D Pillier_Feu;
        Texture2D Pillier;
        Texture2D Pillier_Terre;
        public Rectangle HautPacerelle;

        public PillierGaz(int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            //base.gravityReady = false;
            base.ElementsIsActived = _isActive;
            base.ElementsIsBloquant = _isActive;
            base.ElementsIsBase = false;
            HautPacerelle = new Rectangle(x, y, 0, 0);
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)
        {
            Pillier = Content.Load<Texture2D>("ElementsInteractifs/pillier éteint");
            Pillier_Gaz = Content.Load<Texture2D>("ElementsInteractifs/geyser gaz");
            Pillier_Feu = Content.Load<Texture2D>("ElementsInteractifs/pillier flame");
            Pillier_Terre = Content.Load<Texture2D>("ElementsInteractifs/geyser péti");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            if (!base.ElementsIsBase)
            {
                if (!base.ElementsIsActived)
                {
                    HautPacerelle = new Rectangle(x, y - (screenHeight * 3), screenWidth, screenHeight);
                }
                else
                {
                    HautPacerelle = new Rectangle(x, y, 0, 0);
                }
                base.rect = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 2), (screenWidth / 2), screenHeight * 3);
                base.headCol = new Rectangle(x + (screenWidth / 4), y - ((screenHeight * 2) + (screenHeight / 4)) + 1, (screenWidth / 2), (screenHeight / 4) - 2);
                base.col = new Rectangle(x + (screenWidth / 4), y - (screenHeight * 2) + 2, (screenWidth / 2), (screenHeight * 3) + 10);
            }
            else
            {
                base.rect = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
                HautPacerelle = new Rectangle(x, y, 0,0);
            }            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if (ElementsIsActived)
                spriteBatch.Draw(Pillier_Feu, rect, Color.White);
            else 
                if (ElementsIsAltered)
                    spriteBatch.Draw(Pillier_Terre, rect, Color.White);
                else
                if (ElementsIsBase)
                    spriteBatch.Draw(Pillier, rect, Color.White);
                else
                    spriteBatch.Draw(Pillier_Gaz, rect, Color.White);
            spriteBatch.Draw(Pillier, HautPacerelle, Color.White);
            spriteBatch.End();
        }

        public override void actionFeu()
        {
            if (!ElementsIsBase && !ElementsIsAltered)
            {
                ElementsIsActived = true;
                ElementsIsBloquant = true;
            }
        }
        public override void actionEau()
        {
            if (ElementsIsActived)
            {
                ElementsIsAltered = true;
                ElementsIsActived = false;
            }
        }
        public override void actionTerre()
        {
            //if (ElementsIsActived)
            //    ElementsIsAltered = true;
            //else
            //{
            if (ElementsIsAltered)
            {
                ElementsIsAltered = false;
                ElementsIsActived = false;
                ElementsIsBloquant = false;
                ElementsIsBase = true;
            }
            else
            {
                if (ElementsIsBase)
                    ElementsIsBase = false;
            }
            //}
                
        }
        public override void actionAir(Perso p)
        {
                      
        }
    }
}
