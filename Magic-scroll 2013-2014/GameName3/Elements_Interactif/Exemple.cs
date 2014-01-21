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
    class Exemple : ElementInteractifGeneral
    {
        Texture2D ma_texture;

        public Exemple(int _screenWitdh, int _screenHeight, bool _isActive, Vector2 coordPositionAbsolu, int _x = 25, int _y = 25)
            : base(coordPositionAbsolu)
        {
            base.x = _x;
            base.y = _y;
            base.screenWidth = _screenWitdh;
            base.screenHeight = _screenHeight;
            //base.ElementsIsActived = _isActive;
            //base.gravityReady = false;
            base.ElementsIsActived = false;
            base.ElementsIsBloquant = false;
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);
        }

        public override void LoadContent(ContentManager Content)
        {
            ma_texture = Content.Load<Texture2D>("ElementsInteractifs/PetitBambou");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            base.rect = new Rectangle(x, y, screenWidth, screenHeight);
            base.col = new Rectangle(x, y, screenWidth, screenHeight);
            base.bottomCol = new Rectangle(x, y + screenHeight - 10, screenWidth, 14);

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(ma_texture, rect, Color.White);
            spriteBatch.End();
        }

        public override void actionFeu()
        {

        }
        public override void actionEau()
        {

        }
        public override void actionTerre()
        {

        }
        public override void actionAir(Perso p)
        {

        }
    }
}
