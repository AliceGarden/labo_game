using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.Elements_Interactif;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Magic___Scroll.Sortilege
{
    public class miniMap
    {
        Game1 game;
        protected List<Decor> _listDecor;
        protected List<ElementInteractifGeneral> _listElemInt;
        protected List<Ennemis> _listEnn;
        protected List<Parchment> _listParch;
        protected List<Rectangle> _listCoord;
        Vector2 _perso;
        Rectangle coordPerso;
        Texture2D persoT, ennemisT, fond;

        int screenHeight, screenWidth;
        int screenHeightQuad, screenWidthQuad;
        int newScrHQ, newScrWQ;
        Rectangle backgroundDarkPos;
        Texture2D backgroundDark;
        int xMax, yMax;
        int xMin, yMin;
        Sceptre souris;

        public miniMap(Game1 game, int xMax, int yMax, int xMin, int yMin, List<Decor> _listDecor, List<ElementInteractifGeneral> _listElemInt, List<Ennemis> _listEnn, List<Parchment> _listParch, Vector2 _perso)
        {
            this.game = game;
            this.xMax = xMax;
            this.yMax = yMax;
            this.xMin = xMin;
            this.yMin = yMin;
            this._listDecor = _listDecor;
            this._listElemInt = _listElemInt;
            this._listEnn = _listEnn;
            this._listParch = _listParch;
            this._perso = _perso;
            screenHeightQuad = _listDecor[0].rect.Height;
            screenWidthQuad = _listDecor[0].rect.Width;
        }
        public void Initialize()
        {
            screenHeight = game.Window.ClientBounds.Height;
            screenWidth = game.Window.ClientBounds.Width;
            _listCoord = new List<Rectangle>();
            souris = new Sceptre();


            newScrWQ = (screenWidth - ((screenWidth * 18)/100)) / ((xMax - xMin + 1) + 2);
            newScrHQ = (screenHeight * newScrWQ) / screenWidth;

            foreach (var t in _listDecor)
                _listCoord.Add(new Rectangle((((int)t.coordPositionAbsolu.X - xMin) * newScrWQ) + ((screenWidth * 9)/100) + (newScrWQ), (((int)t.coordPositionAbsolu.Y - yMin + 1) * newScrHQ) + ((screenHeight / 2) - (((yMax- yMin + 1)/2)*newScrHQ)), newScrWQ, newScrHQ));
            foreach (var t in _listElemInt)
                t.miniMapCoord = (new Rectangle((((int)t.coordPositionAbsolu.X - xMin) * newScrWQ) + ((screenWidth * 9) / 100) + (newScrWQ), (((int)t.coordPositionAbsolu.Y - yMin + 1) * newScrHQ) + ((screenHeight / 2) - (((yMax - yMin + 1) / 2) * newScrHQ)), newScrWQ, newScrHQ));
            foreach (var e in _listEnn)
                e.miniMapCoord = (new Rectangle((((int)e.coordPositionAbsolu.X - xMin) * newScrWQ) + ((screenWidth * 9) / 100) + (newScrWQ), (((int)e.coordPositionAbsolu.Y - yMin + 1) * newScrHQ) + ((screenHeight / 2) - (((yMax - yMin + 1) / 2) * newScrHQ)), newScrWQ, newScrHQ));
            foreach (Parchment p in _listParch)
                _listCoord.Add(new Rectangle((((int)p.coordPositionAbsolu.X - xMin) * newScrWQ) + ((screenWidth * 9) / 100) + (newScrWQ), (((int)p.coordPositionAbsolu.Y - yMin + 1) * newScrHQ) + ((screenHeight / 2) - (((yMax - yMin + 1) / 2) * newScrHQ)), newScrWQ, newScrHQ));

            coordPerso = new Rectangle(((((int)_perso.X) / screenWidthQuad) * newScrWQ) + (((screenWidth * 9) / 100)) + (newScrWQ/2), ((((int)_perso.Y) / screenHeightQuad) * newScrHQ) + ((screenHeight / 2) - (((yMax / screenHeightQuad) - 1) * newScrHQ)), newScrWQ, newScrHQ);

            backgroundDarkPos = new Rectangle(0, 0, screenWidth, screenHeight);
        }
        public void LoadContent(ContentManager content)
        {
            backgroundDark = content.Load<Texture2D>("ElementsMenu/Noir");
            fond = content.Load<Texture2D>("ElementsMenu/Carte");
            souris.LoadContent(content);
            foreach (var t in _listDecor)
                t.LoadContent(content);
            foreach (var t in _listElemInt)
                t.LoadContent(content);
            ennemisT = content.Load<Texture2D>("Ennemis/Ennemi Terre");
            foreach (Parchment p in _listParch)
                p.LoadContent(content);
            persoT = content.Load<Texture2D>("Sprite magicienne");
        }

        public void Update(GameTime gameTime, Vector2 _perso)
        {
            souris.Update(gameTime);
            int i = 0;
            foreach (var t in _listDecor)
            {
                t.rect = _listCoord[i];
                i++;
            }
            foreach (Parchment p in _listParch)
            {
                p.rect = _listCoord[i];
                i++;
            }
            foreach (var t in _listElemInt)
                t.rect = t.miniMapCoord;
            foreach (var e in _listEnn)
            {
                e.rect = e.miniMapCoord;
            }
            coordPerso = new Rectangle((((((int)_perso.X) / screenWidthQuad) - xMin) * newScrWQ) + (newScrWQ), (((((int)_perso.Y) / screenHeightQuad) - yMin) * newScrHQ) + ((screenHeight / 2) - (((yMax - yMin + 1) / 2) * newScrHQ)), newScrWQ, newScrHQ);
        }

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //spriteBatch.End();
            //spriteBatch.Begin();
            spriteBatch.Draw(backgroundDark, backgroundDarkPos, Color.White * 0.5f);
            spriteBatch.Draw(fond, new Rectangle(10,10,screenWidth - 20, screenHeight - 20), Color.White);

            foreach (var t in _listDecor)
                t.Draw(spriteBatch);
            foreach (ElementInteractifGeneral t in _listElemInt)
                t.Draw(spriteBatch);
            foreach (Parchment p in _listParch)
                p.Draw(spriteBatch);
            //spriteBatch.Begin();
            foreach (var e in _listEnn)
                spriteBatch.Draw(ennemisT, e.miniMapCoord, Color.White);
            //spriteBatch.Draw(persoT, coordPerso, new Rectangle(0, 0, persoT.Width / 12, persoT.Height / 2), Color.White);
            souris.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
