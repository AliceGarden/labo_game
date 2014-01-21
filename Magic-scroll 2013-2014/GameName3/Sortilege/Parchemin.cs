using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Magic___Scroll.Conception_du_niveau;

namespace Magic___Scroll.Sortilege
{
    class Parchemin //C'est en fait la classe RoueDesPouvoirs
    {
        Monde mondeEnCours;

        Texture2D RoueDesPouvoirs, AffichageCompteur;
        Texture2D sortEau, sortFeu, sortTerre, sortVent;
        SpriteFont ParchmentFont;
        public Texture2D TrucDesSorts { get; set; }
        public int sortActive { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        int niveauEnCourPrListe;

        Rectangle rect;
        private int Height = 352;
        private int Width = 352;
        

        public Parchemin(Monde mondePetit, int niveauxEnCour, int screenWidth, int screenHeight)
        {
            mondeEnCours = mondePetit;
            niveauEnCourPrListe = niveauxEnCour -1;
            x = screenWidth /2;
            y = screenHeight /2;
            sortActive = 0;
            rect = new Rectangle(x, y, Width, Height);
        }

        public void LoadContent(ContentManager Content)
        {
            sortEau = Content.Load<Texture2D>("RouePouvoir-Sceptre/Eau Active");
            sortTerre = Content.Load<Texture2D>("RouePouvoir-Sceptre/Terre Active");
            sortFeu = Content.Load<Texture2D>("RouePouvoir-Sceptre/Feu Active");
            sortVent = Content.Load<Texture2D>("RouePouvoir-Sceptre/Air Active");
            RoueDesPouvoirs = Content.Load<Texture2D>("RouePouvoir-Sceptre/Roue des pouvoir");
            TrucDesSorts = Content.Load<Texture2D>("RouePouvoir-Sceptre/Truc des sorts");
            AffichageCompteur = Content.Load<Texture2D>("Parchemin/Affichage Compteur");
            ParchmentFont = Content.Load<SpriteFont>("50ShowCard");
        }

        public void Update(Point centrePosition)
        {
            x = centrePosition.X - (Width / 2);
            y = centrePosition.Y - (Height / 2);
            rect = new Rectangle(x, y, Width, Height);
        }

        public void DrawCompteur(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AffichageCompteur, new Rectangle(0, 0, 450, 182), Color.White);
            spriteBatch.DrawString(ParchmentFont, mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCourPrListe].nbParcheminA.ToString(), new Vector2(40, 25), Color.White * 0.9f);
            spriteBatch.DrawString(ParchmentFont, mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCourPrListe].nbParcheminE.ToString(), new Vector2(152, 25), Color.White * 0.9f);
            spriteBatch.DrawString(ParchmentFont, mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCourPrListe].nbParcheminF.ToString(), new Vector2(255, 25), Color.White * 0.9f);
            spriteBatch.DrawString(ParchmentFont, mondeEnCours.ListeDesNiveauxDunMonde[niveauEnCourPrListe].nbParcheminT.ToString(), new Vector2(357, 25), Color.White * 0.9f);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sortActive == 1) spriteBatch.Draw(sortTerre, rect, Color.White);
            if (sortActive == 2) spriteBatch.Draw(sortFeu, rect, Color.White);
            if (sortActive == 3) spriteBatch.Draw(sortEau, rect, Color.White);
            if (sortActive == 4) spriteBatch.Draw(sortVent, rect, Color.White);
            spriteBatch.Draw(RoueDesPouvoirs, rect, Color.White);    
        }
    }
}
