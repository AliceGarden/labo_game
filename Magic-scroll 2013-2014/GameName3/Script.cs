using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magic___Scroll.ScreenManagerFolder;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Magic___Scroll
{
    class Script
    {
        Setting setting;
        public bool ScriptExisting { get; set; }

        SpriteFont showCard;
        Texture2D miaou;

        TimeSpan lastUpdate;
        int dureeAffichage;

        private bool affichageEnCours;
        private string text1;
        private string text2;
        private string text3;
        private string text4;
        private string text5;
        private int affichParagraphe;
        private int paragrapheMax;
        bool script1IsActive;
        bool script2IsActive;

        public Script()
        {

        }

        public void Initialize()
        {
            setting = Setting.getInstance();
            ScriptExisting = false;

            if (setting.currentWorld == 0)
                ScriptExisting = true;
            dureeAffichage = 6;
            text1 = "";
            text2 = "";
            text3 = "";
            text4 = "";
            text5 = "";
            script1IsActive = false;
            affichParagraphe = 0;
            paragrapheMax = 0;
        }

        public void LoadContent(ContentManager content)
        {
            showCard = content.Load<SpriteFont>("ShowCard");
            miaou = content.Load<Texture2D>("ElementsInteractifs/=3");
        }

        public void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Subtract(lastUpdate).TotalSeconds >= dureeAffichage)
            {
                if (affichParagraphe < paragrapheMax && affichageEnCours)
                    affichParagraphe++;
                else
                    affichageEnCours = false;
                lastUpdate = gameTime.TotalGameTime;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (affichageEnCours)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(miaou, new Rectangle(100, 100, miaou.Width, miaou.Height), Color.White);
                spriteBatch.DrawString(showCard, text1, new Vector2(miaou.Width + 150, 105), Color.Green);
                spriteBatch.DrawString(showCard, text2, new Vector2(miaou.Width + 150, 145), Color.Green);
                spriteBatch.DrawString(showCard, text3, new Vector2(miaou.Width + 150, 185), Color.Green);
                spriteBatch.DrawString(showCard, text4, new Vector2(miaou.Width + 150, 225), Color.Green);
                spriteBatch.DrawString(showCard, text5, new Vector2(miaou.Width + 150, 265), Color.Green);
                spriteBatch.End();
            }
        }

        public void script1()
        {
            if (!script1IsActive)
            {
                script1IsActive = true;
                affichageEnCours = true;
                paragrapheMax = 2;
            }
            switch(affichParagraphe)
            {
                case 0:
                    dureeAffichage = 6;
                    text1 = "";
                    text2 = "Je me suis perdu, et je n'arrive pas a trouver la";
                    text3 = "sortie tu pourrais venir me chercher?";
                    text4 = "";
                    text5 = "";
                    break;
                case 1:
                    dureeAffichage = 6;
                    text1 = "";
                    text2 = "Pour te deplacer tu as le choix entre les touches";
                    text3 = "Q D et Z ou alors les touches fleches de ton clavier";
                    text4 = "Et sinon tu vois le bambou a ta droite?";
                    text5 = "";
                    break;
                case 2:
                    dureeAffichage = 8;
                    text1 = "Tu peut interargir avec!";
                    text2 = "Tu possedes des parchemins magiques. Utilise-les pour voir";
                    text3 = "a quoi il servent en cliquant sur les elements qui te semblent";
                    text4 = "important puis choisit le pouvoir qui t'interesse.";
                    text5 = "";
                    break;
            }
        }

        public void script2()
        {
            if (!script2IsActive)
            {
                script2IsActive = true;
                affichageEnCours = true;
                paragrapheMax = 1;
            }
            switch (affichParagraphe)
            {
                case 0:
                    dureeAffichage = 6;
                    text1 = "";
                    text2 = "A tout moment tu peut regarder ou tu te trouve en regardant";
                    text3 = "la carte du niveau en appuyant sur M.";
                    text4 = "";
                    text5 = "";
                    break;
                case 1:
                    dureeAffichage = 6;
                    text1 = "";
                    text2 = "En haut a droite, se trouvent le boutons pour recommencer";
                    text3 = "le niveau et celui qui te permet de mettre le jeu en pause.";
                    text4 = "";
                    text5 = "";
                    break;
            }
        }
    }
}
