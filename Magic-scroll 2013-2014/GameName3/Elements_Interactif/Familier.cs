using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Magic___Scroll.Elements_Interactif
{

    class Familier : ElementInteractifGeneral
    {
        Texture2D familier;    // On creer un texture pour notre personnage ( c'est l'image qu'il aura )

        public Familier(int _screenWidth, int _screenHeight, Vector2 coordPositionAbsolu, int _x = 50, int _y = 100) : base(coordPositionAbsolu)
        {
            base.x = _x; // la position en X -------
            base.y = _y; // la position vertical
            base.screenHeight = _screenHeight;
            base.screenWidth = _screenWidth;
            base.rect = new Rectangle(x, y, screenHeight, screenHeight);
            base.col = new Rectangle(x, y, screenHeight, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)     // pendant le chargement :
        {
            familier = Content.Load<Texture2D>("ElementsInteractifs/=3");
        }

        public override void Update(GameTime gameTime)    // Boucle dans laquelle on regarde si on appui sur un touche
        {
            base.Update(gameTime);
            base.bottomCol = new Rectangle(x + (screenWidth / 4), y + screenHeight - 10, (screenWidth / 2), 14);
            base.rect = new Rectangle(x, y, screenHeight, screenHeight);
            base.col = new Rectangle(x + (screenWidth / 4), y, (screenWidth / 2), screenHeight);
        }

        public override void Draw(SpriteBatch spriteBatch)   // On dessine notre personnage
        {
            spriteBatch.Begin();
            spriteBatch.Draw(familier, base.rect, Color.White);
            spriteBatch.End();                          // on leve notre crayon
        }
    }
}
